using Core.Dialog.Controller;
using Core.Dialog.Manager;
using Core.UI.Service;
using Cysharp.Threading.Tasks;
using Descriptor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Offer
{
	public sealed class OfferDialog : MonoBehaviour, IDialog
	{
		private const int ITEMS_PER_ROW = 3;
		
		[SerializeField]
		private TextMeshProUGUI _headerText = null!;
		[SerializeField]
		private TextMeshProUGUI _descriptionText = null!;
		[SerializeField]
		private RectTransform _itemsFirstRow = null!;
		[SerializeField]
		private RectTransform _itemsSecondRow = null!;
		[SerializeField]
		private Image _offerIcon = null!;
		[SerializeField]
		private TextMeshProUGUI _originalPriceText = null!;
		[SerializeField]
		private TextMeshProUGUI _discountPriceText = null!;
		[SerializeField]
		private GameObject _discountLabel = null!;
		[SerializeField]
		private TextMeshProUGUI _discountText = null!;
		[SerializeField]
		private Button _button = null!;

		private OffersDescriptor _offersDescriptor = null!;
		private SpritesDescriptor _spritesDescriptor = null!;
		private DialogManager _dialogManager = null!;
		private UIService _uiService = null!;

		private void Awake()
		{
			_button.onClick.AddListener(OnClick);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveAllListeners();
		}

		[Inject]
		private void Construct(OffersDescriptor offersDescriptor,
		                       SpritesDescriptor spritesDescriptor,
		                       DialogManager dialogManager,
		                       UIService uiService)
		{
			_offersDescriptor = offersDescriptor;
			_spritesDescriptor = spritesDescriptor;
			_dialogManager = dialogManager;
			_uiService = uiService;
		}

		async UniTask IDialog.Configure(string offerId)
		{
			OffersDescriptor.OfferData offerData = _offersDescriptor.Require(offerId);
			_headerText.text = offerData.Title;
			_descriptionText.text = offerData.Description;

			for (int i = 0; i < offerData.Items.Count; i++)
			{
				GameObject itemGo = await _uiService.CreateAsync
						(_offersDescriptor.OfferItemPrefab.AssetGUID, i <= ITEMS_PER_ROW ? _itemsFirstRow : _itemsSecondRow);
				OfferItem item = itemGo.GetComponent<OfferItem>();
				await item.Configure(offerData.Items[i]);
			}

			Sprite iconSprite = await _uiService.LoadAsync<Sprite>
					(_spritesDescriptor.Require(offerData.IconId).AssetGUID);
			_offerIcon.sprite = iconSprite;
			_originalPriceText.text = $"${offerData.Price - offerData.Price * 0.01f * offerData.DiscountPercent:F2}";
			_discountPriceText.enabled = offerData.DiscountPercent > 0f;
			_discountPriceText.text = $"<s>${offerData.Price:F2}</s>";
			_discountLabel.SetActive(offerData.DiscountPercent > 0f);
			_discountText.text = $"-{offerData.DiscountPercent}%";
		}

		void IDialog.Show()
		{
			gameObject.SetActive(true);
		}

		void IDialog.Hide()
		{
			gameObject.SetActive(false);
		}

		private void OnClick()
		{
			_dialogManager.Hide(gameObject);
		}
	}
}
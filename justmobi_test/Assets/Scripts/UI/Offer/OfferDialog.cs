using Core.Dialog.Controller;
using Core.Dialog.Manager;
using Cysharp.Threading.Tasks;
using Descriptor;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using VContainer;

namespace UI.Offer
{
	public sealed class OfferDialog : MonoBehaviour, IDialog
	{
		[SerializeField]
		private TextMeshProUGUI _headerText = null!;
		[SerializeField]
		private TextMeshProUGUI _descriptionText = null!;
		[SerializeField]
		private RectTransform _itemsContent = null!;
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

		private void Awake()
		{
			_button.onClick.AddListener(OnClick);
		}

		[Inject]
		private void Construct(OffersDescriptor offersDescriptor,
		                       SpritesDescriptor spritesDescriptor,
		                       DialogManager dialogManager)
		{
			_offersDescriptor = offersDescriptor;
			_spritesDescriptor = spritesDescriptor;
			_dialogManager = dialogManager;
		}

		async UniTask IDialog.Configure(params object[] initParam)
		{
			OffersDescriptor.OfferData offerData = _offersDescriptor.Require(initParam[0].ToString());
			_headerText.text = offerData.Title;
			_descriptionText.text = offerData.Description;

			for (int i = 0; i < offerData.Items.Count; i++)
			{
				GameObject kek = await Addressables.InstantiateAsync("OfferItem", _itemsContent);
				Image image = kek.GetComponentInChildren<Image>();
				TextMeshProUGUI text = kek.GetComponentInChildren<TextMeshProUGUI>();
				string spriteId = offerData.Items[i].SpriteId;
				Sprite itemSprite = await Addressables.LoadAssetAsync<Sprite>(_spritesDescriptor.Require(spriteId).AssetGUID);
				image.sprite = itemSprite;
				text.text = $"{offerData.Items[i].Amount}";
			}

			Sprite iconSprite = await Addressables.LoadAssetAsync<Sprite>
					(_spritesDescriptor.Require(offerData.IconId).AssetGUID);
			_offerIcon.sprite = iconSprite;
			_originalPriceText.text = $"${offerData.Price - offerData.Price * 0.01f * offerData.DiscountPercent}";
			_discountPriceText.enabled = offerData.DiscountPercent > 0f;
			_discountPriceText.text = $"<s>${offerData.Price}</s>";
			_discountLabel.SetActive(offerData.DiscountPercent > 0f);
			_discountText.text = $"{offerData.DiscountPercent}%";
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
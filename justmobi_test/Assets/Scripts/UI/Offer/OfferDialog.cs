using System.Globalization;
using System.Threading;
using Core.Dialog.Controller;
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

		private void Awake()
		{
			_button.onClick.AddListener(OnClick);
		}

		[Inject]
		private void Construct(OffersDescriptor offersDescriptor,
		                       SpritesDescriptor spritesDescriptor)
		{
			_offersDescriptor = offersDescriptor;
			_spritesDescriptor = spritesDescriptor;
		}

		async UniTask IDialog.Configure(params object[] initParam)
		{
			OffersDescriptor.OfferData offerData = _offersDescriptor.Require(initParam[0].ToString());
			_headerText.text = offerData.Title;
			_descriptionText.text = offerData.Description;
			//fill items
			Sprite iconSprite = await Addressables.LoadAssetAsync<Sprite>
					(_spritesDescriptor.Require(offerData.IconId).AssetGUID);
			_offerIcon.sprite = iconSprite;
			_originalPriceText.text = $"${offerData.Price}";
			_discountPriceText.enabled = offerData.DiscountPercent > 0f;
			_discountPriceText.text = $"{offerData.Price - offerData.Price * 0.01f * offerData.DiscountPercent}";
			_discountLabel.SetActive(offerData.DiscountPercent > 0f);
			_discountText.text = $"{offerData.DiscountPercent}";
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
			
		}
	}
}
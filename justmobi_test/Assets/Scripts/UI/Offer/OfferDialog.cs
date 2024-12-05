using System.Linq;
using Core.Dialog.Controller;
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
		
		[Inject]
		private void Construct(OffersDescriptor offersDescriptor,
		                       SpritesDescriptor spritesDescriptor)
		{
			_offersDescriptor = offersDescriptor;
			_spritesDescriptor = spritesDescriptor;
		}
		
		public void Configure(params object[] initParam)
		{
			OffersDescriptor.OfferData offerData = _offersDescriptor.Require(initParam[0].ToString());
			_headerText.text = offerData.Title;
			_descriptionText.text = offerData.Description;
			//fill items
			//_offerIcon.sprite = _spritesDescriptor.Require(offerData.IconId);
		}
		
		public void Show()
		{
			gameObject.SetActive(true);
		}
		
		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}
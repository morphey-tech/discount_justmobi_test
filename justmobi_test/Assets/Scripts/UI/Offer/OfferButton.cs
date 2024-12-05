using Core.Dialog.Manager;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Offer
{
	[RequireComponent(typeof(Button))]
	public sealed class OfferButton : MonoBehaviour
	{
		private const string OFFER_DIALOG_ASSET_ID = "OfferDialog";
		
		[field: SerializeField, ValueDropdown("@DescriptorParamsHelper.GetAvailableOffersIds()")] 
		private string _offerId = null!;
		
		private Button _button = null!;

		private DialogManager _dialogManager = null!;
		
		private void Awake()
		{
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClick);
		}

		[Inject]
		private void Construct(DialogManager dialogManager)
		{
			_dialogManager = dialogManager;
		}

		private void OnClick()
		{
			_dialogManager.ShowModal(OFFER_DIALOG_ASSET_ID, _offerId);
		}
	}
}
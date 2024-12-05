using Core.Dialog.Manager;
using Descriptor.Utils;
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
		
		[field: SerializeField, ValueDropdown(DescriptorParamsHelper.AVAILABLE_OFFERS_LIST)] 
		private string _offerId = null!;
		
		private Button _button = null!;

		private DialogManager _dialogManager = null!;
		
		private void Awake()
		{
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClick);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveAllListeners();
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
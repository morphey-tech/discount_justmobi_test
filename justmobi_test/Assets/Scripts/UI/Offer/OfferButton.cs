using Core.Dialog.Manager;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Offer
{
	[RequireComponent(typeof(Button))]
	public sealed class OfferButton : MonoBehaviour
	{
		[field: SerializeField] 
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
			//Show offer dialog by id
		}
	}
}
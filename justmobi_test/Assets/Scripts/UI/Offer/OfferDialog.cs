using Core.Dialog.Controller;
using Descriptor;
using UnityEngine;

namespace UI.Offer
{
	public sealed class OfferDialog : MonoBehaviour, IDialog
	{
		private OffersDescriptor _descriptor = null!;
		
		public void Configure(params object[] initParam)
		{
			_descriptor = initParam[0] as OffersDescriptor;
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
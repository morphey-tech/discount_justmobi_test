using Core.UI.Service;
using Cysharp.Threading.Tasks;
using Descriptor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Offer
{
	public sealed class OfferItem : MonoBehaviour
	{
		[SerializeField]
		private Image _icon = null!;
		[SerializeField]
		private TextMeshProUGUI _amount = null!;

		private SpritesDescriptor _spritesDescriptor = null!;
		private UIService _uiService = null!;
		
		[Inject]
		private void Construct(SpritesDescriptor spritesDescriptor, UIService uiService)
		{
			_spritesDescriptor = spritesDescriptor;
			_uiService = uiService;
		}
		
		public async UniTask Configure(OffersDescriptor.OfferReward descriptor)
		{
			string spriteId = _spritesDescriptor.Require(descriptor.SpriteId).AssetGUID;
			Sprite iconSprite = await _uiService.LoadAsync<Sprite>(spriteId);
			_icon.sprite = iconSprite;
			_amount.text = $"{descriptor.Amount}";
		}
	}
}
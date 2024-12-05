using Cysharp.Threading.Tasks;
using Descriptor;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
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
		
		[Inject]
		private void Construct(SpritesDescriptor spritesDescriptor)
		{
			_spritesDescriptor = spritesDescriptor;
		}
		
		public async UniTask Configure(OffersDescriptor.OfferReward descriptor)
		{
			AssetReference spriteId = _spritesDescriptor.Require(descriptor.SpriteId);
			Sprite iconSprite = await Addressables.LoadAssetAsync<Sprite>(spriteId);
			_icon.sprite = iconSprite;
			_amount.text = $"{descriptor.Amount}";
		}
	}
}
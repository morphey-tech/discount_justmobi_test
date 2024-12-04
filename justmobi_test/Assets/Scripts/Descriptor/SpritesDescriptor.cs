using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Descriptor
{
	[CreateAssetMenu(fileName = "SpritesDescriptor", menuName = "Descriptor/SpritesDescriptor")]
	public sealed class SpritesDescriptor : ScriptableObject
	{
		[field: SerializeField]
		public List<SpriteData> Collection { get; private set; } = null!;
		
		public class SpriteData
		{
			public string Id;
			public AssetReference Asset;
		}
	}
}
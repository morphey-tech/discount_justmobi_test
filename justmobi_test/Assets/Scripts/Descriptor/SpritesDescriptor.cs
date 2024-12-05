using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Descriptor
{
	[CreateAssetMenu(fileName = "SpritesDescriptor", menuName = "Descriptor/SpritesDescriptor")]
	public sealed class SpritesDescriptor : ScriptableObject
	{
		[field: SerializeField]
		public List<SpriteData> Collection { get; private set; } = null!;

		[Serializable]
		public class SpriteData
		{
			[Required]
			public string Id;
			[Required]
			public AssetReference Asset;
		}

		private void OnValidate()
		{
			for (int i = 0; i < Collection.Count; i++)
			{
				for (int j = Collection.Count - 1; j >= 0; j--)
				{
					if (i == j)
					{
						continue;
					}
					if (Collection[i].Id != Collection[j].Id)
					{
						continue;
					}
					Debug.LogWarning($"Collection contains duplicates. id={Collection[j].Id}");
					Collection[j].Id = string.Concat(Collection[j].Id, " duplicate");
				}
			}
		}
	}
}
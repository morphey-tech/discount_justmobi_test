using System.Collections.Generic;
using UnityEngine;

namespace Descriptor
{
	[CreateAssetMenu(fileName = "ItemsDescriptor", menuName = "Descriptor/ItemsDescriptor")]
	public sealed class ItemsDescriptor : ScriptableObject
	{
		[field: SerializeField]
		public List<ItemData> Collection { get; private set; } = null!;
		
		public class ItemData
		{
			public string SpriteId;
			public int Amount;
		}
	}
}
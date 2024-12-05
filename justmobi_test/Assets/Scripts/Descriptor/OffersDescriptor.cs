using System;
using System.Collections.Generic;
using System.Linq;
using Descriptor.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptor
{
	[CreateAssetMenu(fileName = "OffersDescriptor", menuName = "Descriptor/OffersDescriptor")]
	public sealed class OffersDescriptor : ScriptableObject
	{
		[field: SerializeField]
		public List<OfferData> Collection { get; private set; } = null!;
		
		public OfferData Require(string id)
		{
			return Collection.First(d => d.Id == id);
		}

		public OfferData? Get(string id)
		{
			return Collection.FirstOrDefault(d => d.Id == id);
		}
		
		[Serializable]
		public class OfferData
		{
			[Required]
			public string Id;
			[Required]
			public string Title;
			[Required]
			public string Description;
			[Required]
			public List<OfferReward> Items;
			[MinValue(1)]
			public float Price;
			[MinValue(0)]
			public float DiscountPercent;
			[ValueDropdown(DescriptorParamsHelper.AVAILABLE_SPRITES_LIST)]
			public string IconId;
		}

		[Serializable]
		public class OfferReward
		{
			[ValueDropdown(DescriptorParamsHelper.AVAILABLE_SPRITES_LIST)]
			public string SpriteId;
			[MinValue(1)]
			public int Amount;
		}

		private void OnValidate()
		{
			
		}
	}
}
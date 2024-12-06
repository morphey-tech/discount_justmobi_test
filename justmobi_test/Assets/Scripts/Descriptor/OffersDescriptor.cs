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
		private const int MIN_OFFERS_COUNT = 3;
		private const int MAX_OFFERS_COUNT = 6;

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
			foreach (OfferData offer in Collection)
			{
				if (offer.Items.Count < MIN_OFFERS_COUNT)
				{
					for (int i = 0; i < MIN_OFFERS_COUNT - offer.Items.Count; i++)
					{
						offer.Items.Add(new OfferReward());
					}
				}
				if (offer.Items.Count > MAX_OFFERS_COUNT)
				{
					for (int i = offer.Items.Count - 1; i >= MAX_OFFERS_COUNT; i--)
					{
						offer.Items.RemoveAt(i);
					}
				}
			}
		}
	}
}
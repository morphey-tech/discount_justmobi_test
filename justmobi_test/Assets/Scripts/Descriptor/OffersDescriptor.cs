using System;
using System.Collections.Generic;
using System.Linq;
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
			public string Id;
			public string Title;
			public string Description;
			public List<OfferReward> Items;
			public float Price;
			public float DiscountPercent;
			public string IconId;
		}

		[Serializable]
		public class OfferReward
		{
			public string SpriteId;
			public int Amount;
		}
	}
}
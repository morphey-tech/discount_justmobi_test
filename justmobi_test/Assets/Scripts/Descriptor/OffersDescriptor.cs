using System.Collections.Generic;
using UnityEngine;

namespace Descriptor
{
	[CreateAssetMenu(fileName = "OffersDescriptor", menuName = "Descriptor/OffersDescriptor")]
	public sealed class OffersDescriptor : ScriptableObject
	{
		[field: SerializeField]
		public List<OfferData> Collection { get; private set; } = null!;
		
		public class OfferData
		{
			public string Id;
			public string Title;
			public string Description;
			public List<string> Items;
			public float Price;
			public float Discount;
			public string IconId;
		}
	}
}
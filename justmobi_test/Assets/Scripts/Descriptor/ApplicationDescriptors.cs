using UnityEngine;

namespace Descriptor
{
	public sealed class ApplicationDescriptors : MonoBehaviour
	{
		[field: SerializeField]
		public OffersDescriptor OffersDescriptor { get; private set; } = null!;

		[field: SerializeField]
		public SpritesDescriptor SpritesDescriptor { get; private set; } = null!;
	}
}
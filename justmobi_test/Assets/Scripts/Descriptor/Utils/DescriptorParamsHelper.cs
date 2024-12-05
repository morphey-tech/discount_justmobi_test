using System.Collections;
using System.Linq;
using UnityEditor;

namespace Descriptor.Utils
{
	public static class DescriptorParamsHelper
	{
		public const string AVAILABLE_SPRITES_LIST = "@DescriptorParamsHelper.GetAvailableSpritesIds()";
		public const string AVAILABLE_OFFERS_LIST = "@DescriptorParamsHelper.GetAvailableOffersIds()";
		
		private static IEnumerable GetAvailableSpritesIds()
		{
			const string root = "Assets/Bundles/Descriptor/SpritesDescriptor.asset";
			SpritesDescriptor spritesDescriptor = AssetDatabase.LoadAssetAtPath<SpritesDescriptor>(root);
			return spritesDescriptor.Collection.Select(s => s.Id);
		}
		
		private static IEnumerable GetAvailableOffersIds()
		{
			const string root = "Assets/Bundles/Descriptor/OffersDescriptor.asset";
			OffersDescriptor spritesDescriptor = AssetDatabase.LoadAssetAtPath<OffersDescriptor>(root);
			return spritesDescriptor.Collection.Select(s => s.Id);
		}
	}
}
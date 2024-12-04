using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
	public sealed class ApplicationScope : LifetimeScope
	{
		[field: SerializeField] 
		private Transform _applicationDescriptor = null!;
		
		protected override void Configure(IContainerBuilder builder)
		{
				//Register descriptors
				//Register DialogManager
		}
	}
}

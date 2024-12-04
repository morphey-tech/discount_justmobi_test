using Core.Dialog.Manager;
using Core.Dialog.Service;
using Descriptor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
	public sealed class ApplicationScope : LifetimeScope
	{
		[field: SerializeField]
		private ApplicationDescriptors ApplicationDescriptors { get; set; } = null!;
		
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<DialogManager>(Lifetime.Singleton);
			builder.Register<AddresableDialogLoadService>(Lifetime.Singleton).AsImplementedInterfaces();

			builder.RegisterInstance(ApplicationDescriptors.ItemsDescriptor);
			builder.RegisterInstance(ApplicationDescriptors.OffersDescriptor);
			builder.RegisterInstance(ApplicationDescriptors.SpritesDescriptor);
		}
	}
}

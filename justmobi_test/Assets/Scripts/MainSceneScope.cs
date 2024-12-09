using VContainer;
using VContainer.Unity;

public sealed class MainSceneScope : LifetimeScope
{
	protected override void Configure(IContainerBuilder builder)
	{
		builder.RegisterComponentInHierarchy<MainSceneBootstrap>().AsImplementedInterfaces();
	}
}
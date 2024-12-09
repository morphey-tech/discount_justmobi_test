using UI.Offer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public sealed class MainSceneBootstrap : MonoBehaviour, IInitializable
{
	[SerializeField]
	private OfferButton _offerButton = null!;

	private IObjectResolver _objectResolver = null!;
		
	[Inject]
	private void Construct(IObjectResolver objectResolver)
	{
		_objectResolver = objectResolver;
	}
		
	void IInitializable.Initialize()
	{
		_objectResolver.InjectGameObject(_offerButton.gameObject);
	}
}
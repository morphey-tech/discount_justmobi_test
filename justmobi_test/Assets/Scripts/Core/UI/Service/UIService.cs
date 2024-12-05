using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace Core.UI.Service
{
	public sealed class UIService
	{
		private readonly IObjectResolver _objectResolver;
		
		[Inject]
		public UIService(IObjectResolver objectResolver)
		{
			_objectResolver = objectResolver;
		}
		
		public async UniTask<T> LoadAsync<T>(string assetId)
		{
			return await Addressables.LoadAssetAsync<T>(assetId);
		}
		
		public async UniTask<GameObject> CreateAsync(string assetId, Transform parent = null)
		{
			GameObject instance = await Addressables.InstantiateAsync(assetId, parent);
			_objectResolver.InjectGameObject(instance);
			return instance;
		}

		public void Unload(GameObject gameObject)
		{
			Addressables.ReleaseInstance(gameObject);
		}
	}
}
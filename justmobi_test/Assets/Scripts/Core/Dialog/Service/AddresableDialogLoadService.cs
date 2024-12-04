using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace Core.Dialog.Service
{
	public class AddresableDialogLoadService : IDialogLoader
	{
		private readonly IObjectResolver _objectResolver;
		
		[Inject]
		private AddresableDialogLoadService(IObjectResolver objectResolver)
		{
			_objectResolver = objectResolver;
		}
		
		public async UniTask<GameObject> LoadDialogAsync(string dialogId,
		                                              GameObject container)
		{
			GameObject instance = await Addressables.InstantiateAsync(dialogId, container.transform);
			instance.name = dialogId;
			_objectResolver.InjectGameObject(instance);
			return instance;
		}

		public void Unload(GameObject dialogController)
		{
			Addressables.ReleaseInstance(dialogController);
		}
	}
}
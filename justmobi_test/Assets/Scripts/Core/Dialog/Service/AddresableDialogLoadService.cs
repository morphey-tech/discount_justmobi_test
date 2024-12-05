using Core.UI.Service;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Core.Dialog.Service
{
	public class AddresableDialogLoadService : IDialogLoader
	{
		private readonly UIService _uiService;
		
		[Inject]
		private AddresableDialogLoadService(UIService uiService)
		{
			_uiService = uiService;
		}
		
		public async UniTask<GameObject> LoadDialogAsync(string dialogId,
		                                              GameObject container)
		{
			GameObject instance = await _uiService.CreateAsync(dialogId, container.transform);
			instance.name = dialogId;
			return instance;
		}

		public void Unload(GameObject dialogController)
		{
			_uiService.Unload(dialogController);
		}
	}
}
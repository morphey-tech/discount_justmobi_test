using Core.Dialog.Controller;
using Core.Dialog.Service;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Core.Dialog.Manager
{
	public sealed class DialogManager
  {
    private readonly IDialogLoader _dialogLoader;
    private readonly GameObject _dialogContainer;

    [Inject]
    private DialogManager(IDialogLoader dialogLoader)
    {
      _dialogLoader = dialogLoader;
      _dialogContainer = GameObject.Find("Canvas");
    }

    public void ShowModal(string dialogId)
    {
      ShowModalAsync(dialogId).Forget();
    }

    public async UniTask<GameObject> ShowModalAsync(string dialogId)
    {
      UIDialogController uiDialogController = new(dialogId);
        GameObject instance =
            await _dialogLoader.LoadDialogAsync(dialogId, _dialogContainer);
        uiDialogController.SetDialog(instance);
        await uiDialogController.ShowAsync();
        return instance;
    }

    public GameObject DialogContainer => _dialogContainer;
  }
}
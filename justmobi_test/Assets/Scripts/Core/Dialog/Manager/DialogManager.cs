using System;
using System.Collections.Generic;
using Core.Dialog.Controller;
using Core.Dialog.Service;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Core.Dialog.Manager
{
  public sealed class DialogManager
  {
    private const string CONTAINER_NAME = "Canvas";
    
    private readonly IDialogLoader _dialogLoader;
    private readonly GameObject _dialogContainer;

    private readonly Stack<DialogController> _dialogStack = new();

    [Inject]
    private DialogManager(IDialogLoader dialogLoader)
    {
      _dialogLoader = dialogLoader;
      _dialogContainer = GameObject.Find(CONTAINER_NAME);
    }

    public void ShowModal(string dialogId, string offerId)
    {
      ShowModalAsync(dialogId, offerId).Forget();
    }

    public async UniTask<GameObject> ShowModalAsync(string dialogId, string offerId)
    {
      DialogController controller = new();
      GameObject instance =
          await _dialogLoader.LoadDialogAsync(dialogId, _dialogContainer);
      controller.SetDialog(instance);
      await controller.ShowAsync(offerId);
      _dialogStack.Push(controller);
      return instance;
    }

    public void Hide(GameObject dialog)
    {
      HideAsync(dialog).Forget();
    }
    
    public async UniTask HideAsync(GameObject dialog)
    {
      if (ReferenceEquals(dialog, null))
      {
        throw new ArgumentNullException(nameof(dialog), "Try to hide null dialog");
      }
      DialogController controller = _dialogStack.Pop();
      await controller.HideAsync();
      _dialogLoader.Unload(dialog);
    }
  }
}
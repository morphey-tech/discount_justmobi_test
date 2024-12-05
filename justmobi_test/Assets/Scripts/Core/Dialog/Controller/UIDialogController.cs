using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Core.Dialog.Controller
{
  public sealed class UIDialogController
  {
    public string DialogId { get; private set; }
    public IDialog? DialogInstance { get; private set; }

    public bool Opened { get; set; }
    public bool Hiding { get; set; }

    private DOTweenAnimation? _doTweenAnimation;

    public UIDialogController(string dialogId)
    {
      DialogId = dialogId;
    }

    public void SetDialog(GameObject dialogController)
    {
      DialogInstance = dialogController.GetComponent<IDialog>();
      _doTweenAnimation = dialogController.GetComponent<DOTweenAnimation>();
    }

    public async UniTask ShowAsync(params object[] initParam)
    {
      DialogInstance!.Configure(initParam);
      if (_doTweenAnimation == null) {
        DialogInstance!.Show();
        Opened = true;
      }
      else {
        _doTweenAnimation.DOPlayById("Open");
        await UniTask.WaitWhile(() => _doTweenAnimation.hasOnComplete);
        await UniTask.Yield();
        DialogInstance!.Show();
        Opened = true;
      }
    }

    public async UniTask HideAsync()
    {
      Hiding = true;
      if (_doTweenAnimation != null) {
        _doTweenAnimation.DOPlayById("Close");
        await UniTask.WaitWhile(() => _doTweenAnimation.hasOnComplete);
      }
      DialogInstance!.Hide();
      Opened = false;
    }
  }
}
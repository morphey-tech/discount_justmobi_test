using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Dialog.Controller
{
  public sealed class UIDialogController
  {
    public string DialogId { get; private set; }
    public GameObject? DialogController { get; private set; }

    public bool Opened { get; set; }
    public bool Hiding { get; set; }

    public UIDialogController(string dialogId)
    {
      DialogId = dialogId;
    }

    public void SetDialog(GameObject dialogController)
    {
      DialogController = dialogController;
    }

    public async UniTask ShowAsync()
    {
      /*if (DialogAnimator == null) {
        DialogController!.gameObject.SetActive(!Muted);
      }
      else {
        await DialogAnimator.PlayOpenAnimation();
        await UniTask.Yield();
        DialogController!.gameObject.SetActive(!Muted);
      }*/
      Opened = true;
    }

    public async UniTask HideAsync()
    {
      Hiding = true;
      /*if (DialogAnimator != null) {
        await DialogAnimator.PlayCloseAnimation();
      }*/
      DialogController!.gameObject.SetActive(false);
      Opened = false;
    }
  }
}
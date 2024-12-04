using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Dialog.Service
{
	public interface IDialogLoader
	{
		UniTask<GameObject> LoadDialogAsync(string dialogId,
		                                    GameObject container);

		void Unload(GameObject dialogController);
	}
}
using Cysharp.Threading.Tasks;

namespace Core.Dialog.Controller
{
	public interface IDialog
	{
		UniTask Configure(params object[] initParam);
		void Show();
		void Hide();
	}
}
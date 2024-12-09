using Cysharp.Threading.Tasks;

namespace Core.Dialog.Controller
{
	public interface IDialog
	{
		UniTask Configure(string offerId);
		void Show();
		void Hide();
	}
}
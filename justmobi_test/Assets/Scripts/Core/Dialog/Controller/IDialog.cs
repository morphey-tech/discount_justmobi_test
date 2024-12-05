using Cysharp.Threading.Tasks;

namespace Core.Dialog.Controller
{
	public interface IDialog
	{
		void Configure(params object[] initParam);
		void Show();
		void Hide();
	}
}
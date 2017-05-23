using Calculator.ViewModels.Base;
using System.Windows.Input;

using Xamarin.Forms;
namespace Calculator.ViewModels
{
    public class HistoricViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; }

        public HistoricViewModel()
        {
            CloseCommand = new Command(ExecuteClose);
        }

        void ExecuteClose()
        {
            Application.Current.MainPage.Navigation?.PopModalAsync();
        }
    }
}

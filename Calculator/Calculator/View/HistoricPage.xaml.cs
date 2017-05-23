using Calculator.ViewModels;

using Xamarin.Forms;

namespace Calculator.View
{
    public partial class HistoricPage : ContentPage
    {
        public HistoricPage()
        {
            InitializeComponent();
            BindingContext = new HistoricViewModel();
		}
    }
}

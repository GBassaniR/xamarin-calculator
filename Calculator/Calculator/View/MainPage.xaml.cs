using Calculator.ViewModels;

using Xamarin.Forms;

namespace Calculator.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
		}
    }
}

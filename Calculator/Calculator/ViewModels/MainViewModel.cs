using Xamarin.Forms;
using System.Windows.Input;
using Calculator.ViewModels.Base;
using Calculator.Service;
using Calculator.View;

namespace Calculator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region private fields
        string displayValue = "0";
        string tempDataForCalculation;
        string mathOperator;
        bool startCalculation;
        bool startNumber = true;
        #endregion

        public MainViewModel()
        {
            NumberComamnd = new Command<string>(ExecuteSelectNumber);
            OperatorCommand = new Command<string>(ExecuteSelectOperator);
            AddPointCommand = new Command(ExecuteAddPoint);
            BackspaceCommand = new Command(ExecuteBackspace);
            CleanCommand = new Command(ExecuteClean);
            CalculationCommand = new Command(ExecuteCalculate);
            PushCommand = new Command(ExecutePush);
        }

        public ICommand NumberComamnd { get; }
        public ICommand OperatorCommand { get; }
        public ICommand AddPointCommand { get; }
        public ICommand BackspaceCommand { get; }
        public ICommand CleanCommand { get; }
		public ICommand CalculationCommand { get; }
		public ICommand PushCommand { get; }

        public string DisplayValue
        {
            get { return displayValue; }
            set { SetProperty(ref displayValue, value); }
        }

        void ExecuteSelectNumber(string number)
        {
            if (mathOperator == null)
            {
                if (startNumber)
                {
                    DisplayValue = number;
                    if (number != "0")
                        startNumber = false;
                }
                else
                {
                    DisplayAlerts(DisplayValue.Length);
                    DisplayValue += number;
                }
            }
            else
            {
                if (startCalculation)
                {
                    tempDataForCalculation = DisplayValue;
                    DisplayValue = "";
                    startCalculation = false;
                }

                if (startNumber)
                {
                    DisplayValue = number;
                    startNumber = false;
                }
                else
                {
                    DisplayAlerts(DisplayValue.Length);
                    DisplayValue += number;
                }
            }
        }

        async void DisplayAlerts(int displayCount)
        {
            if (displayCount > 4)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Limite de números ultrapassados.", "Sim", "Não");
                DisplayValue = DisplayValue.Remove(DisplayValue.Length - 1);
            }
        }

        void ExecuteCalculate()
        {
            DisplayValue = MathOperations.Calculate(tempDataForCalculation, mathOperator, DisplayValue)
                .ToString();
            tempDataForCalculation = "";
            mathOperator = null;

        }

        void ExecuteSelectOperator(string selectedOperator)
        {
            mathOperator = selectedOperator;

            if (!string.IsNullOrEmpty(tempDataForCalculation))
            {
                DisplayValue = MathOperations.Calculate(tempDataForCalculation, mathOperator, DisplayValue)
                    .ToString();
                tempDataForCalculation = "";
                mathOperator = null;
            }

            startCalculation = true;
        }

        void ExecuteClean()
        {
            tempDataForCalculation = "";
            DisplayValue = "0";
            startNumber = true;
            mathOperator = null;
        }

        void ExecuteBackspace()
        {
            DisplayValue = DisplayValue.Remove(DisplayValue.Length - 1);
            if (string.IsNullOrEmpty(DisplayValue))
            {
                DisplayValue = "0";
                startNumber = true;
            }

        }

        void ExecuteAddPoint()
        {
            if (!string.IsNullOrEmpty(DisplayValue) && !FindPoint(DisplayValue))
            {
                DisplayValue += ".";
                startNumber = false;
            }
        }

        bool FindPoint(string field)
        {
            if (field.Contains("."))
                return true;
            return false;
        }

        async void ExecutePush()
        {
            await PushAsync<HistoricViewModel>();
        }
    }
}
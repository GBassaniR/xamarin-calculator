using Calculator.Models;

namespace Calculator.Service.Base
{
    public class Operation
    {
        private static TypeOperation? TypeOperation;

		public static TypeOperation SetsOperation(string operation)
        {
            if (operation == "+")
                TypeOperation = Models.TypeOperation.Sum;
			else if (operation == "-")
				TypeOperation = Models.TypeOperation.Subtraction;
			else if (operation == "x")
				TypeOperation = Models.TypeOperation.Multiplication;
			else
				TypeOperation = Models.TypeOperation.Division;

            return (TypeOperation)TypeOperation;   
        }
    }
}

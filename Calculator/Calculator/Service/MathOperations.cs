using Calculator.Service.Base;

namespace Calculator.Service
{
	public class MathOperations
	{
        public Operation Operation { get; }

		public static double Calculate(string dataForAction, string symbol, string currentData)
		{
			double firstData;
			double secondData;
			double.TryParse(dataForAction, out firstData);
			double.TryParse(currentData, out secondData);


            if (!string.IsNullOrWhiteSpace(symbol))
            {
                var operationSymbol = Operation.SetsOperation(symbol);

				switch (operationSymbol)
				{
                    case Models.TypeOperation.Division:
                        try
                        {
                            return firstData / secondData;
						}
                        catch
                        {
                            return 0;                            
                        }
                    case Models.TypeOperation.Multiplication:
						return firstData * secondData;
                    case Models.TypeOperation.Sum:
						return firstData + secondData;
                    case Models.TypeOperation.Subtraction:
						return firstData - secondData;
				}
			}
			return secondData;
		}
	}
}
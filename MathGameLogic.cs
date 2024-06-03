namespace .
{
    public class MathGameLogic
    {
        public List<string> GameHistory { get; set; } = new List<string>();

        public void ShowMenu()
        {
            System.Console.WriteLine("Please enter an option to select the operation you want to perform");
            System.Console.WriteLine( "1. Summation");
            System.Console.WriteLine("2. Subtraction");
            System.Console.WriteLine("3. Multiplication");
            System.Console.WriteLine("4. Division");
            System.Console.WriteLine("5. Random Mode");
            System.Console.WriteLine("6. Show History");
            System.Console.WriteLine("7. Change difficulty");
            System.Console.WriteLine("8. Exit");
        }
        public int MathOperation(int firstNumber, int secondNumber, char operation)
        {
            switch(operation)
            {
                case '+':
                    GameHistory.Add($"{firstNumber} + {secondNumber} = {firstNumber} + {secondNumber} ");
                    return firstNumber + secondNumber;
                case '-':
                    while(firstNumber < 0 || firstNumber > 100)
                    {
                        try
                        {
                            System.Console.WriteLine("Please enter a number between 0 and 100.");
                            firstNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (System.Exception)
                        {

                        }                   
                    }
                       GameHistory.Add($"{firstNumber} / {secondNumber} = {firstNumber} / {secondNumber} ");
                        return firstNumber / secondNumber;     
                case '*':
                    GameHistory.Add($"{firstNumber} * {secondNumber} = {firstNumber} * {secondNumber} ");
                    return firstNumber * secondNumber;
                case '/':
                    GameHistory.Add($"{firstNumber} / {secondNumber} = {firstNumber} / {secondNumber} ");
                    return firstNumber / secondNumber;
            }
            return 0;
        }
    }
}
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using MathGame;
/**
 1. You need to create a Math game containing the 4 basic operations
 2. The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
 3. Users should be presented with a menu to choose an operation
 4. You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
 5. You don't need to record results on a database. Once the program is closed the results will be deleted.
 **/


MathGameLogic mathGame = new MathGameLogic();
Random random = new Random();

int firstNumber;
int secondNumber;
int userMenuSelection;
int score = 0;
bool gameOver = false;





static difficultyLevel ChangeDifficultyLevel()
{
    int userSelection = 0;

    System.Console.WriteLine("Please enter a difficulty level");
    System.Console.WriteLine("1. Easy");
    System.Console.WriteLine("2. Medium");
    System.Console.WriteLine("3. Hard");

    while(!int.TryParse(Console.ReadLine(), out userSelection) || (userSelection < 1 || userSelection > 3)) 
    {
        System.Console.WriteLine("Please enter a valid option 1, 2 or 3");
    }
    switch(userSelection)
    {
        case 1:
            return difficultyLevel.easy;
        case 2:
            return difficultyLevel.Medium;
        case 3:
            return difficultyLevel.Hard;
    }

    return difficultyLevel.easy;
}

public enum difficultyLevel
{
    easy = 45, 
    Medium = 30,
    Hard = 15
}

static void DisplayMathGameQuestion(int firstNumber, int secondNumber, char operation)
{
    System.Console.WriteLine($"{firstNumber} {operation} {secondNumber} = ??");
}

static int GetUserMenuSelection(MathGameLogic mathGame)
{
    int selection = -1;
    mathGame.ShowMenu();
    while(selection < 1 || selection > 8)
    {
        while(!int.TryParse(Console.ReadLine(), out selection))
        {
            System.Console.WriteLine("Please enter a valid option between 1-8");
        }
        if(!(selection < 1 && selection > 8))
        {
            System.Console.WriteLine("Please enter a valid option between 1-8");
        }
    }
    return selection;
}

static async Task<int?> GetUserResponse(difficultyLevel difficulty)
{
    int response = 0;
    int timeout = (int)difficulty;

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    Task<string?> getUserInputTask = Task.Run(() => Console.ReadLine()) ;
    try
    {
        string? result = await Task.WhenAny(getUserInputTask, Task.Delay(timeout * 1000)) == getUserInputTask ? getUserInputTask.Result : null;

        stopwatch.Stop();

        if(result != null && int.TryParse(result, out response)) 
        {
            System.Console.WriteLine($"Time taken to answer: {stopwatch.Elapsed.ToString(@"m\::ss\.fff")}");
            return response;
        }
        else
        {
            throw new OperationCanceledException();
        }
    }
    catch(OperationCanceledException)
    {
        System.Console.WriteLine("Time is up!");
        return null;
    }
    }
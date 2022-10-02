// See https://aka.ms/new-console-template for more information

// MAIN
using System;
bool exitApp = false;
bool validUser = false;
string response = "";
string validLogin;
while (!exitApp)
{
    if (!validUser)
    {
        response = Expenses.Login();
        switch (response)
        {
            case "x": //user has opted to exit the program
                exitApp = true;
                break;
            case "z"://user has entered an invalid response
            case "r"://user registered and now needs to login
            case "f"://user forgot password and now needs to login
                continue;
                break;
            default: //user has successfully logged in, or has registered. the return value is the user's userId from the database
                validUser = true;
                break;
        }
    }
    else
    {
        validLogin = Expenses.Employee("Paul", "1");
        if (validLogin == "r" || validLogin == "s" || validLogin == "p")
        {
            continue;
        }
        else if (validLogin == "x")
        {
            exitApp = true;
        }
        else
        {
            Console.WriteLine("Invalid Entry");
            Console.WriteLine("");
        }
    }
    
}
public class Expenses
{
    
    public static string Login()
    {
        //Every response in Login needs to go back to Main
        string ans;
        string? userName;
        string? passWord;
        string valid;
        Console.WriteLine("");
        Console.WriteLine("                   Expense Report");
        Console.WriteLine(" -------------------------------------------------- ");
        Console.WriteLine("| " + "Login(l) Register(r) Forgot Password(f) Exit(x) |");
        Console.WriteLine(" -------------------------------------------------- ");
        ans = Console.ReadLine();
        switch (ans)
        {
            case "l":
                Console.WriteLine("");
                Console.WriteLine("Enter Username");
                userName = Console.ReadLine();
                //check database for valid username
                Console.WriteLine("");
                Console.WriteLine("Enter Password");
                passWord = Console.ReadLine();
                //check database for valid password
                Console.WriteLine("");
                Console.WriteLine("Credentials verified");
                valid = "userId";
                return valid; //need to return user ID pulled from database
                break;
            case "r":
                //user will be sent to registration class, and will then need to login
                return "r"; //the user will see the login menu after registration
                break;
            case "f":

                return "f";
                break;
            case "x":
                Console.WriteLine("Exit Program");
                return "x";
                break;
            default:
                Console.WriteLine("Invalid entry. Try again");
                return "z";
                break;
        }

    }
    public static string Employee(string firstName, string userId)
    {
        string ans;
        Console.WriteLine("Hello " + firstName + userId);
        Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
        Console.WriteLine("| " + "Submit new Expense Report(r) View all past submissions(s) View only pending submissions(p) Exit(x) |");
        Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
        ans = Console.ReadLine();
        switch (ans)
        {
            case "r":
                return "r"; //user has submitted a new report and will be brought back to employee class
                break;
            case "s":
                return "r"; //user has viewed past submissions and will be brought back to employee class
                break;
            case "p":
                return "r"; //user has viewed any pending submissinos and will be brought back to employee class
                break;
            case "x":
                return "x";
                break;
            default:
                return "z";
                break;
        }
    }
}
    

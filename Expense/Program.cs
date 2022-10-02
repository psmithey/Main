// See https://aka.ms/new-console-template for more information

// MAIN
using System;
bool exitApp = false;
string response = "";
string validLogin;
while (!exitApp)
{
    response = Expenses.Login();
    switch (response)
    {
        case "x": //user has opted to exit the program
            exitApp = true;
            break;
        case "z": //user has entered an invalid response
            continue;
            break;
        default: //user has successfully logged in, or has registered. the return value is the user's userId from the database
            validLogin = Expenses.Employee("Paul", "1"); //Paul and 1 is temporary to get the code to work. this will be the response from a valid login or registration
            if(validLogin == "z")
            {
                Console.WriteLine("");
                Console.WriteLine("You have entered an invalid response");               
                Console.WriteLine("You must login again if another invalid respose is entered");
                Console.WriteLine("");
                validLogin = Expenses.Employee("Paul", "1");
            }
            else if(validLogin == "x")
            {
                exitApp = true;
            }
            break;
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

                return "";
                break;
            case "f":

                return "";
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
                return "";
                break;
            case "s":
                return "";
                break;
            case "p":
                return "";
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
    

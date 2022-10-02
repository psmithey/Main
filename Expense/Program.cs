// See https://aka.ms/new-console-template for more information

// MAIN
using System;
bool exitApp = false;
string response = "";
while (!exitApp)
{
    response = Expenses.Login();
    switch (response)
    {
        case "x":
            exitApp = true;
            break;
        case "z":
            continue;
            break;
        default:
            exitApp = true;
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
        Console.WriteLine("");
        Console.WriteLine("                   Expense Report");
        Console.WriteLine(" -------------------------------------------------- ");
        Console.WriteLine("| " + "Login(l) Register(r) Forgot Password(f) Exit(x) |");
        Console.WriteLine(" -------------------------------------------------- ");
        ans = Console.ReadLine();
        switch (ans)
        {
            case "l":
                Console.WriteLine("Enter Username");
                userName = Console.ReadLine();
                //check database for valid username
                Console.WriteLine("Enter Password");
                passWord = Console.ReadLine();
                //check database for valid password
                Console.WriteLine("Credentials verified");
                return "";
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
}
    

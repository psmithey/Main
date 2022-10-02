﻿// See https://aka.ms/new-console-template for more information

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
                Console.Clear();
                Console.WriteLine("Exit Program");
                exitApp = true;
                break;
            case "z"://user has entered an invalid response
            case "r"://user registered and now needs to login
            case "f"://user forgot password and now needs to login
                continue;
                break;
            default: //user has successfully logged in, or has registered. the return value is the user's userId from the database
                //it will also be determined the user type during login. admin, manager, or employee
                validUser = true;
                break;
        }
    }
    else
    { //there will be an if statement here once it's determined the user type to choose which class to call. admin, manager, or employee
        validLogin = Expenses.Employee("Paul", "1");
        if (validLogin == "r" || validLogin == "s" || validLogin == "p")
        {
            continue;
        }
        else if (validLogin == "x")
        {
            Console.Clear();
            Console.WriteLine("Exit Program");
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
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Enter Username");
                userName = Console.ReadLine();
                //check database for valid username
                Console.WriteLine("");
                Console.WriteLine("Enter Password");
                passWord = Console.ReadLine();
                //check database for valid password
                Console.WriteLine("");
                Console.Clear();
                Console.WriteLine("Credentials verified");
                valid = "userId";
                return valid; //need to return user ID pulled from database
                break;
            case "r":
                Console.Clear();
                //user will be sent to registration class, and will then need to login
                return "r"; //the user will see the login menu after registration
                break;
            case "f":
                Console.Clear();
                return "f";
                break;
            case "x":
                return "x";
                break;
            default:
                Console.Clear();
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
                Console.Clear();
                return "r"; //user has submitted a new report and will be brought back to employee class
                break;
            case "s":
                Console.Clear();
                return "r"; //user has viewed past submissions and will be brought back to employee class
                break;
            case "p":
                Console.Clear();
                return "r"; //user has viewed any pending submissinos and will be brought back to employee class
                break;
            case "x":
                return "x";
                break;
            default:
                Console.Clear();
                return "z";
                break;
        }
    }
}
    

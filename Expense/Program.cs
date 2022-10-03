// See https://aka.ms/new-console-template for more information

// MAIN
using Microsoft.Data.SqlClient;
using ExpenseClassLibrary;
bool exitApp = false;
bool validUser = false;
string response = "";
string validLogin;

Expenses exp = new Expenses();


while (!exitApp)
{
    if (!validUser)
    {
       
        response = Login.LoginMenu();        
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
        
        string[] words = response.Split(' ');
        exp.setFirstName(words[0]);
        exp.setUserId(words[1]);
        validLogin = Expenses.Employee(exp.getFirstName(), exp.getUserId());
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

public class Login
{
    public static string LoginMenu()
    {
        //Every response in Login needs to go back to Main
        string ans;

        string temp;

        string? userName;
        string? passWord;
        string valid;
        //TestClass tc = new TestClass();
        //tc.PrintSomething("test");
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

                temp = Expenses.ConnectToDatabase();

                Console.WriteLine("");
                Console.WriteLine("Enter Password");
                passWord = Console.ReadLine();

                //check database for valid password

                Console.WriteLine("");
                Console.Clear();
                Console.WriteLine("Credentials verified");
                Console.WriteLine("");

                valid = "Paul UserId"; //these values will be returned from a database querry

                return valid; //need to return first name and user ID pulled from database
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
}

public class Expenses
{
    private string firstName;
    private string userId;

    public string getFirstName()
    {
        return this.firstName;
    }
    public void setFirstName(string value)
    {
        this.firstName = value;
    }
    public string getUserId()
    {
        return this.userId;
    }
    public void setUserId(string value)
    {
        this.userId = value;
    }

    public static string Employee(string fname, string uId)
    {
        
        string ans;
        string returnVal;
        Console.WriteLine("User: " + fname);
        Console.WriteLine("                                        Employee Menu");
        Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
        Console.WriteLine("| " + "Submit new Expense Report(r) View all past submissions(s) View only pending submissions(p) Exit(x) |");
        Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
        ans = Console.ReadLine();
        switch (ans)
        {
            case "r":
                Console.Clear();
                //returnVal = NewExpenseReport(uId);
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
            case "x": //user wishes to exit the program
                return "x";
                break;
            default: //there has been an ivalid key stroke/bad entry
                Console.Clear();
                return "z";
                break;
        }
    }
    //public static string NewExpenseReport(string uId)
    //{

    //}
    public static string ConnectToDatabase()
    {
        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        conn.Open();

        Console.WriteLine("got past connection");
        return "foo";

    }
}   


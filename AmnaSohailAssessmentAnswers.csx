using System;
using System.Collections.Generic;
using System.Text;

//Part One

// 1 - Declare and initialize five different types
int yearsLivedInIndiana = 13;
bool isTrue = true;
string familyName = "Sohail family";
double dbl = 0.6;
decimal s = 0.6m;

//2 - Write function to combine two variables from 1 into a string.

string BuildMessage(string familyName, int yearsLivedInIndiana)
{
    return $"The length of time the {familyName} has lived in Indiana is {yearsLivedInIndiana} years.";
}

//3 Print string to console.

var message = BuildMessage(familyName, yearsLivedInIndiana);
Console.WriteLine(message);




// 4 - Create array of strings  with 3-5 names.
var names =
    new[]
    {
       "Nausheen",
       "Ahsan",
       "Haris",
       "Zain"
    };

// 5 - Loop over array and print to console.
foreach (var name in names) Console.WriteLine(name);


// Part Two - OOP

// 1 - Create customer class with three properties & Gender Enum.


public enum Gender
{
    Unknown,
    Male,
    Female
}


public class Customer
{
    // 2 - Customer Class Constructor
    public Customer(string name, Gender gender, string product)
    {
        Name = name;
        Gender = gender;
        Product = product;
    }

    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Product { get; set; }

    // 3 - Method in Customer Class to Thank Customer
    public void SayThankYou()
    {
        Console.WriteLine($"Hello {Name}, thank you for purchasing the {Product}. We hope you enjoy it!");
    }

    // 4 - Send Sale Notice Method
    public void SendSaleNotice(DateTime saleDate)
    {
        Console.WriteLine($"Hello {Name}, We wanted to let you know there's a sale coming up on {saleDate:yyyy-MM-dd}");
    }

    public void SendSaleNotice(string product, DateTime saleDate)
    {
        Console.WriteLine($"Hello {Name}, We wanted to let you know there's a sale on {product} coming up on {saleDate:yyyy-MM-dd}");
    }

    // 9 - Overridable method - PrintCustomerInfo
    public virtual void PrintCustomerInfo()
    {
        Console.WriteLine($"{Name} - {Gender} - {Product}");
    }
}

// 5 - InactiveCustomer Sealed Class
public sealed class InactiveCustomer
    : Customer
{
    // 10 - Enum - Reasons Customer May Not Purchase
    public enum InactiveReason
    {
        Irate,
        Moved,
        Uninterested
    }

    // 6 - Add Constructor with Months Inactive parameter
    public InactiveCustomer(string name, Gender gender, string product, int monthsInactive)
        : base(name, gender, product)
    {
        MonthsInactive = monthsInactive;
    }

    public int MonthsInactive { get; set; }

    // 11 - Add property to inactive customer class - NOT SURE ABOUT THIS PART
   //public InactiveReason - Not sure if this is going along the right track.....

    // 7 - Sending Message to Inactive Customer
    public void SendInactiveCustomerMessage()
    {
        var message =
            new StringBuilder($"Thanks for shopping with us, {Name}. ")
                .Append($"We saw that you purchased a {Product} from us {MonthsInactive} months ago. ")
                .Append("We'd like to know if you'd like to take a look at some of our current deals.")
                .ToString();
        Console.WriteLine(message);
    }

    // 12 - Print Customer Info Overide Method
    public override void PrintCustomerInfo()
    {
        Console.WriteLine($"{Name} - {Gender} - {Product} - {Reason}");
    }
}

// 8 - Create Instances of Classes & Test Methods
var customer = new Customer("Amna", Gender.Female, "iPhone 6");
customer.SayThankYou();
customer.SendSaleNotice(DateTime.Parse("2016-07-15"));
customer.SendSaleNotice("Pokemon Game", DateTime.Parse("2016-07-15"));
customer.PrintCustomerInfo();

var inactiveCustomer =
    new InactiveCustomer("Adam", Gender.Male, "movie", 5)
    {
        Reason = InactiveCustomer.InactiveReason.Irate
    };
inactiveCustomer.SayThankYou();
inactiveCustomer.PrintCustomerInfo();
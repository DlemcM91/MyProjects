using System;
using System.Collections.Generic;

public class Meter {
    public string MeterNumber { get; set; }
    public double Balance { get; set; }

    public Meter(string meterNumber, double balance) {
        MeterNumber = meterNumber;
        Balance = balance;
    }

    public void LoadToken(double amount) {
        Balance += amount;
        Console.WriteLine($"Token loaded successfully. New balance for meter {MeterNumber} is R {Balance:F2}");
    }
}

public class TokenLoader {
    private Dictionary<string, Meter> meters = new Dictionary<string, Meter>();

    public void AddMeter(string meterNumber, double initialBalance) {
        meters[meterNumber] = new Meter(meterNumber, initialBalance);
    }

    public void LoadToken(string meterNumber, double amount) {
        if (meters.ContainsKey(meterNumber)) {
            meters[meterNumber].LoadToken(amount);
        } else {
            Console.WriteLine("Meter not found.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TokenLoader loader = new TokenLoader();
        loader.AddMeter("M12345", 0.0); // Sample meter

        Console.Write("Enter meter number: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string meterNumber = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        Console.Write("Enter token amount: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string inputAmount = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        if (double.TryParse(inputAmount, out double amount) && amount > 0)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            loader.LoadToken(meterNumber, amount);
#pragma warning restore CS8604 // Possible null reference argument.
        }
        else
        {
            Console.WriteLine("Invalid token amount.");
        }
    }
    
}

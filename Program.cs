/*
* ITELEC2 Prelim Activity 01: Codac Logistics Delivery & Fuel Auditor
* Name: Bitara, Peter John P.
* Description:
* It is a C# program in a console, which monitors the monthly fuel costs of a delivery driver, weekly. 
* verifies the amount of distance covered, computes fuel efficiency scores, 
* and establishes whether the driver was operating within the weekly budgeted amount.
*
* Concepts Used:
* - Data Types: string, double, decimal, bool
* - Console Input/Output
* - Input Validation using while loop
* - 1D Array
* - for loop
* - if/else statements
*/

using System;

using System.Text; // Needed for UTF-8 encoding

class CodacLogisticsAuditor
{
    static void Main()
    {
        // Fix console encoding to support ₱ symbol
        Console.OutputEncoding = Encoding.UTF8;

        // TASK 1: DRIVER PROFILE INPUT

        Console.Write("Enter Driver's Full Name: ");
        string driverName = Console.ReadLine();

        Console.Write("Enter Weekly Fuel Budget: ");
        decimal weeklyBudget = decimal.Parse(Console.ReadLine());

        double totalDistance = 0;

        // Distance validation using while loop
        while (true)
        {
            Console.Write("Enter Total Distance Traveled this Week (1 - 5000 km): ");
            totalDistance = double.Parse(Console.ReadLine());

            if (totalDistance >= 1.0 && totalDistance <= 5000.0)
                break;
            else
                Console.WriteLine("Invalid input. Distance must be between 1 and 5000 km.");
        }

        // TASK 2: FUEL EXPENSE TRACKING

        decimal[] fuelExpenses = new decimal[5];
        decimal totalFuelSpent = 0;

        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            Console.Write($"Enter fuel expense for Day {i + 1}: ");
            fuelExpenses[i] = decimal.Parse(Console.ReadLine());
            totalFuelSpent += fuelExpenses[i];
        }


        // TASK 3: PERFORMANCE ANALYSIS


        decimal averageDailyExpense = totalFuelSpent / fuelExpenses.Length;

        double efficiency = 0;
        if (totalFuelSpent != 0)
            efficiency = (double)totalDistance / (double)totalFuelSpent;

        string efficiencyRating;

        if (efficiency > 15)
            efficiencyRating = "High Efficiency";
        else if (efficiency >= 10)
            efficiencyRating = "Standard Efficiency";
        else
            efficiencyRating = "Low Efficiency / Maintenance Required";

        bool isUnderBudget = totalFuelSpent <= weeklyBudget;

        // TASK 4: AUDIT REPORT

        Console.WriteLine("\n========== CODAC LOGISTICS AUDIT REPORT ==========");
        Console.WriteLine($"Driver Name: {driverName}");

        Console.WriteLine("\n--- 5 Day Fuel Breakdown ---");
        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            Console.WriteLine($"Day {i + 1}: \u20B1{fuelExpenses[i]:N2}");
        }

        Console.WriteLine("\n--- Financial Summary ---");
        Console.WriteLine($"Total Fuel Spent: \u20B1{totalFuelSpent:N2}");
        Console.WriteLine($"Average Daily Expense: \u20B1{averageDailyExpense:N2}");
        Console.WriteLine($"Fuel Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Stayed Under Budget: {isUnderBudget}");

        Console.WriteLine("==================================================");
    }
}
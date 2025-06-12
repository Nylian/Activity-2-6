using System;
using System.Collections.Generic;
using System.IO;

namespace PersonalBudgetTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            BudgetTracker tracker = new BudgetTracker();
            string filePath = "transactions.txt";

            while (true)
            {
                Console.WriteLine("\n==== Personal Budget Tracker ====");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. Show Summary");
                Console.WriteLine("3. Show Category-wise Expenses");
                Console.WriteLine("4. Sort Transactions");
                Console.WriteLine("5. Show Visual Analytics");
                Console.WriteLine("6. Save Transactions");
                Console.WriteLine("7. Load Transactions");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Description: ");
                            string desc = Console.ReadLine();
                            Console.Write("Amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.Write("Type (Income/Expense): ");
                            string type = Console.ReadLine();
                            Console.Write("Category: ");
                            string category = Console.ReadLine();
                            Console.Write("Date (yyyy-mm-dd): ");
                            DateTime date = DateTime.Parse(Console.ReadLine());

                            tracker.AddTransaction(new Transaction(desc, amount, type, category, date));
                            break;

                        case "2":
                            tracker.ShowSummary();
                            break;

                        case "3":
                            tracker.ShowCategoryExpenses();
                            break;

                        case "4":
                            Console.Write("Sort by (date/category/amount): ");
                            string sortBy = Console.ReadLine();
                            tracker.SortTransactions(sortBy);
                            break;

                        case "5":
                            tracker.ShowVisualAnalytics();
                            break;

                        case "6":
                            tracker.SaveToFile(filePath);
                            Console.WriteLine("Transactions saved.");
                            break;

                        case "7":
                            tracker.LoadFromFile(filePath);
                            Console.WriteLine("Transactions loaded.");
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }

    class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Income" or "Expense"
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string description, decimal amount, string type, string category, DateTime date)
        {
            Description = description;
            Amount = amount;
            Type = type;
            Category = category;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} | {Type} | {Category} | {Description} : ${Amount}";
        }
    }

    class BudgetTracker
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction t)
        {
            transactions.Add(t);
        }

        public void ShowSummary()
        {
            decimal totalIncome = 0;
            decimal totalExpenses = 0;

            foreach (var t in transactions)
            {
                if (t.Type.ToLower() == "income")
                    totalIncome += t.Amount;
                else if (t.Type.ToLower() == "expense")
                    totalExpenses += t.Amount;
            }

            decimal netSavings = totalIncome - totalExpenses;

            Console.WriteLine("------ Summary ------");
            Console.WriteLine("Total Income: $" + totalIncome);
            Console.WriteLine("Total Expenses: $" + totalExpenses);
            Console.WriteLine("Net Savings: $" + netSavings);
        }

        public void ShowCategoryExpenses()
        {
            Dictionary<string, decimal> categoryTotals = new Dictionary<string, decimal>();

            foreach (var t in transactions)
            {
                if (t.Type.ToLower() == "expense")
                {
                    if (!categoryTotals.ContainsKey(t.Category))
                        categoryTotals[t.Category] = 0;

                    categoryTotals[t.Category] += t.Amount;
                }
            }

            Console.WriteLine("------ Category-wise Expenses ------");
            foreach (var pair in categoryTotals)
            {
                Console.WriteLine($"{pair.Key}: ${pair.Value}");
            }
        }

        public void SortTransactions(string sortBy)
        {
            Console.WriteLine("------ Sorted Transactions ------");
            List<Transaction> sorted = new List<Transaction>(transactions);

            switch (sortBy.ToLower())
            {
                case "date":
                    sorted.Sort((a, b) => a.Date.CompareTo(b.Date));
                    break;
                case "category":
                    sorted.Sort((a, b) => a.Category.CompareTo(b.Category));
                    break;
                case "amount":
                    sorted.Sort((a, b) => b.Amount.CompareTo(a.Amount));
                    break;
                default:
                    Console.WriteLine("Invalid sort type.");
                    return;
            }

            foreach (var t in sorted)
            {
                Console.WriteLine(t);
            }
        }

        public void ShowVisualAnalytics()
        {
            Dictionary<string, decimal> categoryTotals = new Dictionary<string, decimal>();

            foreach (var t in transactions)
            {
                if (t.Type.ToLower() == "expense")
                {
                    if (!categoryTotals.ContainsKey(t.Category))
                        categoryTotals[t.Category] = 0;

                    categoryTotals[t.Category] += t.Amount;
                }
            }

            Console.WriteLine("------ Visual Analytics ------");
            foreach (var pair in categoryTotals)
            {
                Console.Write($"{pair.Key.PadRight(15)}: ");
                int barLength = (int)(pair.Value / 10);
                Console.WriteLine(new string('*', barLength));
            }
        }

        public void SaveToFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var t in transactions)
                {
                    sw.WriteLine($"{t.Description}|{t.Amount}|{t.Type}|{t.Category}|{t.Date}");
                }
            }
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 5)
                {
                    string desc = parts[0];
                    decimal amount = decimal.Parse(parts[1]);
                    string type = parts[2];
                    string category = parts[3];
                    DateTime date = DateTime.Parse(parts[4]);

                    transactions.Add(new Transaction(desc, amount, type, category, date));
                }
            }
        }
    }
}
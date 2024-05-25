using System.Text.Json;
using Task1_Solution.Enums;
using Task1_Solution.Models;
using static Task1_Solution.InputHelpers;

namespace Task1_Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = CheckStringInput("path to the file");

            var data = LoadDataToMemory(jsonPath);

            while (true)
            {
                DisplayMenu(data);
            }
        }

        public static void DisplayMenu(List<Loan> loans)
        {
            var input = "";
            string text = "\nTo perform a certain action, enter the respective letter:" +
                "\r\nSearch for loan by the borrower's last name - n" +
                "\r\nCalculate the annuity payment by loan Id - a" +
                "\r\nDisplay the list of borrowers - b" +
                "\r\nFilter the loans by category - f" +
                "\r\nDisplay the list of banks - i" +
                "\r\nDisplay the list of loans - l" +
                "\r\nCreate new loan - c" +
                "\r\nExit - x";
            string[] commands = { "n", "a", "b", "f", "i", "l", "c", "x" };
            do
            {
                Console.WriteLine(text);
                input = Console.ReadLine().Trim();
            }
            while (input == string.Empty || !commands.Contains(input));

            switch (input)
            {
                case "n":
                    Menu.DisplayByBorrowerLastName(loans);
                    break;
                case "a":
                    Menu.CalculateAnnuityPayment(loans);
                    break;
                case "f":
                    Menu.DisplayByCategories(loans);
                    break;
                case "b":
                    Menu.DisplayBorrowers(loans);
                    break;
                case "i":
                    Menu.DisplayBanks(loans);
                    break;
                case "l":
                    Menu.DisplayLoans(loans);
                    break;
                case "c":
                    Menu.CreateLoan(loans);
                    break;
                case "x":
                    Environment.Exit(0);
                    break;
            }

        }

        public static List<Loan> LoadDataToMemory(string jsonPath)
        {
            try
            {
                using StreamReader reader = new(jsonPath);
                var json = reader.ReadToEnd();

                List<Loan> data = JsonSerializer.Deserialize<List<Loan>>(json);

                foreach (var loan in data)
                {
                    if (loan.CarModel != null)
                        loan.LoanType = LoanType.CarLoan;

                    if (loan.UniversityAddress != null)
                        loan.LoanType = LoanType.StudentLoan;

                    if (loan.AddressOfObject != null)
                        loan.LoanType = LoanType.Mortgage;
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file contents. Make sure the path to file is valid. {ex.Message}");
                throw;
            }
            
        }
        
    }
}
using Task1_Solution.Enums;
using Task1_Solution.Models;

namespace Task1_Solution
{
    /// <summary>
    /// Class containing the extension methods to handle the validation of the user input.
    /// </summary>
    public static class InputHelpers
    {
        public static string CheckDateInput()
        {
            string input;
            bool isDate;
            do
            {
                Console.Write($"Please enter the date in the format dd/MM/yyyy: ");
                input = Console.ReadLine().Trim();
                isDate = DateOnly.TryParse(input, out DateOnly date);
            }
            while (input == string.Empty || !isDate);
            return input;
        }

        public static string CheckStringInput(string inputType)
        {
            string input = "";
            do
            {
                Console.Write($"Please enter the {inputType}: ");
                input = Console.ReadLine().Trim();
            }
            while (input == string.Empty);
            return input;
        }
        public static float CheckNumInput(string numType)
        {
            var amount = "";
            float amountNumber;
            var isAmountNum = false;
            do
            {
                Console.Write($"Enter {numType} : ");
                amount = Console.ReadLine().Trim();
                isAmountNum = float.TryParse(amount, out amountNumber);
            }
            while (amount == string.Empty || !isAmountNum);

            return amountNumber;
        }

        public static int CheckIntInput(string numType)
        {
            var amount = "";
            int amountNumber;
            var isAmountNum = false;
            do
            {
                Console.Write($"Enter {numType}: ");
                amount = Console.ReadLine().Trim();
                isAmountNum = Int32.TryParse(amount, out amountNumber);
            }
            while (amount == string.Empty || !isAmountNum);
            return amountNumber;
        }

        public static int CheckIdInput(List<Loan> loans, IdType idType)
        {
            var id = "";
            var exists = false;
            var isNumber = false;
            int idNumber;

            do
            {
                Console.Write($"Enter {idType} Id number: ");
                id = Console.ReadLine().Trim();
                isNumber = Int32.TryParse(id, out idNumber);
                if (isNumber)
                {
                    foreach (var loan in loans)
                    {
                        if (idType == IdType.Loan)
                        {
                            if (loan.Id == idNumber)
                            {
                                exists = true;
                                Console.WriteLine("xx The loan with this Id already exists. Please enter a new one.");
                                break;
                            }
                        }
                        else if (idType == IdType.Bank)
                        {
                            if (loan.Bank.Id == idNumber)
                            {
                                exists = true;
                                Console.WriteLine("xx The bank with this Id already exists. Please enter a new one.");
                                break;
                            }
                        }
                        else if (idType == IdType.Borrower)
                        {
                            if (loan.Borrower.Id == idNumber)
                            {
                                exists = true;
                                Console.WriteLine("xx The borrower with this Id already exists. Please enter a new one.");
                                break;
                            }
                        }

                        break;
                        

                    }
                }
            }
            while (id == string.Empty || !isNumber || exists);

            return idNumber;
        }

        public static LoanType CheckCategory()
        {
            string category = "";
            string[] controlInput = { "0", "1", "2" };
            do
            {
                Console.WriteLine($@"Please choose the category of the loan: 
        for Car loans - enter 0
        for Mortgages - enter 1
        for Student loans - enter 2");
                category = Console.ReadLine().Trim();

            }
            while (category == string.Empty || !controlInput.Contains(category));

            var categoryEnum = (LoanType)Convert.ToInt16(category);

            return categoryEnum;
        }
    }
}

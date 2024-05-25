using Task1_Solution.Enums;
using Task1_Solution.Models;
using static Task1_Solution.InputHelpers;

namespace Task1_Solution
{
    /// <summary>
    /// The class that contains the business logic of the application along with the methods to react to the user controls.
    /// </summary>
    internal class Menu
    {

        //7
        public static void CalculateAnnuityPayment(List<Loan> loans)
        {
            Loan loan;
            var loanId = CheckIntInput("loan Id for annuity payment");
            loan = loans.FirstOrDefault(x => x.Id == loanId);

            while (loan == null)
            {
                Console.WriteLine("\n xx No loan with this Id was found.");
                break;
            }
            
            if (loan != null)
            {
                var monthlyInterestRate = loan.Percent / 1200;
                
                var coefficient = (monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), loan.CountOfMonth))/(Math.Pow((1 + monthlyInterestRate), loan.CountOfMonth) - 1);

                var annuityPayment = loan.Amount * coefficient;
                Console.WriteLine($"\n--->The annuity payment for this loan is equal to {annuityPayment.ToString("F2")}.");
            }


        }

        //6
        public static void DisplayByBorrowerLastName(List<Loan> loans)
        {
            string lastName = CheckStringInput("borrower's last name to search");

            Console.WriteLine("\n----ID----|--Amount--|--Percent--|--Months--|--LoanType--|---BankName---|---Borrower---|");
            loans.Where(x => x.Borrower.LastName == lastName)
                .ToList()
                .ForEach(loan => DisplayLoanDetails(loan));
        }
        //5
        public static void CreateLoan(List<Loan> loans)
        {
            var loanId = CheckIdInput(loans, IdType.Loan);
            var amount = CheckIntInput("amount");
            var percent = CheckNumInput("percent");
            var months = CheckIntInput("months");
            var bankId = CheckIdInput(loans, IdType.Bank);
            var bankName = CheckStringInput("bank name");
            var bankAddress = CheckStringInput("bank address");
            var borrowerId = CheckIdInput(loans, IdType.Borrower); ;
            var borrowerFirstName = CheckStringInput("borrower's first name");
            var borrowerLastName = CheckStringInput("borrower's last name"); ;
            var borrowerBirthDate = CheckDateInput();
            var borrowerPassportNumber = CheckStringInput("borrower's passport number");
            LoanType loanType = CheckCategory();

            string? carModel = null;
            string? carBrand = null;
            string? vin = null;

            string? universityName = null;
            string? universityAddress = null;

            float? square = null;
            string? objectAddress = null;
            if (loanType == LoanType.CarLoan)
            {
                carModel = CheckStringInput("car model");
                carBrand = CheckStringInput("car brand"); ;
                vin = CheckStringInput("car VIN"); ;
            }
            else if (loanType == LoanType.StudentLoan)
            {
                universityName = CheckStringInput("university name");
                universityAddress = CheckStringInput("university address");
            }
            else
            {
                square = CheckNumInput("square");
                objectAddress = CheckStringInput("address of the object");
            }

            Loan newLoan = new Loan()
            {
                Id = loanId,
                Amount = amount,
                CountOfMonth = months,
                Percent = percent,
                Bank = new Bank()
                {
                    Id = bankId,
                    Name = bankName,
                    Address = bankAddress
                },
                Borrower = new Borrower()
                {
                    Id = borrowerId,
                    FirstName = borrowerFirstName,
                    LastName = borrowerLastName,
                    DateOfBirth = borrowerBirthDate,
                    PassportNumber = borrowerPassportNumber
                },
                LoanType = loanType,
                CarModel = carModel,
                CarBrand = carBrand,
                VIN = vin,
                Square = square,
                AddressOfObject = objectAddress,
                UniversityAddress = universityAddress,
                UniversityName = universityName
            };

            loans.Add(newLoan);
            Console.WriteLine("\n--->New loan has been created. View the list of all loans.");
            DisplayLoans(loans);
        }

        //4
        public static void DisplayByCategories(List<Loan> loans)
        {
            var categoryEnum = CheckCategory();

            Console.WriteLine($"\n--->The list of loans of type {categoryEnum}:");
            Console.WriteLine("----ID----|--Amount--|--Percent--|--Months--|--LoanType--|---BankName---|---Borrower---|");
            loans.Where(x => x.LoanType == categoryEnum)
                .ToList()
                .ForEach(loan => DisplayLoanDetails(loan));
        }

        //3
        public static void DisplayBorrowers(List<Loan> loans)
        {
            Console.WriteLine("\n--->The List of All Borrowers:");
            loans.ForEach(loan => Console.WriteLine($@"- Name: {loan.Borrower.FirstName} {loan.Borrower.LastName}, Age: {DateTime.Now.Year - Convert.ToDateTime(loan.Borrower.DateOfBirth).Year}"));

        }

        //2
        public static void DisplayBanks(List<Loan> loans)
        {
            Console.WriteLine("\n--->The List of Existing Banks:");
            loans.ForEach(loan => Console.WriteLine($@"- Bank Name: {loan.Bank.Name}, Address: {loan.Bank.Address}"));
        }

        //1
        public static void DisplayLoans(List<Loan> loans)
        {
            Console.WriteLine("----ID----|--Amount--|--Percent--|--Months--|--LoanType--|---BankName---|---Borrower---|");

            loans.ForEach(loan => DisplayLoanDetails(loan));
        }

        public static void DisplayLoanDetails(Loan loan)
        {
            Console.WriteLine($@"{loan.Id.ToString().PadRight(10)}|{loan.Amount.ToString().PadRight(10)}|   {loan.Percent.ToString().PadRight(8)}|{loan.CountOfMonth.ToString().PadRight(10)}|{loan.LoanType.ToString().PadRight(12)}|{loan.Bank.Name.PadRight(14)}|{loan.Borrower.FirstName.PadRight(4)} {loan.Borrower.LastName.PadRight(9)}|");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_Solution.Enums;

namespace Task1_Solution.Models
{
    /// <summary>
    /// The entity representing the base class for loans to retrieve the data from the json file to the memory.
    /// </summary>
    public class Loan
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int CountOfMonth { get; set; }
        public float Percent { get; set; }
        public required Borrower Borrower { get; set; }
        public required Bank Bank { get; set; }
        public LoanType LoanType { get; set; }
        public float? Square { get; set; }
        public string? AddressOfObject { get; set; }
        public string? UniversityName { get; set; }
        public string? UniversityAddress { get; set; }
        public string? VIN { get; set; }
        public string? CarModel { get; set; }
        public string? CarBrand { get; set; }
    }
}

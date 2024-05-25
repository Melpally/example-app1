using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Solution.Models
{
    /// <summary>
    /// The entity representing the borrower class.
    /// </summary>
    public class Borrower
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        private DateOnly DoB;
        public string DateOfBirth
        {
            get { return DoB.ToString(); }
            set { DoB = DateOnly.Parse(value); }
        }
        public required string PassportNumber { get; set; }
    }
}

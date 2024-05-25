using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Solution.Models
{
    /// <summary>
    /// The model for the bank entity.
    /// </summary>
    public class Bank
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Address { get; set; }
    }
}

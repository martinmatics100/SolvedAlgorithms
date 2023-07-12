using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_CONSOLE_APP
{
    internal class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } = default!;
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}

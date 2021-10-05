using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WazeCredit.Models.ViewModels
{
    public class CreditResultVM
    {
        public bool Success { get; set; }
        public IEnumerable<String> ErrorList { get; set; }
        public int CreditID { get; set; }
        public double CreditApproved { get; set; }
    }
}

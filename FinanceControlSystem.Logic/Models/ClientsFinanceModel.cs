using FinanceControlSystem.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControlSystem.Logic.Models
{
    public class ClientsFinanceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency {  get; set; }
        public decimal Balance { get; set; }
        public string Comment { get; set; }
        public ClientsFinanceType Type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.NotMapped
{
    public class TransactionQuery : IQueryObject
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}

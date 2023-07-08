using Microsoft.EntityFrameworkCore;
using RealState.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Context
{
    public interface IRealStateContext
    {
        DbSet<Customer> Customers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetingSystem
{
    internal class ConnectionString
    {
        public static string Connection()
        {
            string connString = "Server = ; Database = BudgetManager; Trusted_Connection = True;";
            return connString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Izdel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionName = "Izdel.Properties.Settings.DatabaseConnectionString";;
            IzdelReport report = new IzdelReport();

            report.GetListFromDatabase(connectionName);

        }
    }
}

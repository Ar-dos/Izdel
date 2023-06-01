using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Izdel
{
    internal class IzdelReport
    {

        public void GetListFromDatabase(string connectionName) {
            string sqlScript = global::Izdel.Properties.Resources.SQLQuery;
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlScript, connection);
            SqlDataReader reader = command.ExecuteReader();

            SaveToCSV(reader);

            connection.Close();
        }

        private void SaveToCSV(SqlDataReader reader)
        {
            Encoding enc = Encoding.GetEncoding(1251);

            using (var w = new StreamWriter("report.csv", false ,enc))
            {
                Console.OutputEncoding = Encoding.UTF8;
                w.WriteLine("Изделие, Кол-во, Стоимость, Цена");     
                while (reader.Read())
                {
                    string name = reader.GetString(1);
                    object kol = reader.GetValue(2);   
                    object total = reader.GetValue(3);
                    object price = reader.GetValue(4);
                    int lvl = reader.GetInt32(5);

                    FormatNameHierarchy(ref name,lvl);

                    w.WriteLine($"{name},{kol},{total},{price}");
                    w.Flush();
                }

                w.Close();
            }
        }

        private void FormatNameHierarchy (ref string name ,int level)
        {
            var delimiter = "  ";
            for (int i = 1; i < level; i++)
                name = $"{delimiter}{name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Creating_Table_with_Reflection_Ado_Net
{
    public class TableHelper
    {
        public TableHelper GenerateTable<T>(T table) where T : class
        {
            if (table == null)
                return null;

            Dictionary<string, string> programSqlTypePair = new Dictionary<string, string>(5)
            {
                ["System.String"] = "NVARCHAR(255)",
                ["Int32"] = "INT",
                ["System.Data.SqlTypes.SqlDateTime"] = "DATETIME",
                ["System.Decimal"] = "MONEY"                
            };

            StringBuilder sb = new StringBuilder(1000);
            Type type = table.GetType();
           
            foreach (var param in type.GetProperties())
            {
                string data = param.ToString();
                sb.Append($"{param.Name} ");
                sb.Append($"{programSqlTypePair[data.Substring(0, data.IndexOf(' '))]} ");

                object[] customAttributes = param.GetCustomAttributes(true);

                foreach (var attribute in customAttributes)
                {
                    sb.Append($"{attribute} ");
                }
                sb.AppendLine(",");
            }

            Console.WriteLine(sb);
            

            using (SqlConnection connection = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["Business"].ConnectionString })
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $"CREATE TABLE {type.Name}s (ID INT PRIMARY KEY NOT NULL IDENTITY(1, 1), {sb});"
                };

                command.ExecuteNonQuery();

                connection.Close();
            }

            return this;
        }

        public TableHelper FillTableWithDatas<T>(List<T> datas) where T : class
        {
            if (datas == null || datas.Count == 0)
                return null;

            using (SqlConnection connection = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["Business"].ConnectionString })
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                };

                Type type = datas[0].GetType();
                int datasCount = datas.Count;

                for (int i = 0; i < datasCount; i++)
                {
                    string fullName = type.GetProperty("FullName").GetValue(datas[i]) as string;                    
                    string position = type.GetProperty("Position").GetValue(datas[i]) as string;
                    decimal salary = (decimal)type.GetProperty("Salary").GetValue(datas[i]);
                    SqlDateTime birthdate = (SqlDateTime)type.GetProperty("Birthdate").GetValue(datas[i]);
                    int experienceYear = (int)type.GetProperty("ExperienceYear").GetValue(datas[i]);
                    string creditCardNumber = type.GetProperty("CreditCardNumber").GetValue(datas[i]) as string;

                    command.CommandText = $"INSERT INTO Workers VALUES('{fullName}', '{position}', '{salary}', '{birthdate}', '{experienceYear}', '{creditCardNumber}');";
                    command.ExecuteNonQuery();
                }


                connection.Close();
            }

            return this;
        }
    }
}
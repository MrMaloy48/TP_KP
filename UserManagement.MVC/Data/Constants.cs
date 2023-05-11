using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Data
{
    public class Constants
    {
        public static string SqlConnectionIntegratedSecurity
        {
            get
            {
                var sb = new SqlConnectionStringBuilder
                {
                    DataSource = "(localdb)\\MSSQLLocalDB",
                    // Подключение будет с проверкой подлинности пользователя Windows
                    IntegratedSecurity = true,
                    // Название целевой базы данных.
                    InitialCatalog = "WareHouse"
                };

                return sb.ConnectionString;
            }
        }
    }
}

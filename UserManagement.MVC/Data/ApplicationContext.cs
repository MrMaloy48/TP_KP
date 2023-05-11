using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Data
{
    public class ApplicationContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Контекст получает строку подключения.
            optionsBuilder.UseSqlServer(Constants.SqlConnectionIntegratedSecurity);
        }
    }
}

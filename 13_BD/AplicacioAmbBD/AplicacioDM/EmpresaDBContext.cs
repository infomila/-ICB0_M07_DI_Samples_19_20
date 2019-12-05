using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacioDM
{
    class EmpresaDBContext : DbContext
    {

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySQL("Server=localhost;Database=empresa;UID=root;Password=informatica");
        }

    }
}

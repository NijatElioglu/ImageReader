using ImageReader.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ImageReader
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"workstation id = ImageReader.mssql.somee.com; packet size = 4096; user id = Qasimli12_SQLLogin_1; pwd=ml1qawdfwe;data source = ImageReader.mssql.somee.com; persist security info=False;initial catalog = ImageReader");
        }


        public DbSet<Files> Files { get; set; }
    }
}

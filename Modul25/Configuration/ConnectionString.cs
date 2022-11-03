using System;
using System.Collections.Generic;
using System.Text;

namespace Modul25.Configuration
{
    public class ConnectionString
    {
        public static string MsSqlConnection => @"Server=.\SQLEXPRESS;Database=Library;Trusted_Connection=True;TrustServerCertificate=Yes;";
    }
}

using HW_10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW_10.Configuration
{
    public static class Configuration
    {
        public static string configurationstring { get; set; }


        static Configuration()
        {
          
            configurationstring = "Data Source=ASO\\SQLEXPRESS;Initial Catalog=Databace-Cw10;Integrated Security=True;TrustServerCertificate=True";
        }
    }

    }


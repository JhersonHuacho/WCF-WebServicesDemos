﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CompanyServiceHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CompanyService.CompanyService)))
            {
                host.Open();
                Console.WriteLine("CompanyServiceHost is running... @ " + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}

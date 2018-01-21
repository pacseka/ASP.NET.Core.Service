﻿using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;

namespace ASP.NET.Core.Service
{
    public static class WebHostServiceExtensions
    {
        public static void RunAsCustomService(this IWebHost host)
        {
            var webHostService = new CustomWebHostService(host);
            ServiceBase.Run(webHostService);
        }
    }
}

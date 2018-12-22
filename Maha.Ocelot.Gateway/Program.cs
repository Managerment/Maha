using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;

namespace Maha.Ocelot.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 加载ocelot配置文件
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                        .ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            config
                                .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                                .AddJsonFile("appsettings.json", true, true)
                                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                                //这里可以单独配置所有的规则文件,也通过ocelot AddOcelot自动匹配加载 (规则:(?i)ocelot.([a-zA-Z0-9]*).json)
                                //Ocelot支持在配置文件发生改变的时候重新加载json配置文件
                                .AddOcelot(hostingContext.HostingEnvironment)
                                //.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                                //.AddJsonFile("ocelot.all.json", optional: false, reloadOnChange: true)
                                //.AddJsonFile("ocelot.good.json", optional: false, reloadOnChange: true)
                                //.AddJsonFile("ocelot.order.json", optional: false, reloadOnChange: true)
                                .AddEnvironmentVariables();
                        })
                .UseUrls("http://localhost:8081")
                .UseStartup<Startup>();
    }
}

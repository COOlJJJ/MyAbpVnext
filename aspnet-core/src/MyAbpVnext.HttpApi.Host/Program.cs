using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace MyAbpVnext;

public class Program
{
    /// <summary>
    /// 通常小型系统没必要把Identity Server应用程序与API host应用程序分开，会增加运维成本，这里只是为了演示分布式部署的情况，为后面的微服务做准备。
    /// xhznl的HelloAbp未分离 
    /// ABP内置了一个/api/abp/application-configuration接口，它用于返回本地化文本，权限和一些系统设置信息.
    /// 在auth.policies字段中包含了系统的所有权限，auth.grantedPolicies字段则包含了当前用户所拥有的权限
    /// currentUser字段表示当前用户信息，没登录时就是空的，isAuthenticated为false，这个字段也可以作为用户是否登录（token是否有效）的判断依据
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
#if DEBUG
            .WriteTo.Async(c => c.Console())
#endif
            .CreateLogger();

        try
        {
            Log.Information("Starting MyAbpVnext.HttpApi.Host.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<MyAbpVnextHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}

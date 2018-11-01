using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DemoServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // configure identity server with in-memory stores, keys, clients and scopes
            services
                .AddIdentityServer()//添加is
                .AddDeveloperSigningCredential()//设置为临时凭证
                
                //添加本地资源  (向ioc容器中添加对象)
                .AddInMemoryIdentityResources(Config.GetIdentityResources())//添加内存_用户建模资源
                .AddInMemoryApiResources(Config.GetApiResources())//添加api资源

                //将client 添加到唯一注入
                //并添加其他Transient依赖
                .AddInMemoryClients(Config.GetClients())//添加内存_客户端

//                .AddTestUsers(Config.GetUsers())//添加测试用户


//                .AddProfileService<CustomProfileService>()//添加概要服务
                .AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();//添加资源验证对象

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(LogLevel.Debug);//添加日志输出

            app.UseIdentityServer();//使用is

        }
    }
}

using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DemoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); //设置兼容版本

            //            services.Configure<AppSetting>(Configuration.GetSection(nameof(AppSetting)));
            //
            //            var requiredService = services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<AppSetting>>();
            //
            //            var requiredServiceCurrentValue = requiredService.CurrentValue;


            //添加中间件
            services
                .AddMvcCore() //添加mvc
                .AddAuthorization() //添加授权认证
                .AddJsonFormatters(); //添加json格式处理

            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000"; //令牌签发人的基本地址
                    options.RequireHttpsMetadata = false; //是否使用https
                    options.ApiName = "api1"; //用于针对内省端点进行身份验证的API资源的名称
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //启用授权认证
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
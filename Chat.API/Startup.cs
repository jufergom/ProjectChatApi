using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.CORE;
using Chat.Data;
using Chat.DATA.Entities;
using Chat.DATA.Repositories;
using Chat.SERVICE;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Chat.API
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
            services.AddControllers();
            services.AddDbContext<ChatContext>();

            //Repositories
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Channel>, ChannelRepository>();
            services.AddScoped<IRepository<Message>, MessageRepository>();
            services.AddScoped<IRepository<UserChannel>, UserChannelRepository>();

            //services
            services.AddScoped<IChannelService, ChannelService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization().UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

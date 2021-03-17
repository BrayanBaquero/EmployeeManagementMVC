using Microsoft.EntityFrameworkCore;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace EmployeeManagementMVC
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ////Inyectar dependencia que realizar gestion de base de datos con entity, y pasar la cadena de coneccion a base de datos
            ///que se encuentra en appsettings.json
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>//configurar restricciones de contraseña
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc(config => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));

                options.AddPolicy("EditRolePolicy",
                    policy => policy.RequireClaim("Edit Role"));

                options.AddPolicy("CreateRolePolicy",
                    policy => policy.RequireClaim("Create Role"));

                options.AddPolicy("AdminRolePolicy",
                   policy => policy.RequireClaim("Admin"));
            });
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddMvcCore(options => options.EnableEndpointRouting = false);

            //Inyeccion de dependencia, necesaria para que cuando se instancie la interface se incluya tambien su implementaicon
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();//Se hace uso de el metodo de Memory Repository
            services.AddScoped<IEmployeeRepository,SQLEmployeeReporitory>();//Se hace uso del metodo de insercion en SQL Repository

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                //app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();//Suport MVC aplication
            //app.UseMvc(); 
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            /*
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            */
        }
    }
}

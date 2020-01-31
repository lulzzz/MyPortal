using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyPortalCore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Models;
using MyPortal.Database.Models.Identity;
using MyPortal.Database.Repositories;
using MyPortal.Logic.Constants;
using MyPortal.Logic.Interfaces;
using MyPortal.Logic.Services;

namespace MyPortalCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LiveConnection")));


            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.UserType.Student, p => p.RequireClaim(ClaimType.UserType, UserType.Student));
                options.AddPolicy(Policy.UserType.Staff, p => p.RequireClaim(ClaimType.UserType, UserType.Staff));
                options.AddPolicy(Policy.UserType.Parent, p => p.RequireClaim(ClaimType.UserType, UserType.Parent));
            });

            services.AddTransient<IDbConnection>(connection =>
                new SqlConnection(Configuration.GetConnectionString("LiveConnection")));

            services.AddTransient<IAcademicYearRepository, AcademicYearRepository>();
            services.AddTransient<IAchievementRepository, AchievementRepository>();
            services.AddTransient<IAchievementTypeRepository, AchievementTypeRepository>();
            services.AddTransient<IDetentionRepository, DetentionRepository>();
            services.AddTransient<IDiaryEventRepository, DiaryEventRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<IBehaviourService, BehaviourService>();
            services.AddTransient<ISchoolService, SchoolService>();
            services.AddTransient<IStudentService, StudentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.V8;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using React.AspNet;
using System.Security.Claims;
using tmherronProfessionalSite.Contracts;
using tmherronProfessionalSite.Contracts.HeyCurator;
using tmherronProfessionalSite.Data;
using tmherronProfessionalSite.Data.HeyCurator;
using tmherronProfessionalSite.Services;
using tmherronProfessionalSite.Services.HeyCurator;

namespace tmherronProfessionalSite
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();



            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
              .AddV8();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            // Temp Disabled
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultUI()
               .AddDefaultTokenProviders();


            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
            });
            services.AddScoped<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);



            // Local MongoDb Data access configuration
            services.Configure<TmherronProfSiteSettings>(
                Configuration.GetSection(nameof(TmherronProfSiteSettings)));

            // Site settings interface/settings
            services.AddSingleton<ISiteDbSettings>(sp =>
                sp.GetRequiredService<IOptions<TmherronProfSiteSettings>>().Value);
            services.AddScoped<IRepositoryWrapperSite, RepositoryWrapper>();

            // Hey Curator settings interface/settings
            services.AddSingleton<IHCDbSettings>(sp =>
                sp.GetRequiredService<IOptions<TmherronProfSiteSettings>>().Value);
            services.AddScoped<IRepositoryWrapperHC, RepositoryWrapperHC>();



            // Remove services once replaced by Repo Pattern
            services.AddSingleton<PostService>();
            services.AddSingleton<ContactService>();
            services.AddSingleton<SuperSecretTestService>();


            // Hey Curator Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ProjectionService>();


            services.AddCors();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo
               {
                   Version = "v1",
                   Title = "Tim Herron Professional Portfolio API",
                   Description = "Api for both Personal Portfolio and projects hosted within the Professional Portfolio.",
                   Contact = new OpenApiContact
                   {
                       Name = "Tim Herron",
                       Email = "tmherron09@gmail.com",
                   },
               });
           });

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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMHerron Portfolio API v1");
           });

            app.UseCors(
                            options => options.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                        );

            app.UseHttpsRedirection();


            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                config
                .AddScript("~/js/Tutorial.jsx");
                //  .AddScript("~/js/First.jsx")
                //  .AddScript("~/js/Second.jsx");

                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //  .SetLoadBabel(false)
                //  .AddScriptWithoutTransform("~/js/bundle.server.js");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

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

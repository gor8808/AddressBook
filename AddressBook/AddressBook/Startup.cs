using AddressBook.DataAccessLayer;
using AddressBook.DataAccessLayer.AddressRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AddressBook
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
            services.AddControllersWithViews();

            var dataStorageConfiguration = new DataStorageConfiguration(
                Configuration.GetConnectionString("DefaultConnection"));

            // Setting Data Storage Configuration Dependency
            services.AddSingleton(dataStorageConfiguration);

            // Setting Address Repository Dependency
            services.AddSingleton<IAddressRepository, AddressRepository>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/PageNotFound";
                    await next();
                }
            });


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=ShowWithTable}/{id?}");
            });
        }
    }
}

using Task_Service.Filters;
using Microsoft.EntityFrameworkCore;
using Task_Service.Interfaces;
using Task_Service.Services;
using Task_Service.Mapper;
using Microsoft.AspNetCore.OData;
using Task_Repositories.Interfaces;
using Task_Repositories.Repositories;
using Task_Repositories;

namespace BitTestTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(AppMappingProfile).Assembly);

            builder.Services.AddControllersWithViews(options =>
                options.Filters.Add(typeof(NotImplExceptionFilterAttribute)))
                .AddOData(options => options.Select().OrderBy().Filter().SkipToken().SetMaxTop(10));

            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IUploadService, UploadService>();

            var connection = builder.Configuration.GetConnectionString("CsvTestConnection");

            builder.Services.AddDbContext<ApplicationContext>(options =>
              options.UseSqlServer(connection, b => b.MigrationsAssembly("BitTestTask")));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=File}/{action=Upload}");

            app.Run();
        }
    }
}
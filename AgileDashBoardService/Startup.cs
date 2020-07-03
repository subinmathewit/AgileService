using AgileDashBoardService.BL;
using AgileDashBoardService.BL.Interfaces;
using AgileDashBoardService.Data.DB;
using AgileDashBoardService.Data.UnitofWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AgileDashBoardService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AgileDbContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("AgileDb")));
            //services.AddDbContext<AgileDbContext>(options => options.UseInMemoryDatabase("AgileDb"));

            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IStoryService,StoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

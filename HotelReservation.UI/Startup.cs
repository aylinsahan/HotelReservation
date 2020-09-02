using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservation.BLL;
using HotelReservation.BLL.Helper;
using HotelReservation.BLL.Helper.Interface;
using HotelReservation.BLL.Interface;
using HotelReservation.DAL;
using HotelReservation.DAL.Repositories;
using HotelReservation.DAL.Repositories.Interface;
using HotelReservation.MODEL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelReservation.UI
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
            services.AddMvc();
            services.AddControllersWithViews();

            //services.AddDbContext<DbContext, HotelReservationContext>();
            var sqlConfiguration = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<DbContext, HotelReservationContext>(o => o.UseSqlServer(sqlConfiguration));

            //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationService, ReservationService>();
 
            services.AddScoped<ITempRoomRepository, TempRoomRepository>();
            services.AddScoped<ITempRoomService, TempRoomService>();

            services.AddScoped<IRoomPriceCalculationService, RoomPriceCalculationService>();

            services.AddScoped<IHelperProvider, HelperProvider>();

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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

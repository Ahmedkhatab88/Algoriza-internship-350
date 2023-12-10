
using ApplicationLayer.GenericInterface;
using ApplicationLayer.NonGenericInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using persistence.APPDBCONTEXT;
using VEZEETA.Infrastructure.persistence.Repositories;

namespace persistence.Container
{
    public static class IocContainer
    {
        public static IServiceCollection Services(this IServiceCollection services,IConfiguration configuration)
        {
            //add DbContext

            var config = configuration.GetConnectionString("DefaultConnectionString");
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config));

            services.AddScoped<AppDbContext,AppDbContext>();

            // Register Generic and Non-generic Repositories

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IDoctorRepository), typeof(DoctorRepository));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));
            services.AddScoped(typeof(ISettingRepository), typeof(SettingRepository));
            services.AddScoped(typeof(IAdminRepository), typeof(AdminRepository));
            services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));
            services.AddScoped(typeof(ITimeSlotRepository), typeof(TimeSlotRepository));
            
            return services;
        }
    }
}

                                                          
 

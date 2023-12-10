
using ApplicationLayer.BusinessLogic.admins.Commands.AddAdmin;
using ApplicationLayer.BusinessLogic.admins.Commands.UpdateAdmin;
using ApplicationLayer.BusinessLogic.admins.Queries.GetAdminById;
using ApplicationLayer.BusinessLogic.admins.Queries.GetAdminsList;
using ApplicationLayer.BusinessLogic.Bills.Commands.AddBill;
using ApplicationLayer.BusinessLogic.Bills.Commands.UpdateBill;
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById;
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;
using ApplicationLayer.BusinessLogic.Bookings.Queries.GetBookingsList;
using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.AddDiscountCodeCoupon;
using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.UpdateDiscountCodeCoupon;
using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponById;
using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponList;
using ApplicationLayer.BusinessLogic.Doctors.Commands.AddDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsByName;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsList;
using ApplicationLayer.BusinessLogic.Patients.Commands.AddPatient;
using ApplicationLayer.BusinessLogic.Patients.Commands.UpdatePatient;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetAllBookings;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetAllDoctors;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientById;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientList;
using ApplicationLayer.BusinessLogic.Settings.Commands.AddSetting;
using ApplicationLayer.BusinessLogic.Settings.Commands.UpdateSetting;
using ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingById;
using ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingList;
using AutoMapper;
using DomainLayer.Entities;

namespace ApplicationLayer.Profiles
{
    public class Mapping : Profile
    {
        
        public Mapping()
        {

            CreateMap<Patient,PatientViewModel>().ReverseMap();
            CreateMap<Patient,PatientDetailViewModel>().ReverseMap();
            CreateMap<Patient,AddPatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            CreateMap<UpdatePatientCommand, UpdatePatientRequest>().ReverseMap();
            CreateMap<Patient, GetBookingViewModel>().ReverseMap();

            CreateMap<Doctor,DoctorViewModel>().ReverseMap();
            CreateMap<Doctor,DoctorDetailViewModel>().ReverseMap();
            CreateMap<Doctor,AddDoctorCommand>().ReverseMap();
            CreateMap<Doctor,UpdateDoctorCommand>().ReverseMap();
            CreateMap<UpdateDoctorCommand, UpdateDoctorRequest>().ReverseMap();
            CreateMap<Doctor, DoctorSearchViewModel>().ReverseMap();


            CreateMap<Booking,BookingViewModel>().ReverseMap();
            CreateMap<Booking,BookingDetailViewModel>().ReverseMap();
            CreateMap<Booking,AddBookingCommand>().ReverseMap();
            CreateMap<Booking,UpdateBookingCommand>().ReverseMap();
            CreateMap<UpdateBookingCommand, UpdateBookingRequest>().ReverseMap();

            CreateMap<Setting, SettingViewModel>().ReverseMap();
            CreateMap<Setting, SettingDetailViewModel>().ReverseMap();
            CreateMap<Setting, AddSettingCommand>().ReverseMap();
            CreateMap<Setting, UpdateSettingCommand>().ReverseMap();
            CreateMap<UpdateSettingCommand, UpdateSettingRequest>().ReverseMap();

            CreateMap<Admin, AdminViewModel>().ReverseMap();
            CreateMap<Admin, AdminDetailViewModel>().ReverseMap();
            CreateMap<Admin, AddAdminCommand>().ReverseMap();
            CreateMap<Admin, UpdateAdminCommand>().ReverseMap();
            CreateMap<UpdateAdminCommand, UpdateAdminRequest>().ReverseMap();

            CreateMap<DiscountCodeCoupon, DiscountCodeCouponViewModel>().ReverseMap();
            CreateMap<DiscountCodeCoupon, DiscountCodeCouponDetailedViewModel>().ReverseMap();
            CreateMap<DiscountCodeCoupon, AddDiscountCodeCouponCommand>().ReverseMap();
            CreateMap<DiscountCodeCoupon, UpdateDiscountCodeCouponCommand>().ReverseMap();
            CreateMap<UpdateDiscountCodeCouponCommand, UpdateDiscountCodeCouponRequest>().ReverseMap();

            CreateMap<Patient,PatientDTO>().ReverseMap();
            CreateMap<Doctor,DoctorDTO>().ReverseMap();
            CreateMap<TimeSlot,TimeSlotDTO>().ReverseMap();
            CreateMap<Setting,SettingDTO>().ReverseMap();
            CreateMap<Admin,AdminDTO>().ReverseMap();
            




        }

    }
}

using Application.Data.Entities;
using System.Threading.Tasks;
using Application.Models.Requests;
using System.Collections.Generic;
using System;

namespace Application.Services
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointment(Guid UserId, CreateAppointmentModel model);
        Task<Appointment> UpdateAppointmentAsync(Appointment appointment, UpdateAppointmentModel model);
        Task<bool> DeleteAppointmentAsync(Appointment appointment);
        List<Appointment> GetAppointments(Guid userId);
        Appointment GetAppointment(int id);
    }

}
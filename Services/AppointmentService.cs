using Application.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Data;
using Application.Models.Requests;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Application.Services 
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DBContext _context;
        private readonly ICalendarService _calendarService;

        public AppointmentService(DBContext context, ICalendarService calendarService)
        {
            _context = context;
            _calendarService = calendarService;
        }

        public async Task<Appointment> CreateAppointment(Guid UserId, CreateAppointmentModel model)
        {
            // Create a new Appointment model with the data from the CreateAppointmentModel
            Appointment createdAppointment = new Appointment 
            {
                UserId = UserId,
                Name = model.Name,
                Start = model.Start,
                End = model.End,
                CalendarId = model.CalendarId,
                Editable = model.Editable
            };

            // Call the dbContext to create the appointment
            _context.Appointment.Add(createdAppointment);
            await _context.SaveChangesAsync();

            // Add current user to attendees list
            model.Attendees.Add(new User { Id = UserId });

            // Add all attendees to work provider
            foreach (User attendee in model.Attendees)
            {
                _context.WorkProvider.Add(new WorkProvider 
                {
                    UserId = attendee.Id,
                    AppointmentId = createdAppointment.Id
                });
            }

            await _context.SaveChangesAsync();

            return createdAppointment;
        }

        public async Task<Appointment> UpdateAppointmentAsync(Appointment appointmentToUpdate, UpdateAppointmentModel model)
        {
            // Update the appointment's properties
            if (!string.IsNullOrEmpty(model.Name) && appointmentToUpdate.Name != model.Name)
            {
                appointmentToUpdate.Name = model.Name;
            }

            if (!string.IsNullOrEmpty(model.Start.ToString()) && appointmentToUpdate.Start != model.Start)
            {
                appointmentToUpdate.Start = model.Start;
            }

            if (!string.IsNullOrEmpty(model.End.ToString()) && appointmentToUpdate.End != model.End)
            {
                appointmentToUpdate.End = model.End;
            }

            if (!string.IsNullOrEmpty(model.Editable.ToString()) && appointmentToUpdate.Editable != model.Editable)
            {
                appointmentToUpdate.Editable = model.Editable;
            }

            // Call the Appointment Context to update the appointment
            _context.Appointment.Update(appointmentToUpdate);
            await _context.SaveChangesAsync();

            return appointmentToUpdate;
        }

        public async Task<bool> DeleteAppointmentAsync(Appointment deleteAppointment)
        {
            // Call the userContext to delete the user
            _context.Appointment.Remove(deleteAppointment);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public List<Appointment> GetAppointments(Guid userId)
        {
            // Call the Appointment Context to get the Appointments
            List<Appointment> appointments = _context.Appointment
                .Include(appointment => appointment.Initiator) // Eager loading of Initiator entity
                .Where(appointment => appointment.UserId == userId)
                .ToList();

            return appointments;
        }


        public Appointment GetAppointment(int id)
        {
            // Get the appointment from the database
            Appointment appointment = _context.Appointment.SingleOrDefault(appointment => appointment.Id == id);

            // Check if the appointment exists
            if (appointment == null)
            {
                return null;
            }

            return appointment;
        }
    }
}
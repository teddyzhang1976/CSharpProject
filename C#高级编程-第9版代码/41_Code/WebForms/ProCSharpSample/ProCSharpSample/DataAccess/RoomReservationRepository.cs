using ProCSharpSample.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProCSharpSample.DataAccess
{
  public class RoomReservationRepository
  {
    public IEnumerable<MeetingRoom> GetMeetingRooms()
    {
      using (var data = new RoomReservationEntities())
      {
        return data.MeetingRooms.AsNoTracking().ToList();
      }
    }

    public IEnumerable<Reservation> GetReservationsByRoom(int roomId)
    {
      using (var data = new RoomReservationEntities())
      {
        return data.Reservations.AsNoTracking().Where(r => r.RoomId == roomId).Include(r => r.MeetingRoom).ToList();
      }
    }

    public void AddReservation(Reservation reservation)
    {
      using (var data = new RoomReservationEntities())
      {
        data.Reservations.Add(reservation);
        data.SaveChanges();
      }
    }

    public void UpdateReservation(Reservation reservation)
    {
      using (var data = new RoomReservationEntities())
      {
        data.Reservations.Attach(reservation);
        data.Entry(reservation).State = EntityState.Modified;
        data.SaveChanges();
      }
    }

    public void DeleteReservation(Reservation reservation)
    {
      using (var data = new RoomReservationEntities())
      {
        data.Reservations.Remove(reservation);
        data.SaveChanges();
      }
    }
  }
}
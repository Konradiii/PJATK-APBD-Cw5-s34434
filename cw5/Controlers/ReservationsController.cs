using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace cw5.Controlers;

public class ReservationsController : ControllerBase
{
    
    public static List<Reservation> Reservations =
    [
        new Reservation
        {
            Id = 1,
            RoomId = 2,
            OrganizerName = "Pawel",
            Topic = "Strukturyzacja",
            Date = DateTime.Now,
            StartTime = new DateTime(2026, 12, 21, 10, 0, 0),
            EndTime = new DateTime(2026, 12, 21, 12, 0, 0),
            Status = ReservationStatus.planned
        },
        new Reservation
        {
            Id = 2,
            RoomId = 1,
            OrganizerName = "Anna",
            Topic = "Projekt zespołowy",
            Date = DateTime.Now,
            StartTime = new DateTime(2026, 11, 10, 9, 0, 0),
            EndTime = new DateTime(2026, 11, 10, 11, 0, 0),
            Status = ReservationStatus.planned
        },
        new Reservation
        {
            Id = 3,
            RoomId = 3,
            OrganizerName = "Krzysztof",
            Topic = "Spotkanie biznesowe",
            Date = DateTime.Now,
            StartTime = new DateTime(2026, 10, 5, 14, 0, 0),
            EndTime = new DateTime(2026, 10, 5, 16, 0, 0),
            Status = ReservationStatus.confirmed
        },
        new Reservation
        {
            Id = 4,
            RoomId = 4,
            OrganizerName = "Magda",
            Topic = "Szkolenie",
            Date = DateTime.Now,
            StartTime = new DateTime(2026, 9, 15, 8, 0, 0),
            EndTime = new DateTime(2026, 9, 15, 13, 0, 0),
            Status = ReservationStatus.cancelled
        },
        new Reservation
        {
            Id = 5,
            RoomId = 5,
            OrganizerName = "Tomasz",
            Topic = "Prezentacja",
            Date = DateTime.Now,
            StartTime = new DateTime(2026, 8, 20, 12, 0, 0),
            EndTime = new DateTime(2026, 8, 20, 14, 0, 0),
            Status = ReservationStatus.planned
        },
        new Reservation
        {
            Id = 6,
            RoomId = 2,
            OrganizerName = "Karolina",
            Topic = "Warsztaty",
            Date = DateTime.Now,
            StartTime = new DateTime(2026, 7, 1, 10, 0, 0),
            EndTime = new DateTime(2026, 7, 1, 15, 0, 0),
            Status = ReservationStatus.confirmed
        }
    ];
    
}
using cw5.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace cw5.Controlers;


[ApiController]
[Route("api/[controller]")]
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
    
    
    
    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] DateTime? date, 
        [FromQuery] ReservationStatus? status,
        [FromQuery] int? RoomId 
        )
    {
        var result =
            Reservations
                .Where(r =>
                    (date == null || r.Date == date) &&
                    (status == null || r.Status == status) &&
                    (RoomId == null || r.RoomId == RoomId)
                )
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    RoomId = r.RoomId,
                    OrganizerName = r.OrganizerName,
                    Topic = r.Topic,
                    Date = r.Date,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Status = r.Status

                });
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var reservation =  Reservations.FirstOrDefault(r => r.Id == id);
        
        if (reservation == null)
            return NotFound();
        
        return Ok(new ReservationDto
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            OrganizerName = reservation.OrganizerName,
            Topic = reservation.Topic,
            Date = reservation.Date,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
            Status = reservation.Status

        });
        
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateReservationDto reservation)
    {

        var rez = new Reservation
        {
            Id = Reservations.Max(r => r.Id) + 1,
            RoomId = reservation.RoomId,
            OrganizerName = reservation.OrganizerName,
            Topic = reservation.Topic,
            Date = reservation.Date,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
            Status = reservation.Status
        };
        Reservations.Add(rez);
        return CreatedAtAction(nameof(GetById), new { id = rez.Id }, rez);    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateReservationDto reservation)
    {
        
        var rez = Reservations.FirstOrDefault(r => r.Id == id);

        if (rez == null)
        {
            return NotFound();
        }

        rez.OrganizerName = reservation.OrganizerName;
        rez.Topic = reservation.Topic;
        rez.Date = reservation.Date;
        rez.StartTime = reservation.StartTime;
        rez.EndTime = reservation.EndTime;
        rez.Status = reservation.Status;

        
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var rez = Reservations.FirstOrDefault(r => r.Id == id);

        if (rez == null)
            return NotFound();

        Reservations.Remove(rez);
        return NoContent();
    }
    
}
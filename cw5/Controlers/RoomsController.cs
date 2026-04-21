using System.ComponentModel.DataAnnotations;
using cw5.DTO;
using Microsoft.AspNetCore.Mvc;

namespace cw5.Controlers;


[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{

    public static List<Room> Rooms =
    [
        new Room
        {
            Id = 1,
            Name = "Room 1",
            BuildingCode = "54",
            Floor = 2,
            Capacity = 4,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 2,
            Name = "Room 2",
            BuildingCode = "43",
            Floor = 4,
            Capacity = 1,
            HasProjector = false,
            IsActive = true
        },
        new Room
        {
            Id = 3,
            Name = "Room 3",
            BuildingCode = "54",
            Floor = 1,
            Capacity = 10,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 4,
            Name = "Room 4",
            BuildingCode = "12",
            Floor = 3,
            Capacity = 20,
            HasProjector = true,
            IsActive = false
        },
        new Room
        {
            Id = 5,
            Name = "Room 5",
            BuildingCode = "43",
            Floor = 2,
            Capacity = 6,
            HasProjector = false,
            IsActive = true
        },
        new Room
        {
            Id = 6,
            Name = "Room 6",
            BuildingCode = "12",
            Floor = 5,
            Capacity = 15,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 7,
            Name = "Room 7",
            BuildingCode = "54",
            Floor = 0,
            Capacity = 3,
            HasProjector = false,
            IsActive = false
        }
    ];


    [HttpGet("building/{buildingCode}")]
    public IActionResult GetByBuildingCode(string buildingCode)
    {
        var result = Rooms
            .Where(r => r.BuildingCode == buildingCode)
            .Select(r => new RoomDto
            {
                Id = r.Id,
                Name = r.Name,
                BuildingCode = r.BuildingCode,
                Floor = r.Floor,
                Capacity = r.Capacity,
                HasProjector = r.HasProjector,
                IsActive = r.IsActive
            });
        return Ok(result);
    }


[HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var room = Rooms.FirstOrDefault(e => e.Id == id);

        if (room == null)
        {
            return NotFound($"Room with id {id} not found");
        }

        return Ok(new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            BuildingCode = room.BuildingCode,
            Floor = room.Floor,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        });
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string? buildingCode,
        [FromQuery] int? minCapacity,
        [FromQuery] bool? hasProjector,
        [FromQuery] bool? activeOnly
    )
    {

        var result = 
            Rooms
            .Where(
                r => (buildingCode == null || r.BuildingCode == buildingCode) &&
                     (minCapacity == null || r.Capacity >= minCapacity) &&
                     (hasProjector == null || r.HasProjector == hasProjector) &&
                     (activeOnly == null || r.IsActive == activeOnly)
                
                )
            .Select(r => new RoomDto
            {
                Id = r.Id,
                Name = r.Name,
                BuildingCode = r.BuildingCode,
                Floor = r.Floor,
                Capacity = r.Capacity,
                HasProjector = r.HasProjector,
                IsActive = r.IsActive
            });
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateRoomDto updateRoomDto)
    {
        
        var room = Rooms.FirstOrDefault(e=>e.Id == id);

        if (room == null)
        {
            return NotFound($"Room with id {id} not found");
        }
        room.Name = updateRoomDto.Name;
        room.BuildingCode = updateRoomDto.BuildingCode;
        room.Floor = updateRoomDto.Floor;
        room.Capacity = updateRoomDto.Capacity;
        room.HasProjector = updateRoomDto.HasProjector;
        room.IsActive = updateRoomDto.IsActive;
        
        return NoContent();
        
    }

    [HttpPost]
    public IActionResult Create(CreateRoomDto createRoomDto)
    {
        var room = new Room
        {
            Id = Rooms.Max(e => e.Id) + 1,
            Name = createRoomDto.Name,
            BuildingCode = createRoomDto.BuildingCode,
            Floor = createRoomDto.Floor,
            Capacity = createRoomDto.Capacity,
            HasProjector = createRoomDto.HasProjector,
            IsActive = createRoomDto.IsActive
        };
            
            Rooms.Add(room);
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
    }


    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var room = Rooms.FirstOrDefault(e => e.Id == id);

        if (room == null)
        {
            return NotFound($"Room with id {id} not found");
        }
        Rooms.Remove(room);
        return NoContent();
    }
    

}
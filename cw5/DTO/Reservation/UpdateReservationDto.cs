namespace cw5.DTO;

public class UpdateReservationDto
{
    public String OrganizerName { get; set; }
    public String Topic { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ReservationStatus Status { get; set; }
}
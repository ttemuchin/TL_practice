namespace Domain.Entities;
public class Hours
{
    public int Id { get; init; }   
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public DayOfWeek Days { get; set; }

    public int TheatreId { get; set; }
    public Theatre Theatre { get; set; }

    public Hours( DayOfWeek days, TimeSpan openingTime, TimeSpan closingTime, int theatreId )
    {
        TheatreId = theatreId;
        Days = days;
        OpeningTime = openingTime;
        ClosingTime = closingTime;        
    }
}

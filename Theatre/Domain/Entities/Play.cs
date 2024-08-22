using System.Text;

namespace Domain.Entities;
public class Play
{
    public int Id { get; private init; }
    public string Name { get; private init; }
    public DateTime StartDate { get; private init; }
    public DateTime EndDate { get; private init; }
    public decimal TicketPrice { get; set; }
    public string Description { get; set; }
    public Theatre Theatre { get; set; }
    public int TheatreId { get; private set; }
    public Composition Composition { get; set; }
    public int CompositionId { get; set; }

    public Play( string name, string description, DateTime startDate, DateTime endDate, decimal price, int teatreId, int compositionId )
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        TicketPrice = price;
        TheatreId = teatreId;
        CompositionId = compositionId;
    }
    public Play( int id, string name, string description, DateTime startDate, DateTime endDate, decimal price, int teatreId, int compositionId )
    {
        Id = id;
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        TicketPrice = price;
        TheatreId = teatreId;
        CompositionId = compositionId;
    }

    public override string ToString()
    {
        StringBuilder sb = new( 300 );
        sb.AppendLine( "[Play]" );
        sb.AppendLine( $"  Id: {Id}" );
        sb.AppendLine( $"  Name: {Name}" );
        sb.AppendLine( $"  TicketPrice:{TicketPrice}" );
        sb.AppendLine( $"  StartDate:{StartDate}" );
        sb.AppendLine( $"  EndDate:{EndDate}" );

        return sb.ToString();
    }
}

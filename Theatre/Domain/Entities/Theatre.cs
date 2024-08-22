using System.Text;

namespace Domain.Entities;
public class Theatre
{
    public int Id { get; private init; }
    public string Name { get; private init; }
    public string Address { get; private init; }
    public string PhoneNumber { get; set; }
    public DateTime OpeningDate { get; private init; }
    public string Description { get; set; }
    public List<Hours> TheaterHours { get; set; } = new List<Hours>();
    public List<Play> Plays { get; private init; } = new List<Play>();

    public Theatre( string name, string address, string phoneNumber, DateTime openingDate, string description )
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        OpeningDate = openingDate;
        Description = description;
    }

    public override string ToString()
    {
        StringBuilder sb = new( 300 );
        sb.AppendLine( "[Theater]" );
        sb.AppendLine( $"  Id: {Id}" );
        sb.AppendLine( $"  Name: {Name}" );
        sb.AppendLine( $"  Address: {Address}" );
        sb.AppendLine( $"  PhoneNumber: {PhoneNumber}" );
        sb.AppendLine( $"  OpeningDate: {OpeningDate}" );
        sb.AppendLine( $"  [Plays]: " );
        foreach ( Play play in Plays )
        {
            sb.AppendLine( $"    {play}" );
        }

        return sb.ToString();
    }
}

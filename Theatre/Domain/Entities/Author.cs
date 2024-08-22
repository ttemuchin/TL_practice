namespace Domain.Entities;
public class Author
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private init; }
    public IReadOnlyList<Composition> Compositions { get; init; } = new List<Composition>();

    public Author( string name, DateTime dateOfBirth )
    {
        if ( string.IsNullOrEmpty( name ) )
        {
            throw new ArgumentException( $"'{nameof( name )}' cannot be null or empty.", nameof( name ) );
        }
        Name = name;
        DateOfBirth = dateOfBirth;

    }
}

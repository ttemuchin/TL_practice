using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Composition
{
    public int CompositionId { get; init; }
    public string Name { get; set; }
    public string Heroes { get; set; }
    public string Description { get; set; }
    public Author Author { get; set; }
    public int AuthorId { get; set; }

    public List<Play> Plays { get; set; }

    public Composition( string name, string heroes, string description, int authorId )
    {
        Name = name;
        Heroes = heroes;
        Description = description;
        AuthorId = authorId;
    }
}

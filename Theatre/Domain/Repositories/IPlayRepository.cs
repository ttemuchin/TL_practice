using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPlayRepository
    {
        IReadOnlyList<Play> GetAllPlays();

        void Save( Play play );

        void Update( Play play );

        void Delete( int id );
    }
}

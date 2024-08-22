using Domain.Entities;

namespace WebAPI.DTO
{
    public class CreatePlayRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TicketPrice { get; set; }
        public string Description { get; set; }
        public Theatre Theatre { get; set; }
        public int TheatreId { get; set; }
        public Composition Composition { get; set; }
        public int CompositionId { get; set; }
    }
}

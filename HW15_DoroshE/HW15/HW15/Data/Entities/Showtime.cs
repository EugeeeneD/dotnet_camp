namespace HW15.Data.Entities
{
    public class Showtime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
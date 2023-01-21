namespace HW15.Data.Entities
{
    public class Showtime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public Movie Movie { get; set; }
        public ICollection<Hall> Halls { get; set; }
    }
}
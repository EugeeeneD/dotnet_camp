namespace HW15.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
namespace Entities.Concrete
{
    public class Blacklist
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string Reason { get; set; }
        public bool IsActive { get; set; }
    }
}

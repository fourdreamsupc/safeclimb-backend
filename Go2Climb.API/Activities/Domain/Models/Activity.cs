namespace Go2Climb.API.Activities.Domain.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        //Relationships
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
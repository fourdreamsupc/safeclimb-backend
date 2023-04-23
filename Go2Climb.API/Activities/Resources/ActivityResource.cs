using Go2Climb.API.Services.Resources;
using Go2Climb.API.Services.Services.Resources;

namespace Go2Climb.API.Activities.Resources
{
    public class ActivityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ServiceResource Service;
    }
}
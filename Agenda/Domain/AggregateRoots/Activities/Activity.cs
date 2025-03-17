using Domain.Common;
using Domain.Entities;
using Type = Domain.Entities.Type;

namespace Domain.AggregateRoots.Activities
{
    public class Activity : AggregateRoot
    {
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int TypeId { get; set; }
        public Type? Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; } = false;
        public List<Task> Tasks { get; set; } = new();
    }
}
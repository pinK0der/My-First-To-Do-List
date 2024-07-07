using Microsoft.EntityFrameworkCore;

namespace To_Do_List.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string? EventToDo { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsFinished { get; set; }
    }
}

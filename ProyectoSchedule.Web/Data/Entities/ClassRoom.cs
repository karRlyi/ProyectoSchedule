namespace ProyectoSchedule.Web.Data.Entities
{
    using System.Collections.Generic;

    public class ClassRoom : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}

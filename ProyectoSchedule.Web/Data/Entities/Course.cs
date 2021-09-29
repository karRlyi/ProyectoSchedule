namespace ProyectoSchedule.Web.Data.Entities
{
    using System.Collections.Generic;

    public class Course : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }

        
        public Teacher Teacher { get; set; }
        public Career Career { get; set; }
        public Subject Subject { get; set; }

        public ICollection<CourseDetail> CourseDetails { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}

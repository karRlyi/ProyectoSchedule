namespace ProyectoSchedule.Web.Data.Entities
{
    using System.Collections.Generic;

    public class Student : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<CourseDetail>  CourseDetails { get; set; }
        public Career Career { get; set; }
    }
}

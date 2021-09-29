using System.Collections.Generic;

namespace ProyectoSchedule.Web.Data.Entities
{
    public class Career : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Coordinator Coordinator { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}

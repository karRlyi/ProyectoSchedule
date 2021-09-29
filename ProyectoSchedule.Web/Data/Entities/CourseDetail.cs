namespace ProyectoSchedule.Web.Data.Entities
{
    public class CourseDetail:IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}

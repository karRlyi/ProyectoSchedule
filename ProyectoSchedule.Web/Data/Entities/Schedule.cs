namespace ProyectoSchedule.Web.Data.Entities
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int  StartingHour { get; set; }
        public int EndingHour { get; set; }
        public WeekDay WeekDay { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public Course Course { get; set; }
    }
}

namespace ProyectoSchedule.Web.Data.Entities
{
 using System.Collections.Generic;

   public class Coordinator : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public Career Career { get; set; }
    }
}

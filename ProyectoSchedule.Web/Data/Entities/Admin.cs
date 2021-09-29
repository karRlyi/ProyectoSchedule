namespace ProyectoSchedule.Web.Data.Entities
{
    using System.Collections.Generic;

    public class Admin : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }

    }
}

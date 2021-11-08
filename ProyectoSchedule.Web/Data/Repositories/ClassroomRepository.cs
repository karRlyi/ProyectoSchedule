namespace ProyectoSchedule.Web.Data.Repositories
{
    using ProyectoSchedule.Web.Data.Entities;
    public class ClassroomRepository:GenericRepository<ClassRoom>, IClassroomRepository
    {
        public ClassroomRepository(DataContext dataContext):base(dataContext)
        {

        }
    }
}

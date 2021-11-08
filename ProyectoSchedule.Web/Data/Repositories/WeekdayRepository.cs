using ProyectoSchedule.Web.Data.Entities;

namespace ProyectoSchedule.Web.Data.Repositories
{
    public class WeekdayRepository : GenericRepository<WeekDay>,IWeekdayRepository
    {
        public WeekdayRepository(DataContext dataContext):base (dataContext)
        {

        }
    }
}

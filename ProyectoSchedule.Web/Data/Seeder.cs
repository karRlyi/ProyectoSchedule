namespace ProyectoSchedule.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using ProyectoSchedule.Web.Data.Entities;
    using ProyectoSchedule.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class Seeder
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        //agregar las entidades o roles correspondientes
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Coordinator");
            await this.userHelper.CheckRoleAsync("Teacher");
            await this.userHelper.CheckRoleAsync("Student");

            if (!this.dataContext.Admins.Any())
            {
                var user = await CheckUserAsync("Ramos", "Karla", "karla.ramos@gmail.com", "8888888888", "123456", "Admin");
                await CheckAdminAsync(user);
            }
            if (!this.dataContext.Coordinators.Any())
            {
                var user = await CheckUserAsync("Zapata", "Carlos", "carlos.zapata@gmail.com", "2651651", "123456", "Coordinator");
                await CheckCoordinatorAsync(user);
            }
            if (!this.dataContext.Teachers.Any())
            {
                var user = await CheckUserAsync("Benitez", "Karla", "karla.benitez@gmail.com", "8888888888", "123456", "Teacher");
                await CheckTeacherAsync(user);
            }
            if (!this.dataContext.Students.Any())
            {
                var user = await CheckUserAsync("Jimenez", "Saul", "saul.jimenez@gmail.com", "777777777", "123456", "Student");
                await CheckStudentAsync(user);
            }

        }
        //Creacion de usuarios desde el seeder
        private async Task<User> CheckUserAsync(string lastName, string firstName, string mail, string phone, string password, string rol)
        {
            var user = await userHelper.GetUserByEmailAsync(mail);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = mail,
                    UserName = mail,
                    PhoneNumber = phone,
                };
                var result = await userHelper.AddUserAsync(user, password);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se puede crear el usuario en la base de datos");
                }
                await userHelper.AddUserToRoleAsync(user, rol);
            }
            return user;
        }
        private async Task CheckAdminAsync(User user)
        {
            this.dataContext.Admins.Add(new Admin { User = user });
            await this.dataContext.SaveChangesAsync();
        }
        
        private async Task CheckCoordinatorAsync(User user)
        {
            this.dataContext.Coordinators.Add(new Coordinator { User = user });
            await this.dataContext.SaveChangesAsync();
        }
        private async Task CheckTeacherAsync(User user)
        {
            this.dataContext.Teachers.Add(new Teacher { User = user });
            await this.dataContext.SaveChangesAsync();
        }
        private async Task CheckStudentAsync(User user)
        {
            this.dataContext.Students.Add(new Student { User = user });
            await this.dataContext.SaveChangesAsync();
        }
    }
}

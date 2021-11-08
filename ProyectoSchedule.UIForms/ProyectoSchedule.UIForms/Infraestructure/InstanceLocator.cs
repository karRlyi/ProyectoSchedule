namespace ProyectoSchedule.UIForms.Infraestructure
{
    using ProyectoSchedule.UIForms.ViewModels;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}

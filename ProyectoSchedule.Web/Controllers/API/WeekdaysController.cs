namespace ProyectoSchedule.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using ProyectoSchedule.Web.Data.Entities;
    using ProyectoSchedule.Web.Data.Repositories;
    using System;
    using System.Linq;

    [Route("API/[Controller]")]
    public class WeekdaysController:Controller
    {
        private readonly IWeekdayRepository weekdayRepository;
        public WeekdaysController(IWeekdayRepository weekdayRepository)
        {
            this.weekdayRepository = weekdayRepository;
        }
        [HttpGet]
        public IActionResult GetWeekdays()
        {
            return Ok(this.weekdayRepository.GetAll());
        }
    }
}

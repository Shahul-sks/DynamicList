using DynamicList.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//using System.Web.UI;

namespace DynamicList.Controllers
{
    public class CarController : Controller
    {
        private readonly CarContext carcontext;
        public CarController(CarContext carcontext)
        {
            this.carcontext = carcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateData(Car car,IFormFile carpic)
        {
          if (carpic != null)
            {
                using MemoryStream stream = new MemoryStream();
                carpic.CopyTo(stream);
                car.carpic = stream.ToArray();

            }
            carcontext.Cars.Add(car);
            carcontext.SaveChanges();

            return RedirectToAction("Index");   
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpGet]
        public ActionResult GetCar()
        {

            var data = carcontext.Cars.ToList();
            return Json(data);

        }
     


    }
}

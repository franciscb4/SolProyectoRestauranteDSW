using Microsoft.AspNetCore.Mvc;

namespace ProyectoRestauranteDSW.Controllers
{
    public class RestauranteController : Controller
    {
        public IActionResult MenuCatalog()
        {
            return View();
        }

        public IActionResult MenuCatalogDetail( int id) 
        {
            return View();
        }

        public IActionResult ConfirmOrderCar() 
        {
            return View();
        }
    }

}

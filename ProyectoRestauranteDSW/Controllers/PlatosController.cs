using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoRestauranteDSW.Controllers
{
    public class PlatosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly RestauranteContext _restauranteContext;

        public PlatosController(
            RestauranteContext restauranteContext,
            IMapper mapper)
        {
            _restauranteContext = restauranteContext;
            _mapper = mapper;
        }

        public IActionResult ListPlat()
        {
            var platos = _restauranteContext.Plato.ToList();
            var platosModelList = new List<PlatosModel>();
            foreach (var plato in platos)

            {
                var platoModel = Mapper.Map<PlatosModel>(plato);
                platosModelList.Add(platoModel);
            }
            return View(platosModelList);
        }

        public IActionResult AddPlat()
        {
            return View();
        }

        public IActionResult AddSaveActionPlat()
        {
            return View();
        }

        public IActionResult EditPlat(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditSavedPlat()
        {
            return View();
        }

        [HttpGet]
        public JsonResult DeletePlat(int id)
        {
            return Json("");
        }
    }
}

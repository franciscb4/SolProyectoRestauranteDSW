using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult AddSaveActionPlat(PlatosModel platoModel)
        {
            if (ModelState.IsValid)
            {
                var platoEntity = _mapper.Map<PlatosEntity>(platoModel);
                _restauranteContext.Plato.Add(platoEntity);
                _restauranteContext.SaveChanges();
                return RedirectToAction("ListPlat");
            }

            return View("AddPlat", platoModel);
        }

        public IActionResult EditPlat(int id)
        {
            var platoEntity = _restauranteContext.Plato.Find(id);
            var platoModel = _mapper.Map<PlatosModel>(platoEntity);
            return View(platoModel);
        }
        [HttpPost]
        public IActionResult EditSavedPlat(PlatosModel platoModel)
        {
            if (ModelState.IsValid)
            {
                var platoEntity = _mapper.Map<PlatosEntity>(platoModel);
                _restauranteContext.Entry(platoEntity).State = EntityState.Modified;
                _restauranteContext.SaveChanges();
                return RedirectToAction("ListPlat");
            }

            return View("EditPlat", platoModel);
        }



        [HttpGet]
        public JsonResult DeletePlatConfirmed(int id)
        {
            var platoEntity = _restauranteContext.Plato.Find(id);

            _restauranteContext.Plato.Remove(platoEntity);
            _restauranteContext.SaveChanges();


            return Json("Se elimino de manera correcta"+" "+ platoEntity.NombrePlato);
        }
    }
}

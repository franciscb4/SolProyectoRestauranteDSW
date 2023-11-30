using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoRestauranteDSW.Controllers
{
    public class LocalesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly RestauranteContext _restauranteContext;

        public LocalesController(
            RestauranteContext restauranteContext,
            IMapper mapper)
        {
            _restauranteContext = restauranteContext;
            _mapper = mapper;
        }

        public IActionResult ListLoc()
        {
            var locales = _restauranteContext.Local.ToList();
            var localesModelList = new List<LocalesModel>();
            foreach (var local in locales)

            {
                var localModel = Mapper.Map<LocalesModel>(local);
                localesModelList.Add(localModel);
            }
            return View(localesModelList);
        }

        public IActionResult AddLoc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSaveActionLoc(LocalesModel localModel)
        {
            if (ModelState.IsValid)
            {
                var localEntity = _mapper.Map<LocalesEntity>(localModel);
                _restauranteContext.Local.Add(localEntity);
                _restauranteContext.SaveChanges();
                return RedirectToAction("ListLoc");
            }

            return View("AddLoc", localModel);
        }

        public IActionResult EditLoc(int id)
        {
            var localEntity = _restauranteContext.Local.Find(id);
            var localModel = _mapper.Map<LocalesModel>(localEntity);
            return View(localModel);
        }
        [HttpPost]
        public IActionResult EditSavedLoc(LocalesModel localModel)
        {
            if (ModelState.IsValid)
            {
                var localEntity = _mapper.Map<LocalesEntity>(localModel);
                _restauranteContext.Entry(localEntity).State = EntityState.Modified;
                _restauranteContext.SaveChanges();
                return RedirectToAction("ListLoc");
            }

            return View("EditLoc", localModel);
        }


        [HttpGet]
        public JsonResult DeleteLocConfirmed(int id)
        {
            var localEntity = _restauranteContext.Local.Find(id);

            _restauranteContext.Local.Remove(localEntity);
            _restauranteContext.SaveChanges();


            return Json("Se elimino de manera correcta"+""+localEntity.NombreLocal);
        }
    }
}

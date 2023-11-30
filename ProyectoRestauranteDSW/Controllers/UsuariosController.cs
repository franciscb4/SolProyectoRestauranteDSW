using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoRestauranteDSW.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly RestauranteContext _restauranteContext;

        public UsuariosController(
            RestauranteContext restauranteContext,
            IMapper mapper)
        {
            _restauranteContext = restauranteContext;
            _mapper = mapper;
        }

        public IActionResult ListUsu()
        {
            var usuarios = _restauranteContext.Usuario.ToList();
            var usuariosModelList = new List<UsuariosModel>();
            foreach (var usuario in usuarios)

            {
                var usuarioModel = Mapper.Map<UsuariosModel>(usuario);
                usuariosModelList.Add(usuarioModel);
            }
            return View(usuariosModelList);
        }

        public IActionResult AddUsu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSaveActionUsu(UsuariosModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioEntity = _mapper.Map<UsuariosEntity>(usuarioModel);
                _restauranteContext.Usuario.Add(usuarioEntity);
                _restauranteContext.SaveChanges();
                return RedirectToAction("ListUsu");
            }

            return View("AddUsu", usuarioModel);
        }

        public IActionResult EditUsu(int id)
        {
            var usuarioEntity = _restauranteContext.Usuario.Find(id);
            var usuarioModel = _mapper.Map<UsuariosModel>(usuarioEntity);
            return View(usuarioModel);
        }
        [HttpPost]
        public IActionResult EditSavedUsu(UsuariosModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioEntity = _mapper.Map<UsuariosEntity>(usuarioModel);
                _restauranteContext.Entry(usuarioEntity).State = EntityState.Modified;
                _restauranteContext.SaveChanges();
                return RedirectToAction("ListUsu");
            }

            return View("EditUsu", usuarioModel);
        }

   

        [HttpGet]
        public JsonResult DeleteUsuConfirmed(int id)
        {
            var usuarioEntity = _restauranteContext.Usuario.Find(id);

            _restauranteContext.Usuario.Remove(usuarioEntity);
            _restauranteContext.SaveChanges();


            return Json("Se elimino de manera correcta" +""+ usuarioEntity.Nombre);
        }
    }
}

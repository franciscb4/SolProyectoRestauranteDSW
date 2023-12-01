using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;
using System.Linq;

namespace ProyectoRestauranteDSW.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly RestauranteContext _context;

        public AccountController(IMapper mapper, RestauranteContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuariosModel model)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Correo == model.Correo);

            if (usuario != null && usuario.Password == model.Password)
            {
                if (usuario.Rol)
                {
                    return RedirectToAction("ListPlat", "Platos");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Credenciales no válidas");
            return View();
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin (UsuariosModel model)
        {
            var existe = _context.Usuario.FirstOrDefault(u => u.Correo == model.Correo);

            if (existe == null)
            {
                var entity = _mapper.Map<UsuariosEntity>(model);

                _context.Usuario.Add(entity);
                _context.SaveChanges();

                ViewBag.Message = "Registro exitoso";

                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "El correo ya está en uso.");
            }
            return View(model);
        }
    }
}

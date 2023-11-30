using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRestauranteDSW.CustomExtensions;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoRestauranteDSW.Controllers
{
    public class RestauranteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly RestauranteContext _restauranteContext;

        public RestauranteController(
            RestauranteContext restauranteContext,
            IMapper mapper)
        {
            _restauranteContext = restauranteContext;
            _mapper = mapper;
        }
        public IActionResult MenuCatalog()
        {
            var platoListBD = _restauranteContext.Plato.ToList();
            var menuModelList = _mapper.Map<List<PlatosModel>>(platoListBD);
            return View(menuModelList);
        }

        public IActionResult MenuCatalogDetail(int id)
        {
            var platoById = _restauranteContext.Plato.SingleOrDefault(p => p.Id == id);

            if (platoById == null)
            {

                return NotFound();
            }

            var platoView = _mapper.Map<PlatosModel>(platoById);
            return View(platoView);
        }

        [HttpPost]
        public JsonResult AddTemporalProduct(PlatoTemporalModel param)
        {

            //CARGAMOS INFORMACION DEL PRODUCTO QUE INTENTAMOS AÑADIR AL CARRITO
            var productById = _restauranteContext.Plato.Where(c => c.Id == param.Id).SingleOrDefault();
            param.PlatoName = productById.NombrePlato;
            param.Total = ((int)productById.Precio);
            param.Img = productById.Imagen;

            //LISTA DE PRODUCTOS (TODOS) QUE ESTAN EN EL CARRITO
            List<PlatoTemporalModel> temporalProducts = null;

            if (HttpContext.Session.GetList<PlatoTemporalModel>("temporal") == null)
            {
                temporalProducts = new List<PlatoTemporalModel>();
            }
            else
            {
                temporalProducts = (List<PlatoTemporalModel>)HttpContext.Session.GetList<PlatoTemporalModel>("temporal");
            }
            temporalProducts.Add(param);
            HttpContext.Session.Set<List<PlatoTemporalModel>>("temporal", temporalProducts);
            return new JsonResult(new { a = 1 });
        }

        public IActionResult ConfirmOrderCar()
        {
            var model = new ConfirmCarritoModel();
            model.TemporalProducts = (List<PlatoTemporalModel>)HttpContext.Session.GetList<PlatoTemporalModel>("temporal");
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveShoppingCard(ConfirmCarritoModel modelToSave)
        {
            modelToSave.TemporalProducts = (List<PlatoTemporalModel>)HttpContext.Session.GetList<PlatoTemporalModel>("temporal");

            //GRABAR CLIENTE
            var userRegistered = _restauranteContext.Usuario.Add(new UsuariosEntity()
            {
                DNI = modelToSave.DniUs,
                Nombre = modelToSave.NombreUs,
                Apellido = modelToSave.ApellidoUs,
                Direccion = modelToSave.DirUs,
                Correo = modelToSave.CorreoUs,
                Password = modelToSave.ContraUs
            });

            foreach (var item in modelToSave.TemporalProducts)
            {
                _restauranteContext.DetalleVenta.Add(new DetalleVentaEntity()
                {
                            //Faltaria solo la zona de grabar productos Dx
                });
            }
            return RedirectToAction("MessageSuccessOrder");

        }

    }
}

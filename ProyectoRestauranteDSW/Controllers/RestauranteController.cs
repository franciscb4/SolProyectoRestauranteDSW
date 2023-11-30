using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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


        public IActionResult ConfirmOrderCar() 
        {
            return View();
        }
    }

}

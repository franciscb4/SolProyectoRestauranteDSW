using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;
using System.Linq;

namespace ProyectoRestauranteDSW.Controllers
{
    public class ReservasController : Controller
    {

        private readonly IMapper _mapper;
        private readonly RestauranteContext _restauranteContext;

        public ReservasController(
            RestauranteContext restauranteContext,
            IMapper mapper)
        {
            _restauranteContext = restauranteContext;
            _mapper = mapper;
        }

        public IActionResult AddReser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSaveActionReser(ReservacionModel reserModel)
        {
            if (ModelState.IsValid)
            {
                var reserEntity = _mapper.Map<ReservacionEntity>(reserModel);
                _restauranteContext.Reserva.Add(reserEntity);
                _restauranteContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("AddReser", reserModel);
        }

        [HttpPost]
        public IActionResult MakeReser(ReservacionEntity reserva)
        {
            
            bool mesaYaReservada = _restauranteContext.Reserva.Any(r => r.Mesa.Id == reserva.Mesa.Id
                       && r.HoraReserva == reserva.HoraReserva);

            if (mesaYaReservada)
            {
                
                return BadRequest("La mesa ya está reservada para esa hora");
            }

            
            _restauranteContext.Reserva.Add(reserva);
            _restauranteContext.SaveChanges();

            return Ok("Reserva realizada con éxito");
        }
    }

}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;
using System.Collections.Generic;
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
            var mesasDisponibles = _restauranteContext.Mesa
                             .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.NroMesa })
                             .ToList();

            ViewBag.MesasDisponibles = mesasDisponibles;

            return View();
        }

        [HttpPost]
        public IActionResult AddSaveActionReser(ReservacionModel reserModel)
        {
            if (ModelState.IsValid)
            {
                var mesasSeleccionadas = _restauranteContext.Mesa
                                            .Where(m => reserModel.IdsMesas.Contains(m.Id))
                                            .ToList();

                if (mesasSeleccionadas.Count != reserModel.IdsMesas.Count)
                {
                    ModelState.AddModelError(string.Empty, "Alguna de las mesas seleccionadas no existe");
                    reserModel.MesasDisponibles = _restauranteContext.Mesa.ToList(); // Recargar las mesas disponibles
                    return View("AddReser", reserModel);
                }

                var reservas = new List<ReservacionEntity>();

                foreach (var mesa in mesasSeleccionadas)
                {
                    var nuevaReserva = new ReservacionEntity
                    {
                        FechaReserva = reserModel.FechaReserva,
                        HoraReserva = reserModel.HoraReserva,
                        Cantidad = reserModel.Cantidad,
                        NombreCliente = reserModel.NombreCliente,
                        Mesa = mesa
                    };

                    reservas.Add(nuevaReserva);
                }

                _restauranteContext.Reserva.AddRange(reservas);
                _restauranteContext.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View("AddReser", reserModel);
        }
        /*
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
        */
    }

}

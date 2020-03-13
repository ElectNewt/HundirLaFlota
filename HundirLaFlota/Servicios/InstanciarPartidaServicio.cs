using HundirLaFlota.DTOs;
using HundirLaFlota.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HundirLaFlota.Servicios
{
    public class InstanciarPartidaServicio
    {
        private readonly BarcoServicio _barcoServicio;
        public InstanciarPartidaServicio()
        {
            _barcoServicio = new BarcoServicio();
        }

        public Tablero GenerarTablero(int tableroSize, int numeroBarcos)
        {
            List<Barco> barcos = _barcoServicio.GenerarBarcos(tableroSize, numeroBarcos);
            return new Tablero(tableroSize, barcos);
        }


        
    }

}

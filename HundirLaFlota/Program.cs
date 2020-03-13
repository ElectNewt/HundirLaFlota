using HundirLaFlota.DTOs;
using HundirLaFlota.Servicios;
using System;

namespace HundirLaFlota
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanciarPartidaServicio partidaServicio = new InstanciarPartidaServicio();
            Tablero tablero = partidaServicio.GenerarTablero(20, 6);

            tablero.DibujarTablero();

        }
    }
}

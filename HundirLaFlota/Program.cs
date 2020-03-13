using HundirLaFlota.DTOs;
using HundirLaFlota.Servicios;
using System;

namespace HundirLaFlota
{
    class Program
    {
        static void Main(string[] args)
        {
            int tableroTamano = 15;
            int numBarcos = 6;

            InstanciarPartidaServicio partidaServicio = new InstanciarPartidaServicio();
            Tablero tablero = partidaServicio.GenerarTablero(tableroTamano, numBarcos);

            tablero.DibujarTablero();

            AtaqueServicio ataque = new AtaqueServicio(tablero);
            ataque.Atacar();
        }
    }
}

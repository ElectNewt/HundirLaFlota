using HundirLaFlota.DTOs;

namespace HundirLaFlota.Servicios
{
    public class AtaqueServicio
    {

        private readonly Tablero _tablero;
        

        public AtaqueServicio(Tablero tablero)
        {
            _tablero = tablero;
        }

        /// <summary>
        /// Algoritmo para calcular la forma mas rapida de detectar todos los barcos en _tablero.Mapa
        /// </summary>
        public void Atacar()
        {

        }
    }
}

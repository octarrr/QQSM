using System;
namespace TP07{
    public class Jugador{
        public int IdJugador{get;set;}
        public string Nombre{get;set;}
        public DateTime FechaHora{get;set;}
        public int PozoGanado{get;set;}
        //public bool CSaltear{get;set;}
        public Jugador(int pIdJugador,string pNombre, DateTime pFechaHora, int pPozoGanado){
            IdJugador=pIdJugador;
            Nombre=pNombre;
            FechaHora=pFechaHora;
            PozoGanado=pPozoGanado;
        }
        public Jugador(){}
    }
}
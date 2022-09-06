using System;
namespace TP07{
    public class Pregunta{
        public int IdPregunta{get;set;}
        public string TextoPregunta{get;set;}
        public int NivelDificultad{get;set;}
        public Pregunta(int pIdPregunta, string pTextoPregunta, int pNivelDificultad){
            IdPregunta=pIdPregunta;
            TextoPregunta=pTextoPregunta;
            NivelDificultad=pNivelDificultad;
        }
        public Pregunta(){}
    }
}
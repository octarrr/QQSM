using System;
namespace TP07{
    public class Respuesta{
        public int IdRespuesta{get;set;}
        public int IdPregunta{get;set;}
        public char OpcionRespuesta{get;set;}
        public string TextoRespuesta{get;set;}
        public bool Correcta{get;set;}
        public Respuesta(int pIdRespuesta,int pIdPregunta,char pOpcionRespuesta,string pTextoRespuesta,bool pCorrecta){
            IdRespuesta=pIdRespuesta;
            IdPregunta=pIdPregunta;
            OpcionRespuesta=pOpcionRespuesta;
            TextoRespuesta=pTextoRespuesta;
            Correcta=pCorrecta;
        }
        public Respuesta(){}
    }
}
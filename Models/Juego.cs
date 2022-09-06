using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
namespace TP07{
    public static class Juego{
        private static string conexion=@"Server=A-PHZ2-CIDI-006;DataBase=QQSM;Trusted_Connection=True;";
        private static int idPreguntaActual;
        private static Jugador jug;
        public static List<Pozo> lPozo=new List<Pozo>();
        public static int posPozo;
        private static char RtaCorrecta;
        private static int pozoSeguroActual;
        private static int estadoJuego;
        public static void IniciarJuego(string n){
            string sql="INSERT INTO Jugadores VALUES(@pNombre,@pFHora,@pPGanado)";
            using(SqlConnection db=new SqlConnection(conexion)){
                db.Execute(sql,new{pNombre=n,pFHora=DateTime.Now,pPGanado=0});
            }
            jug=LevantarJugador();
            idPreguntaActual=1;
            estadoJuego=1;
            RtaCorrecta=LevantarRtaCorrecta();
            lPozo.Add(new Pozo(1000,true));
            lPozo.Add(new Pozo(2000,false));
            lPozo.Add(new Pozo(3000,false));
            lPozo.Add(new Pozo(4000,false));
            lPozo.Add(new Pozo(5000,true));
            lPozo.Add(new Pozo(6000,false));
            lPozo.Add(new Pozo(7000,false));
            lPozo.Add(new Pozo(8000,false));
            lPozo.Add(new Pozo(9000,false));
            lPozo.Add(new Pozo(10000,true));
            lPozo.Add(new Pozo(11000,false));
            lPozo.Add(new Pozo(12000,false));
            lPozo.Add(new Pozo(13000,false));
            lPozo.Add(new Pozo(14000,false));
            lPozo.Add(new Pozo(15000,false));
            lPozo.Add(new Pozo(16000,true));
            posPozo=0;
            pozoSeguroActual=0;
        }
        public static Jugador LevantarJugador(){
            string sql="SELECT TOP 1 * FROM Jugadores ORDER BY IdJugador DESC";
            Jugador j=null;
            using(SqlConnection db=new SqlConnection(conexion)){
                j=db.QueryFirstOrDefault<Jugador>(sql);
            }
            return j;
        }
        public static Pregunta LevantarPregunta(){
            string sql="SELECT * FROM Preguntas WHERE IdPregunta=@pIdPregunta";
            Pregunta p=null;
            using(SqlConnection db=new SqlConnection(conexion)){
                p=db.QueryFirstOrDefault<Pregunta>(sql,new{pIdPregunta=idPreguntaActual});
            }
            return p;
        }
        public static List<Respuesta> LevantarRespuestas(){
            string sql="SELECT * FROM Respuestas WHERE IdPregunta=@pIdPregunta";
            List<Respuesta> l=null;
            using(SqlConnection db=new SqlConnection(conexion)){
                l=db.Query<Respuesta>(sql,new{pIdPregunta=idPreguntaActual}).ToList();
            }
            return l;
        }
        public static bool ComprobarEstJuego(char r){
            bool esCorrecta;
            if(r==RtaCorrecta){
                if(lPozo[posPozo].ValorSeguro==true){
                    pozoSeguroActual=lPozo[posPozo].Importe;
                }
                jug.PozoGanado=lPozo[posPozo].Importe;
                string sqlJug="UPDATE Jugadores SET PozoGanado=@pPozo WHERE IdJugador=@pIdJugador";
                using(SqlConnection db=new SqlConnection(conexion)){
                    db.Execute(sqlJug,new{pPozo=jug.PozoGanado,pIdJugador=jug.IdJugador});
                }
                if(estadoJuego<16){
                    esCorrecta=true;
                    estadoJuego++;
                    idPreguntaActual++;
                    posPozo++;
                    RtaCorrecta=LevantarRtaCorrecta();
                }else{
                    esCorrecta=false;
                }
            }else{
                esCorrecta=false;
                jug.PozoGanado=pozoSeguroActual;
                string sqlRta="UPDATE Jugadores SET PozoGanado=@pPozo WHERE IdJugador=@pIdJugador";
                using(SqlConnection db=new SqlConnection(conexion)){
                    db.Execute(sqlRta,new{pPozo=jug.PozoGanado,pIdJugador=jug.IdJugador});
                }
            }
            return esCorrecta;
        }
        private static char LevantarRtaCorrecta(){
            char r;
            string sql="SELECT OpcionRespuesta FROM Respuestas WHERE IdPregunta=@pIdPregunta AND Correcta=1";
            using(SqlConnection db=new SqlConnection(conexion)){
                r=db.QueryFirstOrDefault<char>(sql,new{pIdPregunta=idPreguntaActual});
            }
            return r;
        }
        public static Pregunta LevantarPregAux(){
            string sql="SELECT * FROM Preguntas ORDER BY IdPregunta DESC";
            Pregunta p=null;
            using(SqlConnection db=new SqlConnection(conexion)){
                p=db.QueryFirstOrDefault<Pregunta>(sql,new{pIdPregunta=idPreguntaActual});
            }
            return p;
        }
    }
}
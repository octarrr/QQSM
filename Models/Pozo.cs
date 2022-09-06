using System;
namespace TP07{
    public class Pozo{
        public int Importe{get;set;}
        public bool ValorSeguro{get;set;}
        public Pozo(int pImporte,bool pValorSeguro){
            Importe=pImporte;
            ValorSeguro=pValorSeguro;
        }
    }
}
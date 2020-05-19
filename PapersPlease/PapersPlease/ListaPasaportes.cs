using System;
using System.Collections.Generic;

namespace PapersPlease
{
    class ListaPasaportes
    {
        List<Pasaporte> pasaportes;

        public ListaPasaportes()
        {
            pasaportes = new List<Pasaporte>();
        }
        
        public List<Pasaporte> GetListaPasaportes()
        {
            return pasaportes;
        }
        public void SetListaPasaportes(List<Pasaporte> pasaportes)
        {
            this.pasaportes = pasaportes;
        }

        public void Add(Pasaporte pasaporte)
        {
            pasaportes.Add(pasaporte);
        }
    }
}

using System;
using System.Collections.Generic;

using OpenTK.Mathematics;
namespace P_Grafica
{
    class Objeto
    {
        public Dictionary<string, Parte> partes;
        public Vector3 origen;

        public Objeto()
        {
            this.partes = new Dictionary<string, Parte>();
            this.origen = new Vector3(0, 0, 0);
        }

        public Objeto(Dictionary<string, Parte> partes, Vector3 origen)
        {
            this.partes = partes;
            this.origen = origen;
        }

        public void SetOrigen(Vector3 centro)
        {
            this.origen = centro;
        }
        public Vector3 GetOrigen()
        {
            return this.origen;
        }
        public void Add(string key, Parte p)
        {
            this.partes.Add(key, p);
        }

        public Parte GetElemento(string key)
        {
            return this.partes[key];
        }
        public void SumOrigen()
        {
            foreach (Parte parte in this.partes.Values)
            {
                parte.SumOrigen(this.origen);
            }
        }
        public void Remove(string key)
        {
            this.partes.Remove(key);
        }
        
        public void Dibujar() {

            SumOrigen();
            foreach (Parte parte in this.partes.Values)
            {
                parte.Dibujar();
            }
        
        }
    }
}

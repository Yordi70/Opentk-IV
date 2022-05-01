using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
namespace P_Grafica
{
    class Escenario
    {
        public  Dictionary<string, Objeto> objetos;
        public Vector3 centro;

        public Escenario()
        {
            this.objetos = new Dictionary<string, Objeto>();
            this.centro = new Vector3(0, 0, 0);
        }

        public Escenario(Dictionary<string, Objeto> objetos, Vector3 centro)
        {
            this.objetos = objetos;
            this.centro = centro;
        }

        public void SetCentro(Vector3 centro)
        {
            this.centro = centro;

        }
        public Vector3 GetCentro()
        {
            return this.centro;
        }

        public void Add(string key, Objeto obj)
        {
            this.objetos.Add(key, obj);
        }

        public Objeto GetElemento(string key)
        {
            return this.objetos[key];
        }

        public void Remove(string key)
        {
            this.objetos.Remove(key);
        }


        public void Dibujar()
        {
            foreach (Objeto obj in this.objetos.Values)
            {
                obj.Dibujar();
            }

        }
    }
}

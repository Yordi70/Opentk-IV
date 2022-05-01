using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
namespace P_Grafica
{
    class Parte
    {
        public Dictionary<string, Punto> puntos;
        public Vector3 centro;

        public Parte()
        {
            this.puntos = new Dictionary<string, Punto>();
            this.centro = new Vector3(0, 0, 0);
        }

        public Parte(Dictionary<string, Punto>puntos, Vector3 centro)
        {
            this.puntos = puntos;
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
        public void Add(string key, Punto p)
        {
            this.puntos.Add(key, p);
        }

        public Punto GetElemento(string key)
        {
            return this.puntos[key];
        }
        public void Remove(string key)
        {
            this.puntos.Remove(key);
        }

        public void SumOrigen(Vector3 origen)
        {
            this.centro += origen;
        }
        public int CantElements()
        {
            return this.puntos.Count * 6;
        }

        public int CantPuntos()
        {
            return this.puntos.Count;
        }
        public float[] ToArray()
        {
            List<float> _vertices = new (){ };
            foreach (Punto p in this.puntos.Values)
            {
                _vertices.Add(p.x + this.centro.X);
                _vertices.Add(p.y + this.centro.Y);
                _vertices.Add(p.z + this.centro.Y);
                _vertices.Add(p.color.X);
                _vertices.Add(p.color.Y);
                _vertices.Add(p.color.Z);
            }

            return _vertices.ToArray();
        }

        public void Dibujar() {

            GL.BufferData(BufferTarget.ArrayBuffer, this.CantElements() * sizeof(float), this.ToArray(), BufferUsageHint.StaticDraw);
            GL.DrawArrays(PrimitiveType.LineLoop, 0, this.CantPuntos());
             
        }
    }
}

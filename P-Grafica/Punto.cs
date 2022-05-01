using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace P_Grafica
{
    class Punto
    {
        public float x;
        public float y;
        public float z;
        public Vector3 color;
        public Punto() : this(0, 0, 0, new Vector3(0, 0, 0)) { }
        public Punto(float X, float Y, float Z, Vector3 Color)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
            this.color = Color;
        }

        public Punto(Vector3 vector, Vector3 Color)
        {
            this.x = vector.X;
            this.y = vector.Y;
            this.z = vector.Z;
            this.color = Color;
        }

       

    }
}

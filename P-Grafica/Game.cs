using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using P_Grafica.common;
using System.Collections.Generic;

namespace P_Grafica
{
    class Game : GameWindow
    {
        private int _vertexBufferObject;
        private int _vertexArrayObject;
        private Shader _shader;
        private Matrix4 _view;
        private Matrix4 _projection;
        public Escenario escenario;
        
        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings) { }


        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }
        protected override void OnLoad()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            ///DEFINIR LOS PUNTOS DE UN TRIANGULO
            /*Punto p1 = new Punto(0.5f,0.0f,0.0f, new Vector3(1.0f,1.0f,1.0f));
            Punto p2 = new Punto(0.0f,0.0f,0.0f, new Vector3(1.0f,1.0f,1.0f));
            Punto p3 = new Punto(0.0f,0.5f,0.0f, new Vector3(1.0f,1.0f,1.0f));
            Punto p4 = new Punto(0.5f, 0.5f, 0.0f, new Vector3(1.0f, 1.0f, 1.0f));*/

            Parte Pfrontal = new Parte(new Dictionary<string, Punto>() {
                {"p1", new Punto(-0.3f, 0.2f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p2", new Punto(0.3f,0.2f,0.3f, new Vector3(1.0f,1.0f,1.0f)) },
                {"p3", new Punto(0.3f,-0.2f,0.3f, new Vector3(1.0f,1.0f,1.0f))},
                {"p4", new Punto(-0.3f, -0.2f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f))}
            },new Vector3(0,0,0));

            Parte Pabajo = new Parte(new Dictionary<string, Punto>() {
                {"p1", new Punto(0.3f,-0.2f,0.3f, new Vector3(1.0f,1.0f,1.0f)) },
                {"p2", new Punto(-0.3f, -0.2f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                { "p3", new Punto(-0.3f, -0.2f, -0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                { "p4", new Punto(0.3f,-0.2f,-0.3f, new Vector3(1.0f,1.0f,1.0f)) }
            }, new Vector3(0,0,0));

            Parte Ptrasera = new Parte(new Dictionary<string, Punto>() {
                {"p1", new Punto(0.3f,-0.2f,-0.3f, new Vector3(1.0f,1.0f,1.0f))},
                {"p2", new Punto(-0.3f, -0.2f, -0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p3", new Punto(-0.3f, 0.2f, -0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p4", new Punto(0.3f,0.2f,-0.3f, new Vector3(1.0f,1.0f,1.0f)) }
            }, new Vector3(0,0,0));

            Parte PLDer = new Parte(new Dictionary<string, Punto>() {
                {"p1", new Punto(0.3f,-0.2f,0.3f, new Vector3(1.0f,1.0f,1.0f)) },
                {"p2", new Punto(0.3f,0.2f,0.3f, new Vector3(1.0f,1.0f,1.0f)) },
                {"p3", new Punto(0.3f,0.2f,-0.3f, new Vector3(1.0f,1.0f,1.0f)) },
                {"p4", new Punto(0.3f,-0.2f,-0.3f, new Vector3(1.0f,1.0f,1.0f)) },
            }, new Vector3(0,0,0));

            Parte PLIzq = new Parte(new Dictionary<string, Punto>(){
                {"p1", new Punto(-0.3f, 0.2f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p2", new Punto(-0.3f, 0.2f, -0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p3", new Punto(-0.3f, -0.2f, -0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p4",new Punto(-0.3f, -0.2f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) }

            }, new Vector3(0,0,0));

            Parte TIzq = new Parte(new Dictionary<string, Punto>() {
                {"p1", new Punto(0.3f,0.2f,0.3f, new Vector3(1.0f,1.0f,1.0f)) },
                {"p2",new Punto(0.0f, 0.4f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p3",new Punto(0.0f, 0.4f, -0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p4",new Punto(0.3f,0.2f,-0.3f, new Vector3(1.0f,1.0f,1.0f)) }
            }, new Vector3(0,0,0));

            Parte TDer = new Parte(new Dictionary<string, Punto>(){
                {"p1",new Punto(-0.3f, 0.2f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p2",new Punto(-0.3f, 0.2f, -0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p3",new Punto(0.0f, 0.4f, -0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p4",new Punto(0.0f, 0.4f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) }
            }, new Vector3(0,0,0));

            Parte Puerta = new Parte(new Dictionary<string, Punto>() {
                {"p1",new Punto(-0.1f, -0.2f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) },
                {"p2",new Punto(-0.1f,0.0f,0.3f, new Vector3(1.0f,1.0f,1.0f)) },
                {"p3",new Punto(0.1f,0.0f,0.3f, new Vector3(1.0f,1.0f,1.0f)) },
                {"p4",new Punto(0.1f, -0.2f, 0.3f, new Vector3(1.0f, 1.0f, 1.0f)) }
            }, new Vector3(0,0,0));

            Objeto casa = new Objeto();
            casa.SetOrigen(new Vector3(0,0,0));
            casa.Add("Pabajo",Pabajo);
            casa.Add("Ptrasera", Ptrasera);
            casa.Add("PLDer", PLDer);
            casa.Add("PLIzq", PLIzq);
            casa.Add("TIzq", TIzq);
            casa.Add("TDer", TDer);
            casa.Add("Puerta",Puerta);

            escenario = new Escenario();
            escenario.Add("casa", casa);


            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);


            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();


            _view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            //_projection = Matrix4.CreateOrthographicOffCenter(-1f, 1f, -1f, 1f, 0.1f, 100.0f);
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);
            base.OnLoad();
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.BindVertexArray(_vertexArrayObject);
            var model = Matrix4.Identity * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(45.0f));

            _shader.Use();
            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", _view);
            _shader.SetMatrix4("projection", _projection);
            escenario.Dibujar();
            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }

        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(_vertexBufferObject);

            GL.DeleteProgram(_shader.Handle);


            base.OnUnload();
        }
    }
}

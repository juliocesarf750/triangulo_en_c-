using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace triangulo_hola_mundo
{
     
    public class game : GameWindow
    {
        private int vertexbuffer;
        private int shaderProgramHandle;
        private int vertexArrayHandle;

        

        public game(): base(GameWindowSettings.Default, NativeWindowSettings.Default)
       
        {
            this.CenterWindow(new Vector2i(1200,720));
            this.RenderFrequency = 60;
            this.UpdateFrequency = 60;

        }

        protected override void OnResize(ResizeEventArgs e)
        {   //para ajustarse a la pantalla
            GL.Viewport(0,0,e .Width,e.Height);
            base.OnResize(e);
        }


        //carga
        protected override void OnLoad()
        {   
            GL.ClearColor(new Color4(0.3f, 0.1f, 0.5f, 1f));

            float[] vertices = new float[]
            {
                0.0f,0.5f,0f,       //vertise 1
                0.5f,-0.5f,0f,      //vertise 2
                -0.5f,-0.5f,0f         //vertice 3
            };

            this.vertexbuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexbuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);  

            this.vertexArrayHandle = GL.GenVertexArray();
            GL.BindVertexArray(this.vertexArrayHandle);

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexbuffer);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.BindVertexArray(0);


            string vertexShaderCode =
                @"#version 330 core
                 
                layout (location = 0) in vec3 aPosition;

                 void main()
                {
                    gl_Position = vec4(aPosition, 1.0);
                }
                ";


            string pixelShaderCode =
                @"#version 330 core
                 
                 out vec4 FragColor;

                 void main()
                {
                    FragColor = vec4(0.3f,0.5f,1.5f,1.5f);
                }
                ";
                
                

            int vertextShaderhandle = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertextShaderhandle, vertexShaderCode);
            GL.CompileShader(vertextShaderhandle);

            int pixelShanderHandle = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(pixelShanderHandle, pixelShaderCode);
            GL.CompileShader(pixelShanderHandle);

            this.shaderProgramHandle = GL.CreateProgram();

            GL.AttachShader(this.shaderProgramHandle, vertextShaderhandle);
            GL.AttachShader(this.shaderProgramHandle, pixelShanderHandle);


            GL.LinkProgram(this.shaderProgramHandle);

            GL.DetachShader(this.shaderProgramHandle, vertextShaderhandle);
            GL.DetachShader(this.shaderProgramHandle, pixelShanderHandle);


            GL.DeleteShader(vertextShaderhandle);
            GL.DeleteShader(pixelShanderHandle);


            


            base.OnLoad();
        }

        //para limpiar los buffers
        //descarga
        protected override void OnUnload()
        {   
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(this.vertexbuffer);

            GL.UseProgram(0);
            GL.DeleteProgram(this.shaderProgramHandle);


            base.OnUnload();
        }


        //en marco de actualizacion
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            
           
            base.OnUpdateFrame(args);
        }


        //en marco de renderizado
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.UseProgram(this.shaderProgramHandle);
            GL.BindVertexArray(this.vertexArrayHandle);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            this.Context.SwapBuffers();
            base.OnRenderFrame(args);
        }

    }
    

     
}

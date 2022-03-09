using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenTK.Graphics.ES20;
using OpenTK.Mathematics;
using OpenTK.Wpf;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;
    /*Severity Code    Description Project	File	Line	Suppression State
Error	MC3074	The tag 'SKElement' does not exist in XML namespace 'clr-namespace:SkiaSharp.Views.WPF'. Line 12 Position 10.	TestSkiasharp E:\c_sharp_projects\GraphEditorTesting\TestSkiasharp\TestSkiasharp\MainWindow.xaml	12	*/

namespace TestSkiasharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        SKColorType colorType = SKColorType.Rgba8888;

        //SKSurface surface;

        int width = 500;
        int height = 500;
        public MainWindow() {
            InitializeComponent();

            OpenTkControl.Start(new GLWpfControlSettings());

            /*width = (int)OpenTkControl.Width;
            height = (int)OpenTkControl.Height;*/


        }

        private void OpenTkControl_OnRender(TimeSpan delta) {

            GRContext contextOpenGL = GRContext.Create(GRBackend.OpenGL, GRGlInterface.CreateNativeGlInterface());

            GL.GetInteger(GetPName.FramebufferBinding, out var framebuffer);
            GRGlFramebufferInfo glInfo = new GRGlFramebufferInfo((uint)framebuffer, colorType.ToGlSizedFormat());
            GL.GetInteger(GetPName.StencilBits, out var stencil);
            GRBackendRenderTarget renderTarget = new GRBackendRenderTarget(width, height, contextOpenGL.GetMaxSurfaceSampleCount(colorType), stencil, glInfo);

            SKSurface surface = surface = SKSurface.Create(contextOpenGL, renderTarget, GRSurfaceOrigin.BottomLeft, colorType);

            surface.Canvas.Clear(SKColor.Parse("#00FF00"));

            RenderTest(surface);
            //   surface.Canvas.Flush();
            //   glControl1.SwapBuffers();

            // prevent memory access violations by disposing before exiting
            renderTarget?.Dispose();
            contextOpenGL?.Dispose();
            surface?.Dispose();
        }

        private void RenderTest(SKSurface surface) {


            byte alpha = 128;
            var paint = new SKPaint();
            paint.StrokeWidth = 5;
            paint.IsAntialias = true;

            for (int i = 0; i < 1_000; i++)
            {

                float x1 = (float)(rand.NextDouble() * width);
                float x2 = (float)(rand.NextDouble() * width);
                float y1 = (float)(rand.NextDouble() * height);
                float y2 = (float)(rand.NextDouble() * height);

                paint.Color = new SKColor(
                    red: (byte)(rand.NextDouble() * 255),
                    green: (byte)(rand.NextDouble() * 255),
                    blue: (byte)(rand.NextDouble() * 255),
                    alpha: alpha
                );


                surface.Canvas.DrawLine(x1, y1, x2, y2, paint);
            }

        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			// the the canvas and properties
			var canvas = e.Surface.Canvas;

            //Control sctl = (Control)sender;
            width = e.Info.Width;
            height = e.Info.Height;

            // make sure the canvas is blank
            canvas.Clear(SKColors.White);


            /*GRContext contextOpenGL = GRContext.Create(GRBackend.OpenGL, GRGlInterface.CreateNativeGlInterface());

            GL.GetInteger(GetPName.FramebufferBinding, out var framebuffer);
            GRGlFramebufferInfo glInfo = new GRGlFramebufferInfo((uint)framebuffer, colorType.ToGlSizedFormat());
            GL.GetInteger(GetPName.StencilBits, out var stencil);
            GRBackendRenderTarget renderTarget = new GRBackendRenderTarget(width, height, contextOpenGL.GetMaxSurfaceSampleCount(colorType), stencil, glInfo);

            SKSurface surface = SKSurface.Create(contextOpenGL, renderTarget, GRSurfaceOrigin.BottomLeft, colorType);*/

            // Draw some stuff on the canvas

           // surface.Canvas.Clear(SKColor.Parse("#FFFFFF")); // adds about 3ms fullscreen

            byte alpha = 128;
            var paint = new SKPaint();
            paint.StrokeWidth = 5;
            paint.IsAntialias = true;

            // surface.isCompatible


            for (int i = 0; i < 1_0000; i++)
            {
                float x1 = (float)(rand.NextDouble() * width);
                float x2 = (float)(rand.NextDouble() * width);
                float y1 = (float)(rand.NextDouble() * height);
                float y2 = (float)(rand.NextDouble() * height);

                paint.Color = new SKColor(
                    red: (byte)(rand.NextDouble() * 255),
                    green: (byte)(rand.NextDouble() * 255),
                    blue: (byte)(rand.NextDouble() * 255),
                    alpha: alpha
                );


                canvas.DrawLine(x1, y1, x2, y2, paint);
                // surface.Canvas.DrawCircle(x1, y1, 40, paint);
            }

            /*surface.Canvas.Flush();
            glControl1.SwapBuffers();

            // prevent memory access violations by disposing before exiting
            renderTarget?.Dispose();
            contextOpenGL?.Dispose();
            surface?.Dispose();*/




            // draw some text
            /*            var paint = new SKPaint
                        {
                            Color = SKColors.Black,
                            IsAntialias = true,
                            Style = SKPaintStyle.Fill,
                            TextAlign = SKTextAlign.Center,
                            TextSize = 24
                        };
                        var coord = new SKPoint(e.Info.Width / 2, (e.Info.Height + paint.TextSize) / 2);
                        canvas.DrawText("SkiaSharp", coord, paint);*/
        }
	}
}

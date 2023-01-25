using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitware.VTK;

namespace ArrowSourceTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrowSourceTest1();
        }

        public static void ArrowSourceTest1()
        {
            vtkArrowSource arrow = vtkArrowSource.New();

            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(arrow.GetOutputPort());

            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            actor.GetProperty().SetColor(0, 1, 0);
            actor.GetProperty().SetOpacity(0.5);
            actor.GetProperty().SetPointSize(1);
            actor.GetProperty().SetLineWidth(1);

            actor.GetProperty().SetRepresentationToSurface(); // points, surface, wireframe
            //actor.GetProperty().SetRepresentationToWireframe();
            //actor.GetProperty().SetRepresentationToPoints();
            //actor.GetProperty().SetTexture(pTexture);  // vtkTexture(Texture Mapping)
            actor.GetProperty().BackfaceCullingOn();
            actor.GetProperty().LightingOn();
            actor.GetProperty().ShadingOn();

            vtkRenderer renderer = vtkRenderer.New();
            renderer.AddActor(actor);
            renderer.SetBackground(.1, .2, .3);
            renderer.ResetCamera();

            vtkRenderWindow renderWin = vtkRenderWindow.New();
            renderWin.AddRenderer(renderer);

            vtkRenderWindowInteractor interactor = vtkRenderWindowInteractor.New();
            interactor.SetRenderWindow(renderWin);

            renderWin.Render();
            interactor.Start();

        }
    }
}

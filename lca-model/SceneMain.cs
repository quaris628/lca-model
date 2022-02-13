using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using phi.graphics;
using phi.control;
using phi.io;
using phi.graphics.renderables;
using phi.graphics.drawables;
using lca_model.model;
using lca_model.ui;

namespace lca_model
{
   public class SceneMain : Scene
   {
      private readonly Text TITLE = new Text.TextBuilder("LCA Model").Build();
      private const Keys BACK_KEY = Keys.Escape;

      private readonly Drawable WORK_AREA = new RectangleDrawable(200, 100,
         LCAPhiConfig.Window.WIDTH - 200, LCAPhiConfig.Window.HEIGHT - 100)
         .SetColor(Color.White);

      private readonly Process[] processes;
      private readonly Flow flow;
      
      public SceneMain(Scene prevScene) : base(prevScene, new ImageWrapper(LCAPhiConfig.Render.DEFAULT_BACKGROUND))
      {
         processes =  new Process[] {
               new Process("Test", 200, 200, WORK_AREA.GetBoundaryRectangle()),
               new Process("Test 2", 200, 400, WORK_AREA.GetBoundaryRectangle()),
         };
         flow = new Flow(600, 200, 700, 260);
      }

      protected override void InitializeMe()
      {
         IO.KEYS.Subscribe(Back, BACK_KEY);
         

         IO.RENDERER.Add(TITLE, 0);
         IO.RENDERER.Add(WORK_AREA, 0);
         foreach (Process p in processes)
         {
            IO.RENDERER.Add(p.GetDrawable(), 1);
            p.Initialize();
         }

         foreach (Drawable d in flow.GetDrawables())
         {
            IO.RENDERER.Add(d, 2);
         }
         flow.Initialize();

      }


   }
}

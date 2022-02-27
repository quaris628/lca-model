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
using phi.other;
using lca_model.model;
using lca_model.ui;

namespace lca_model
{
   public class SceneMain : Scene
   {
      private readonly Text TITLE = new Text.TextBuilder("LCA Model").Build();
      private const Keys BACK_KEY = Keys.Escape;

      private WorkArea workArea;

      public SceneMain(Scene prevScene) : base(prevScene,
         new ImageWrapper(LCAPhiConfig.Render.DEFAULT_BACKGROUND))
      {
         workArea = new WorkArea();
         Process test1 = new Process.ProcessBuilder(workArea)
            .WithName("Test One").WithXY(300, 400).Build();
         Process test2 = new Process.ProcessBuilder(workArea)
            .WithName("Test Two").WithXY(300, 450).Build();
         workArea.Add(test1);
         workArea.Add(test2);
         workArea.Add(new Flow(workArea, 400, 400, 460, 430));
      }

      protected override void InitializeMe()
      {
         IO.KEYS.Subscribe(Back, BACK_KEY);
         
         IO.RENDERER.Add(TITLE, 0);
         IO.RENDERER.Add(workArea.GetDrawables(), 0);

         workArea.Initialize();
         

      }


   }
}

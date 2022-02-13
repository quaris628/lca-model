using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.graphics.drawables;
using phi.graphics.renderables;
using phi.other;

namespace lca_model.ui
{
   public class Process : Draggable
   {
      //private static Drawable drawable = new RectangleDrawable(0, 0, 100, 50).SetColor();

      public Process(string name, int x, int y, Rectangle drawBounds) : base(new ProcessDrawable(name, x, y), drawBounds)
      {

      }

   }
}

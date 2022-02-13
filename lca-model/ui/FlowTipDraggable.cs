using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.graphics.drawables;
using phi.graphics.renderables;

namespace lca_model.ui
{
   public class FlowTipDraggable : Draggable
   {
      public const int SQUARE_SIZE = 20;

      private Line connector;
      private bool attachedAtStart; // else attached at end

      public FlowTipDraggable(Line connector, bool attachedAtStart, int x, int y)
         : base(new RectangleDrawable(x - SQUARE_SIZE / 2, y - SQUARE_SIZE / 2,
            SQUARE_SIZE, SQUARE_SIZE))
      {
         this.connector = connector;
         this.attachedAtStart = attachedAtStart;
      }

      protected override void MyMouseDown(int x, int y)
      {
         // overwrites default draggable positioning method
         GetDrawable().SetCenterXY(x, y);
      }

      protected override void MyMouseMove(int x, int y)
      {
         // overwrites default draggable positioning method
         GetDrawable().SetCenterXY(x, y);
         if (attachedAtStart)
         {
            connector.SetXY1(x, y);
         }
         else
         {
            connector.SetXY2(x, y);
         }
      }

   }
}

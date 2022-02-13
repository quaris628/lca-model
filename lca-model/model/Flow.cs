using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.graphics.renderables;
using lca_model.ui;
using phi.graphics.drawables;

namespace lca_model.model
{
   public class Flow : MultiRenderable
   {
      private FlowTipDraggable inTip;
      private FlowTipDraggable outTip;
      private Line connector;

      public Flow(int inX, int inY, int outX, int outY)
      {
         connector = new Line(inX, inY, outX, outY);
         inTip = new FlowTipDraggable(connector, true, inX, inY);
         outTip = new FlowTipDraggable(connector, false, outX, outY);
         
      }

      public void Initialize()
      {
         inTip.Initialize();
         outTip.Initialize();
      }

      public IEnumerable<Drawable> GetDrawables()
      {
         yield return inTip.GetDrawable();
         yield return outTip.GetDrawable();
         yield return connector;
      }
   }
}

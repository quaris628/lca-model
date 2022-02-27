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
      private WorkArea workArea;

      public Flow(WorkArea workArea, int inX, int inY, int outX, int outY)
      {
         connector = new Line(inX, inY, outX, outY);
         inTip = new FlowTipDraggable(workArea, connector, true, inX, inY);
         outTip = new FlowTipDraggable(workArea, connector, false, outX, outY);
         this.workArea = workArea;
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

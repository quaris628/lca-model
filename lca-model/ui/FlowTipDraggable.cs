using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.graphics.drawables;
using phi.graphics.renderables;
using lca_model.model;

namespace lca_model.ui
{
   public class FlowTipDraggable : Draggable
   {
      public const int SQUARE_SIZE = 20;
      public static readonly Color UNATTACHED_COLOR = Color.DarkGray;
      public static readonly Color ATTACHED_COLOR = Color.LightGray;

      private WorkArea workArea;
      private Line connector;
      private bool attachedAtStart; // else, this tip is attached at the connector's end

      public FlowTipDraggable(WorkArea workArea, Line connector, bool attachedAtStart, int x, int y)
         : base(new RectangleDrawable(x - SQUARE_SIZE / 2, y - SQUARE_SIZE / 2,
            SQUARE_SIZE, SQUARE_SIZE).SetColor(UNATTACHED_COLOR))
      {
         this.workArea = workArea;
         this.connector = connector;
         this.attachedAtStart = attachedAtStart;
      }

      // overwrites the default draggable positioning method
      protected override void MyMouseDown(int x, int y) { PositionElements(x, y); }
      protected override void MyMouseMove(int x, int y) { PositionElements(x, y); }
      protected override void MyMouseUp(int x, int y)
      {
         // determine if released over a process
         foreach (Process process in workArea.GetProcesses())
         {
            if (process.GetDrawable().GetBoundaryRectangle().Contains(x, y))
            {
               ((PenDrawable)GetDrawable()).SetColor(ATTACHED_COLOR);
               ProcessDrawable procDraw = (ProcessDrawable)process.GetDrawable();
               int snapX;
               int snapY = procDraw.GetIOsY();
               if (attachedAtStart)
               {
                  snapX = procDraw.GetOutputsX();
                  connector.SetXY1(snapX, snapY);
               }
               else
               {
                  snapX = procDraw.GetInputsX();
                  connector.SetXY2(snapX, snapY);
               }
               GetDrawable().SetCenterXY(snapX, snapY);
            }
         }
      }

      private void PositionElements(int x, int y)
      {
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

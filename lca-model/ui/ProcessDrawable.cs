using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.graphics.drawables;
using System.Drawing;

namespace lca_model.ui
{
   public class ProcessDrawable : Drawable
   {
      public const int WIDTH = 100;
      public const int HEIGHT = 35;
      public const int SIDES_WIDTH = 10;

      private readonly Color SIDE_COLOR = Color.LightGray;
      private readonly Color BODY_COLOR = Color.DarkGray;

      private Drawable inputs;
      private Drawable body;
      private Drawable outputs;
      private Text bodyText;

      public ProcessDrawable(string name, int x, int y) : base(x, y, WIDTH, HEIGHT)
      {
         inputs = new RectangleDrawable(x, y, SIDES_WIDTH, HEIGHT).SetColor(SIDE_COLOR);
         body = new RectangleDrawable(x + SIDES_WIDTH, y, WIDTH - 2 * SIDES_WIDTH, HEIGHT).SetColor(BODY_COLOR);
         outputs = new RectangleDrawable(x + WIDTH - SIDES_WIDTH, y, SIDES_WIDTH, HEIGHT).SetColor(SIDE_COLOR);
         bodyText = new Text.TextBuilder(name).WithFontSize(10f).Build();
         bodyText.SetCenterXY(x + WIDTH / 2, y + HEIGHT / 2);
      }

      protected override void DrawAt(Graphics g, int x, int y)
      {
         SetElementsPositions();
         inputs.Draw(g);
         body.Draw(g);
         outputs.Draw(g);
         bodyText.Draw(g);
      }

      private void SetElementsPositions()
      {
         inputs.SetXY(GetX(), GetY());
         body.SetXY(GetX() + SIDES_WIDTH, GetY());
         outputs.SetXY(GetX() + WIDTH - SIDES_WIDTH, GetY());
         bodyText.SetCenterXY(GetX() + WIDTH / 2, GetY() + HEIGHT / 2);
      }

      public int GetInputsX() { return GetX() + SIDES_WIDTH / 2; }
      public int GetOutputsX() { return GetX() + WIDTH - SIDES_WIDTH / 2; }
      public int GetIOsY() { return GetY() + HEIGHT / 2; }
   }
}

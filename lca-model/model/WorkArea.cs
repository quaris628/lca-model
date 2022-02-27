using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.graphics.drawables;
using phi.other;

namespace lca_model.model
{
   public class WorkArea : MultiRenderable
   {
      public const int X_POS = 200;
      public const int Y_POS = 100;
      public readonly Color COLOR = Color.White;

      private List<Flow> flows;
      private List<Process> processes;
      private Drawable background;

      public WorkArea()
      {
         this.flows = new List<Flow>();
         this.processes = new List<Process>();
         this.background = new RectangleDrawable(X_POS, Y_POS,
            LCAPhiConfig.Window.WIDTH - X_POS, LCAPhiConfig.Window.HEIGHT - Y_POS)
            .SetColor(COLOR);
      }

      public void Initialize()
      {
         foreach (Flow flow in flows)
         {
            flow.Initialize();
         }
         foreach (Process p in processes)
         {
            p.Initialize();
         }
      }

      // implement MultiRenderable
      public IEnumerable<Drawable> GetDrawables()
      {
         foreach (Flow f in flows)
         {
            foreach (Drawable d in f.GetDrawables())
            {
               yield return d;
            }
         }
         foreach (Process p in processes)
         {
            yield return p.GetDrawable();
         }
         // must be returned last so it's added to the renderer last,
         // making it behind all the other drawables
         yield return background;
      }

      // Simple Setters/Getters, etc
      public WorkArea Add(Flow flow) { flows.Add(flow); return this; }
      public WorkArea Remove(Flow flow) { flows.Remove(flow); return this; }
      public IEnumerable<Flow> GetFlows() { return flows; }
      public WorkArea Add(Process process) { processes.Add(process); return this; }
      public WorkArea Remove(Process process) { processes.Remove(process); return this; }
      public IEnumerable<Process> GetProcesses() { return processes; }
      public Drawable GetBackground() { return background; }

   }
}

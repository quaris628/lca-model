using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.graphics.drawables;
using phi.graphics.renderables;
using phi.other;
using lca_model.ui;
using lca_model.db;

namespace lca_model.model
{
   public class Process : Draggable
   {
      // TODO when I drag, bring the flow tips with me

      private string name;
      private List<Flow> ins;
      private List<Flow> outs;
      // TODO quantities of ins and outs
      // TODO scale of process (make 1 sandwich, make 2 sandwiches, etc)
      private WorkArea workArea;

      private Process(ProcessBuilder b)
            : base(new ProcessDrawable(b.GetName(), b.GetX(), b.GetY()),
            b.GetWorkArea().GetBackground().GetBoundaryRectangle())
      {
         this.name = b.GetName();
         this.ins = b.GetIns();
         this.outs = b.GetOuts();
         this.workArea = b.GetWorkArea();
      }

      // Getters / Setters
      public Process AddIn(Flow flowType) { ins.Add(flowType); return this; }
      public Process AddOut(Flow flowType) { outs.Add(flowType); return this; }
      public Process RemoveIn(Flow flowType) { ins.Remove(flowType); return this; }
      public Process RemoveOut(Flow flowType) { outs.Remove(flowType); return this; }
      public IEnumerable<Flow> GetIns() { return ins; }
      public IEnumerable<Flow> GetOuts() { return outs; }

      // Builder Pattern
      public class ProcessBuilder
      {
         private string name;
         private List<Flow> ins;
         private List<Flow> outs;
         // TODO in quantities, out quantities
         private WorkArea workArea;
         private int x, y;

         public ProcessBuilder(WorkArea workArea)
         {
            this.name = "Process " + (workArea.GetProcesses().Count() + 1);
            this.ins = new List<Flow>();
            this.outs = new List<Flow>();
            this.workArea = workArea;
            this.x = workArea.GetBackground().GetCenterX();
            this.y = workArea.GetBackground().GetCenterY();
         }

         public ProcessBuilder WithName(string name) { this.name = name; return this; }
         public ProcessBuilder WithIn(Flow flowType) { this.ins.Add(flowType); return this; }
         public ProcessBuilder WithOut(Flow flowType) { this.outs.Add(flowType); return this; }
         public ProcessBuilder WithXY(int x, int y) { return this.WithX(x).WithY(y); }
         public ProcessBuilder WithX(int x) { this.x = x; return this; }
         public ProcessBuilder WithY(int y) { this.y = y; return this; }

         public string GetName() { return name; }
         public List<Flow> GetIns() { return ins; }
         public List<Flow> GetOuts() { return outs; }
         public WorkArea GetWorkArea() { return workArea; }
         public int GetX() { return x; }
         public int GetY() { return y; }

         public Process Build() { return new Process(this); }
      }
   }
}

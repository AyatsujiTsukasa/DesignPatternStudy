namespace Takumi.TestCodeStudy.CommandPatternUndo
{
   
    public class Command
    {
        public virtual void Execute(GameUnit unit) { }
        public virtual void Undo() { }
    }
}
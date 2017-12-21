namespace Takumi.TestCodeStudy.CommandPattern{

public class Command
    {
        public virtual void Execute(IGameActor actor) { }
        public virtual void Undo() { }
    }
}
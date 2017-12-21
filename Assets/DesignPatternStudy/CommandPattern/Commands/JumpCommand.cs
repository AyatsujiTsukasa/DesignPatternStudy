namespace Takumi.TestCodeStudy.CommandPattern.Commands
{
    public class JumpCommand : Command
    {
        public override void Execute(IGameActor actor)
        {
            base.Execute(actor);
            actor.Jump();
        }
    }
}

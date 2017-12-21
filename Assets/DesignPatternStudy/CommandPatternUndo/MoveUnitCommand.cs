namespace Takumi.TestCodeStudy.CommandPatternUndo
{
    using UnityEngine;
    using Takumi.TestCodeStudy;

    public class MoveUnitCommand : Command
    {

        GameUnit unit;
        int x;
        int y;
        int x_before, y_before;

        public MoveUnitCommand(GameUnit unit, int x, int y)
        {
            this.unit = unit;
            this.x = x;
            this.y = y;
        }

        public override void Execute(GameUnit unit)
        {
            base.Execute(unit);
            x_before = (int)((Component)unit).transform.position.x;
            y_before = (int)((Component)unit).transform.position.z;
            ((Component)unit).transform.position = new Vector3(x, 0, y);
        }

        public override void Undo()
        {
            ((Component)unit).transform.position = new Vector3(x_before, 0, y_before);
        }
    }

}
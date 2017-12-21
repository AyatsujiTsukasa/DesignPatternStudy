namespace Takumi.TestCodeStudy.CommandPatternUndo{
    using UnityEngine;
    using System.Collections.Generic;

    public class CommandInputHandlerUndo : MonoBehaviour
    {
        public int historyCount = 5;
        public GameUnit unit;
        List<Command> commandHistory;
        public int commandIndex = -1;

        // Use this for initialization
        void Start()
        {
            commandHistory = new List<Command>(historyCount);
        }

        // Update is called once per frame
        void Update()
        {
            var command = HandleInput();
            if (command != null){
                Debug.Log("Execute");
                command.Execute(unit);
                if (commandIndex != commandHistory.Count-1){
                    commandHistory.RemoveRange(commandIndex + 1, commandHistory.Count - commandIndex - 1);
                }
                commandHistory.Add(command);
                if (commandHistory.Count > historyCount){
                    commandHistory.RemoveAt(0);
                }
                commandHistory.TrimExcess();
                commandIndex = commandHistory.Count - 1;
            }
        }

        Command HandleInput(){
            if (unit == null) return null;
            if (Input.GetKeyDown(KeyCode.D))
            {
                int destX = (int)(unit.transform.position.x + 1);
                return new MoveUnitCommand(unit, destX, (int)unit.transform.position.z);
            } 
            else if (Input.GetKeyDown(KeyCode.A))
            {
                int destX = (int)(unit.transform.position.x - 1);
                return new MoveUnitCommand(unit, destX, (int)unit.transform.position.z);
            } 
            else if (Input.GetKeyDown(KeyCode.S))
            {
                int destY = (int)(unit.transform.position.z - 1);
                return new MoveUnitCommand(unit, (int)unit.transform.position.x, destY);
            } 
            else if (Input.GetKeyDown(KeyCode.W))
            {
                int destY = (int)(unit.transform.position.z + 1);
                return new MoveUnitCommand(unit, (int)unit.transform.position.x, destY);
            }
            return null;
        }

        public void ExecuteUndo(){
            if (commandIndex >= 0){
                Debug.Log("Undo");
                commandHistory[commandIndex].Undo();
                commandIndex--;
            }
        }

        public void ExecuteRedo(){
            if (commandIndex < commandHistory.Count - 1)
            {
                Debug.Log("Redo");
                commandHistory[commandIndex + 1].Execute(unit);
                commandIndex++;
            }
        }

    }

}
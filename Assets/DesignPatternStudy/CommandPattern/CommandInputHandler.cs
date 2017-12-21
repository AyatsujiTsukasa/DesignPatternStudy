namespace Takumi.TestCodeStudy.CommandPattern{

    using Takumi.TestCodeStudy.CommandPattern.Commands;
    using System.Collections.Generic;
    using UnityEngine;

    public class CommandInputHandler : MonoBehaviour
    {

        Command WButton = new JumpCommand();
        public List<GameObject> go_actors;
        private List<IGameActor> actors;

        // Use this for initialization
        void Start()
        {
            actors = new List<IGameActor>();
            SetActors();
        }

        void SetActors()
        {
            foreach (var x in go_actors)
            {
                var actor = x.GetComponent(typeof(IGameActor));
                if (actor != null)
                {
                    actors.Add((IGameActor)actor);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            var command = HandleInput();
            if (command != null && actors != null)
            {
                foreach (var actor in actors)
                {
                    command.Execute(actor);
                }
            }
        }

        Command HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                return WButton;
            }
            return null;
        }
    }
}

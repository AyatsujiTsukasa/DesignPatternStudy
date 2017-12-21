namespace Takumi.TestCodeStudy
{
    using UnityEngine;

    public class NormalGameActor : MonoBehaviour, IGameActor
    {
        public virtual void Jump()
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
        }
    }
}
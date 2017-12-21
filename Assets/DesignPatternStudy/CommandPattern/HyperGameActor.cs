using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperGameActor : MonoBehaviour, IGameActor
{
    void IGameActor.Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public abstract class ActorController : MonoBehaviour
{
    public virtual void Init() 
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.3f);
    }
}

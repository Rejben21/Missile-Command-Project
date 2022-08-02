using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float timeToDestroy;

    public void SelfDestry()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
}

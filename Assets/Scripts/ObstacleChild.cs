using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChild : MonoBehaviour
{

    void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject, 1);
    }
}

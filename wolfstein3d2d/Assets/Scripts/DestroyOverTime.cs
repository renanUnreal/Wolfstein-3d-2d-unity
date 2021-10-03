using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField]
    private float overTime;
    void Start()
    {
        Destroy(this.gameObject, overTime);
    }
}

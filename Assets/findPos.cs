using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPos : MonoBehaviour
{
    Transform[] ts;
    void Start()
    {
        ts = gameObject.GetComponentsInChildren<Transform>();
    }
    public Transform[] GetTransform()
    {
        return ts;
    }
}

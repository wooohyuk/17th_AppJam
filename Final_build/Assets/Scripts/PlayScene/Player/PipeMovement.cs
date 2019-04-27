using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour {

    public Vector3 dirVector;

    void Update()
    {
        dirVector.z = 0f;
        transform.position += dirVector * 0.25f;
    }

}

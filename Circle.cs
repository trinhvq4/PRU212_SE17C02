using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    float step = 0.02f;
    Vector3 parentPosition;
    // Start is called before the first frame update
    void Start()
    {
        parentPosition = transform.parent.position;
        Debug.Log(parentPosition);
    }

    // Update is called once per frame
    void Update()
    {
        parentPosition = transform.parent.position;
        transform.RotateAround(parentPosition, Vector3.forward, 20 * step);
    }
}

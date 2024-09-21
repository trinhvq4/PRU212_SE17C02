using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    #region Fields

    Vector3 position;
    [SerializeField]
    float step = 0.01f;
    float direction = 1f;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // store position information of game object to position variable
        position = transform.position;
        Debug.Log(position);
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        if(position.x < -8f || position.x > 8f) direction *= -1f;
        position.x -= direction * step;
        transform.position = position;
    }

    #endregion
}

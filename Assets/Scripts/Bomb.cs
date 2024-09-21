using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Vector2 force = new Vector2(-1f, 1f);
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        float magnitude = Random.Range(4f, 10.0f);
        float angle = Random.Range(0f, 360.0f) * Mathf.Deg2Rad;
        float Fx = magnitude * Mathf.Cos(angle);
        float Fy = magnitude * Mathf.Sin(angle);
        force = new Vector2(Fx, Fy);

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour
{
    #region Fields
    Vector2 force = new Vector2(-1f, 1f);

    Rigidbody2D rb2d; // create variable to store rigidbody2d information

    [SerializeField]
    GameObject explosionPrefab;

    float lifeTime = 41f;
    float elapseTime = 0f;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite[] spriteTeddy = new Sprite[3];
    int spriteIdx = 0;

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        float magnitude = Random.Range(4f, 10.0f);
        float angle = Random.Range(0f, 360.0f) * Mathf.Deg2Rad;
        float Fx = magnitude * Mathf.Cos(angle);
        float Fy = magnitude * Mathf.Sin(angle);
        force = new Vector2(Fx, Fy);
        // access rigidbody2d of the game object
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.AddForce(force, ForceMode2D.Impulse);

        //fetch SpritRenderer to spriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        elapseTime += Time.deltaTime;
        if (elapseTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Main Camera")
        {
            //Debug.Log("Teddy collides with wall");
            spriteIdx = (spriteIdx + 1) % 3;
            spriteRenderer.sprite = spriteTeddy[spriteIdx];
        }

        if(coll.gameObject.name.Contains("bomb"))
        {
            Vector3 bombPos = coll.gameObject.transform.position;
            Destroy(coll.gameObject);
            Instantiate(explosionPrefab, bombPos, Quaternion.identity);
            Vector3 teddyPos = transform.position;
            Destroy(gameObject);
            Instantiate(explosionPrefab, teddyPos, Quaternion.identity);
        }
    }
    #endregion
}

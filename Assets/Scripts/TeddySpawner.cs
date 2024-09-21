using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddySpawner : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject teddyPrefab;

    protected float spawnTime = 5f;
    float elapseTime = 0f;

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(teddyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SetParas();
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime
        elapseTime += Time.deltaTime;
        if(elapseTime > spawnTime)
        {
            Instantiate(teddyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            elapseTime = 0f;
        }
    }

    virtual public void SetParas()
    {
        spawnTime = 5f;
    }
    #endregion
}

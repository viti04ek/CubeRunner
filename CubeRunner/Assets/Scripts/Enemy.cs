using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;


    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(0, 0, -Speed * Time.deltaTime);

        if (transform.position.z < -10f)
            Destroy(gameObject);
    }
}

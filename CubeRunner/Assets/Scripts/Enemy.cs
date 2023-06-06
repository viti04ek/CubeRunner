using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;

    
    void Update()
    {
        transform.Translate(0, 0, -Speed * Time.deltaTime);

        if (transform.position.z < -10f)
        {
            GameManager.Instance.ScoreUp();
            Destroy(gameObject);
        }
    }
}

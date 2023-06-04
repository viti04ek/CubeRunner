using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float DodgeSpeed;
    private float _xInput;


    void Start()
    {
        
    }

    
    void Update()
    {
        _xInput = Input.GetAxis("Horizontal");

        transform.Translate(_xInput * DodgeSpeed * Time.deltaTime, 0, 0);
    }
}

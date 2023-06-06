using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float DodgeSpeed;
    private float _xInput;

    public float XMax;

    
    void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        transform.Translate(_xInput * DodgeSpeed * Time.deltaTime, 0, 0);

        float limitedX = Mathf.Clamp(transform.position.x, -XMax, XMax);
        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.Restart();
        }
    }
}

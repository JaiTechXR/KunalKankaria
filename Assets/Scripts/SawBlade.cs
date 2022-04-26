using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float moveTime;
    Vector3 movement;
    float timer;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 0f;
        movement = new Vector3(0f, 0f, moveSpeed);    
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer>moveTime)
        {
            timer = 0f;
            movement *= -1;
        }


    }
}

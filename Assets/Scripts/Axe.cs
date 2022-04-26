using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    [SerializeField] float rotateSpeed;
    [SerializeField] float period;
    float timer;
    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(new Vector3(rotateSpeed*Time.deltaTime, 0f, 0f));
        if(timer>period)
        {
            timer = 0f;
            rotateSpeed *= -1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] string type;
    [SerializeField] float speed;
    [SerializeField] float moveTime;
    Rigidbody rb;
    Vector3 movement;
    float timer;
    float direction;
    GameObject target;
    Vector3 offset;
    private void Start()
    {
        timer = 0f;
        rb = GetComponent<Rigidbody>();
        if (type == "Horizontal")
        {
            movement = new Vector3(speed * moveTime, 0f, 0f);
        }
        else if (type == "Vertical")
        {
            movement = new Vector3(0f, 0f, speed * moveTime);
        }
        else if (type == "Diagonal")
        {
            movement = new Vector3(Mathf.Sqrt(speed * moveTime), 0f, Mathf.Sqrt(speed * moveTime));
        }
        else if (type == "UpDown")
        {
            movement = new Vector3(0f, speed * moveTime, 0f);
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("Caught");
        target = collision.gameObject;
        offset = target.transform.position - transform.position;
    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Dropped");
        target = null;
    }
    private void FixedUpdate()
    {
        
        timer += Time.fixedDeltaTime;
        if(timer>=moveTime)
        {
            Debug.Log("Turning");
            timer = 0f;
            movement *= -1;
        }
        rb.MovePosition(transform.position+movement*Time.fixedDeltaTime);
        if (target != null)
        {            
            target.transform.position = transform.position + offset;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float smoothening;
    Transform target;
    Vector3 offset;
    [SerializeField]GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 targetPosition = offset + target.position;
        gameObject.transform.position = Vector3.Lerp(transform.position, targetPosition, smoothening);
    }
}

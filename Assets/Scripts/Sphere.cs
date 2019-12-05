using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Vector3 resetPos;

    private Rigidbody _rb;
    // Start is called before the first frame update

    [SerializeField]
    private float forceDown;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(0, -forceDown, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "DeathPlane")
        {
            _rb.velocity = Vector3.zero;
            transform.position = resetPos;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Vector3 resetPos;
    private Timer _timer;
    private Score _score;
    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _timer = GameObject.Find("Timer").GetComponent<Timer>();
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "DeathPlane")
        {
            _rb.velocity = Vector3.zero;
            transform.position = resetPos;
            _timer.AddTime(-2);
        } else if (other.CompareTag("Goal"))
        {
            _timer.AddTime(4);
            _score.AddScore(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private Rigidbody _rb;
    public float speedH, speedV;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speedH;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speedV;
        _rb.AddTorque(new Vector3(v, 0, -h));

    }
}

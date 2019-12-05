using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed * 1.2f;
		float v = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		rb.AddTorque(new Vector3(v, 0, -h));

	}
}

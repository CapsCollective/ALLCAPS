using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Sphere : MonoBehaviour
{
    public Vector3 resetPos;
    private Timer _timer;
    private Score _score;
    private Rigidbody _rb;
    private GameObject[] _keys;
    private KeyCap _selectedKey;
    private AudioSource _dingSound;
    
    // Start is called before the first frame update

    [SerializeField]
    private float forceDown;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _dingSound = GetComponent<AudioSource>();
        _timer = GameObject.Find("Timer").GetComponent<Timer>();
        _score = GameObject.Find("Score").GetComponent<Score>();
        _keys = FindObjectsOfType<GameObject>().Where(obj => obj.name == "Key").ToArray();
        _selectedKey = _keys[Random.Range(0, _keys.Length)].GetComponent<KeyCap>();
        _selectedKey.SelectKey();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(0, -forceDown, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "DeathPlane")
        {
            _rb.velocity = Vector3.zero;
            transform.position = resetPos;
            _timer.AddTime(-2);
        } else if (collision.collider.CompareTag("Goal"))
        {
            _dingSound.Play(0);
            _timer.AddTime(4);
            _score.AddScore(1);
            _selectedKey.DeselectKey();
            _selectedKey = _keys[Random.Range(0, _keys.Length)].GetComponent<KeyCap>();
            _selectedKey.SelectKey();
        }
    }
}

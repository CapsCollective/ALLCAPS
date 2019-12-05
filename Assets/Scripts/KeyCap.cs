using System;
using UnityEngine;

public class KeyCap : MonoBehaviour
{
    public string key;
    public float maxPos;
    public float minPos;
    
    
    private Vector3 _targetPos;
    private const int DownSpeed = 5;
    private const int UpSpeed = 10;

    private void Start()
    {
        _targetPos = transform.localPosition;
    }

    private void Update()
    {
        var speed = 0;
        if (Input.GetKey(key) && transform.localPosition.y > minPos)
        {
            _targetPos.y = minPos;
            speed = DownSpeed;
        }
        else if (transform.localPosition.y < maxPos)
        {
            _targetPos.y = maxPos;
            speed = UpSpeed;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPos, speed * Time.deltaTime);
    }
}
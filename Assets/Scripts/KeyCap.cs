using UnityEngine;

public class KeyCap : MonoBehaviour
{
    public string key;
    public float maxPos;
    public float minPos;
    
    
    private Vector3 _targetPos;

    [SerializeField]
    private int DownSpeed = 5;

    [SerializeField]
    private int UpSpeed = 10;

    [SerializeField]
    private BounceForce bf;


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
            bf.BounceHit(transform.localPosition.y - maxPos);
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPos, speed * Time.deltaTime);
    }
}
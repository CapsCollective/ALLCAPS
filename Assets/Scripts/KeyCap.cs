using UnityEngine;
using UnityEngine.Serialization;

public class KeyCap : MonoBehaviour
{
    public string key;
    public float maxPos;
    public float minPos;
    public float activationPoint;
    
    private AudioSource _audioData;
    private Vector3 _targetPos;

    [SerializeField]
    private int downSpeed = 5;

    [SerializeField]
    private int upSpeed = 10;

    [SerializeField]
    private BounceForce bf;

    private void Start()
    {
        _audioData = GetComponent<AudioSource>();
        _targetPos = transform.localPosition;
    }

    private void Update()
    {
        var initialPosY = transform.localPosition.y;
        var speed = 0;
        if (Input.GetKey(key) && transform.localPosition.y > minPos)
        {
            _targetPos.y = minPos;
            speed = downSpeed;
        }
        else if (transform.localPosition.y < maxPos)
        {
            _targetPos.y = maxPos;
            speed = upSpeed;
            bf.ApplyForce(transform.localPosition.y - maxPos);
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPos, speed * Time.deltaTime);

        if (initialPosY > activationPoint && transform.localPosition.y < activationPoint)
        {
            _audioData.Play(0);
        }
    }
}
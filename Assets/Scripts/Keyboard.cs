using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private Rigidbody _rb;
    public float maxTilt;
    public float downSpeed, upSpeed;

    private Quaternion _xTargetRot, _zTargetRot;
    private readonly Quaternion _normalRot = new Quaternion(0, 0, 0, 1.0f);
    private float _xSpeed = 0, _zSpeed = 0;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        var localRotation = transform.localRotation;
        _xTargetRot = localRotation;
        _zTargetRot = localRotation;
    }
    
    private void Update()
    {
        if (Input.GetKey("up"))
        {
            _xTargetRot.x = maxTilt;
            _xSpeed = upSpeed;
        }
        else if (Input.GetKey("down"))
        {
            _xTargetRot.x = -maxTilt;
            _xSpeed = upSpeed;
        }
        else if (!(Input.GetKey("up") || Input.GetKey("down")))
        {
            _xTargetRot.x = 0;
            _xSpeed = downSpeed;
        }
        
        var temp = Quaternion.Slerp(transform.localRotation, _xTargetRot, _xSpeed * Time.deltaTime);

        _zTargetRot = temp;

        if (Input.GetKey("left"))
        {
            _zTargetRot.z = maxTilt;
            _zSpeed = upSpeed;
        }
        else if (Input.GetKey("right"))
        {
            _zTargetRot.z = -maxTilt;
            _zSpeed = upSpeed;
        }
        else if (!(Input.GetKey("left") || Input.GetKey("right")))
        {
            _zTargetRot.z = 0;
            _zSpeed = downSpeed;
        }

        temp = Quaternion.Slerp(temp, _zTargetRot, _zSpeed * Time.deltaTime);
        var angle = Quaternion.Angle(temp, _normalRot);
        
        if (angle < maxTilt*10)
        {
            transform.localRotation = temp;
        }
    }
}

using UnityEngine;

public class KeyCap : MonoBehaviour
{
    public bool isMainMenu;
    public string key;
    public float keyTravel, activationPoint;
    public int downSpeed = 5, upSpeed = 10;
    public BounceForce bf;
    public Material regularMat;
    public Material selectedMat;
    
    private float _originalPositionY, _finalPositionY, _trueActivationPoint;
    private AudioSource _clickSound;
    private Vector3 _targetPos;
    private bool _sceneTransitioning = false;
    
    private void Start()
    {
        _originalPositionY = transform.position.y;
        _finalPositionY = _originalPositionY - keyTravel;
        _trueActivationPoint = _originalPositionY - (keyTravel * activationPoint);
        _clickSound = GetComponent<AudioSource>();
        _targetPos = transform.localPosition;
    }

    private void FixedUpdate()
    {
        var initialPosY = transform.localPosition.y;
        var speed = 0;

        
        if (Input.GetKey(key) && transform.localPosition.y > _finalPositionY)
        {
            _targetPos.y = _finalPositionY;
            speed = downSpeed;
        }
        else if (transform.localPosition.y < _originalPositionY)
        {
            _targetPos.y = _originalPositionY;
            speed = upSpeed;
            if (bf != null)
            {
                bf.ApplyForce(transform.localPosition.y - _originalPositionY);
            }
        }
        
        if (isMainMenu && _sceneTransitioning && transform.localPosition.y > _originalPositionY-1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPos, speed * Time.deltaTime);
        
        if (initialPosY > _trueActivationPoint && transform.localPosition.y < _trueActivationPoint)
        {
            _clickSound.Play(0);
            if (isMainMenu)
            {
                _sceneTransitioning = true;
            }
        }
    }

    public void SelectKey()
    {
        GetComponent<Renderer>().material = selectedMat;
        tag = "Goal";
    }
    
    public void DeselectKey()
    {
        GetComponent<Renderer>().material = regularMat;
        tag = "Untagged";
    }
}
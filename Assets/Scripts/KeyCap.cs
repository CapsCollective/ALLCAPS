using UnityEngine;

public class KeyCap : MonoBehaviour
{

    public bool isMainMenu;
    public string key;
    public float maxPos, minPos, activationPoint;
    public int downSpeed = 5, upSpeed = 10;
    public BounceForce bf;
    public Material regularMat;
    public Material selectedMat;

    private AudioSource _clickSound;
    private Vector3 _targetPos;
    private bool _sceneTransitioning = false;
    
    private void Start()
    {
        _clickSound = GetComponent<AudioSource>();
        _targetPos = transform.localPosition;
    }

    private void FixedUpdate()
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
            if (bf != null)
            {
                bf.ApplyForce(transform.localPosition.y - maxPos);
            }
        }
        
        if (isMainMenu && _sceneTransitioning && transform.localPosition.y > maxPos-1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPos, speed * Time.deltaTime);

        if (initialPosY > activationPoint && transform.localPosition.y < activationPoint)
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
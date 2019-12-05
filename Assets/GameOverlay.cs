using UnityEngine;

public class GameOverlay : MonoBehaviour
{
    public float colourOffset;
    public GameObject timer;
    private MeshRenderer _meshRenderer;
    private Timer _timer;
    
    private void Start()
    {
        _timer = timer.GetComponent<Timer>();
        Debug.Log(_timer.maxTime);
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        var percent = 1 - (_timer.currentTime / _timer.maxTime) - colourOffset;
        var color = _meshRenderer.material.color;
        color.a = percent;
        _meshRenderer.material.color = color;
    }
}

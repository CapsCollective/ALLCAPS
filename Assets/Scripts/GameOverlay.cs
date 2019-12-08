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
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    private void Update()
    {
        var percentRemaining = 1 - (_timer.currentTime / _timer.maxTime);
        var newAlpha = percentRemaining - 
                           Mathf.PingPong(Time.time * 
                                          Mathf.Clamp(percentRemaining/2,0.0f, 0.5f), 
                               colourOffset);
        var color = _meshRenderer.material.color;
        color.a = newAlpha;
        _meshRenderer.material.color = color;
    }
}

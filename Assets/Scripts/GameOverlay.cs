using UnityEngine;

public class GameOverlay : MonoBehaviour
{
    public float colourOffset;
    public GameObject timer;
    private MeshRenderer _meshRenderer;
    private Timer _timer;
    private float count = 0;
    private void Start()
    {
        _timer = timer.GetComponent<Timer>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    private void FixedUpdate()
    {
        var percentRemaining = 1 - (_timer.currentTime / _timer.maxTime);
        count += Mathf.Clamp(percentRemaining, 0f, 0.6f) / 60f;
        var newAlpha = percentRemaining - 0.2f - Mathf.PingPong(count, colourOffset);
        var color = _meshRenderer.material.color;
        color.a = newAlpha;
        _meshRenderer.material.color = color;
    }
}

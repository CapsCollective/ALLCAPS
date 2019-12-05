using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        _score += score;
        GetComponent<TextMesh>().text = _score.ToString();
    }
}

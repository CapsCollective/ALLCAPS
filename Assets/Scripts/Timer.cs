using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxTime = 30;
    public float currentTime = 30;
    void Start()
    {
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        transform.localScale = new Vector3(0.95f * currentTime/ maxTime, 0.8f, 0.1f);
    }

    public void AddTime(float time)
    {
        currentTime += time;
        if (currentTime > maxTime) currentTime = maxTime;
    }
}

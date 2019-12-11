using System.Collections;
using UnityEngine;

public class MoveToView : MonoBehaviour
{
    public Vector3 menuPos, settingsPos;
    
    public void ViewSettings()
    {
        GetComponent<AudioSource>().Play(0); 
        StartCoroutine(Move(settingsPos));
        GameObject.Find("Key").GetComponent<KeyCap>().enabled = false;
    }
    
    public void ViewMenu()
    {
        GetComponent<AudioSource>().Play(0); 
        StartCoroutine(Move(menuPos));
        GameObject.Find("Key").GetComponent<KeyCap>().enabled = true;
    }

    private IEnumerator Move(Vector3 targetPos)
    {
        float t = 0;
        Vector3 startPos = transform.position;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, targetPos, Mathf.SmoothStep(0.0f, 1.0f, t));
            yield return null;
        }
    }
}

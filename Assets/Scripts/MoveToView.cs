using System.Collections;
using UnityEngine;

public class MoveToView : MonoBehaviour
{
    public Vector3 menuPos, settingsPos;
    
    public void ViewSettings()
    {
        Debug.Log("Move");
        StartCoroutine(Move(settingsPos));
    }
    
    public void ViewMenu()
    {
        StartCoroutine(Move(menuPos));
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

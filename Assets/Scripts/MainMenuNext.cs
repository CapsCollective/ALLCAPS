using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuNext : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            StartCoroutine(NewWait());
    }

    IEnumerator NewWait ()
    {
        yield return new WaitForSeconds(0.2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}

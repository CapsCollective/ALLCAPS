using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRendererOnStart : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

}

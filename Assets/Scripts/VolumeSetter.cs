using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetter : MonoBehaviour
{
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1);
    }
}

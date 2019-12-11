using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    private float _masterVolume = 1;
    private Resolution  _resolution;
    // Start is called before the first frame update
    void Start()
    {
        // Load Settings from File
        UpdateSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSettings()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    void Awake () 
    {
        #if UNITY_EDITOR
        Application.targetFrameRate = 144;
        #endif
    }
}

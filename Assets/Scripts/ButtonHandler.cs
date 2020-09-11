using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject SettingsTab;

    public void EnableSettings()
    {
        SettingsTab.SetActive(true);
    }

    public void DisableSettings()
    {
        SettingsTab.SetActive(false);
    }

    
}

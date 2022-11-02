using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance{ get; private set;}
    public UIManager uiManager {get; private set; }
    public AudioManager audioManager {get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        uiManager = GetComponentInChildren<UIManager>();
        audioManager = GetComponentInChildren<AudioManager>();
    }

    public void Tester() 
    {
        Debug.Log("Working");
    }
}


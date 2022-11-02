using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set;}

    public PlayerScript playerScript;




    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        Singleton.Instance.Tester();
        Singleton.Instance.audioManager.PlaySound();
    }

    public void TakeDamage(float damage)
    {
        playerScript.health -= damage;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}

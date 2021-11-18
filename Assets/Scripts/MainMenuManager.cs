using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void onStart()
    {
        Debug.Log("onStart");
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void onShop()
    {
        Debug.Log("onShop");
        SceneManager.LoadScene("Scenes/Shop Scene");
    }

    public void onSettings()
    {
        Debug.Log("onSettings");
    }
}

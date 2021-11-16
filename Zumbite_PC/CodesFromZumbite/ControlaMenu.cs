using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaMenu : MonoBehaviour
{
    public GameObject BotãoSair;

    private void Start()
    {
        #if UNITY_STANDALONE ||UNITY_EDITOR
        BotãoSair.SetActive(true);
        #endif
    }
    public void JogarJogo()
    {
        SceneManager.LoadScene("SceneMotel");
    }
    public void SairDoJogo()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void OnMain()
    {
        SceneManager.LoadScene("Main");
    }
}

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
    public void OnEnd()
    {
        SceneManager.LoadScene("End");
    }
}

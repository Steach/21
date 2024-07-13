using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    public System.Action PressButton;
    public void RestartScene()
    {
        PressButton?.Invoke();
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}

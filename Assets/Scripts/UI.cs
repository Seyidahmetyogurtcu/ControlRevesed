using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}

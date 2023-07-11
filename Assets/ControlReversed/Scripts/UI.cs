using UnityEngine;
using UnityEngine.SceneManagement;

namespace ControlReversed
{
    public class UI : MonoBehaviour
    {
        public void RestartButton()
        {
            SceneManager.LoadScene(0);
        }
    }

}
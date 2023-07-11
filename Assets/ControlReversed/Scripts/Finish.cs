using UnityEngine;
namespace ControlReversed
{

    public class Finish : MonoBehaviour
    {
        UI ui;
        private void OnTriggerEnter(Collider other)
        {
            if (CompareTag("Player"))
            {
                ui.RestartButton();
            }
        }
    }

}
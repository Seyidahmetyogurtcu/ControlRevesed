using UnityEngine;

namespace ProjectBalik
{
    public class Player : MonoBehaviour
    {
        // Start is called before the first frame update
        int a;

        public int A { get => a; set => a = value; }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Lose()
        {
            Debug.Log("Kaybettin");
        }
    }
}

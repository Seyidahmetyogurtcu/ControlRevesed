using UnityEngine;

namespace ControlReversed
{
    public class Health : MonoBehaviour
    {
        public int health = 500;

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }

}
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 500;
    //public GameObject deathEffect;
    public bool isEnraged = false;

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
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

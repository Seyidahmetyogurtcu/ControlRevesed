using UnityEngine;

namespace ControlReversed
{
    public class Arrow : MonoBehaviour
    {
        bool hasHit;
        Rigidbody2D rb;
        public int arrowDamage = 10;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (hasHit == false)  // normal behaviour(if not hit any object)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }



        private void OnTriggerEnter(Collider other)
        {
            hasHit = true;

            if (other.gameObject.GetComponent<Health>() != null)
            {
                other.gameObject.GetComponent<Health>().TakeDamage(arrowDamage);
                Destroy(this.gameObject);
            }
            if (this.gameObject != null)
            {
                Destroy(this.gameObject, 0.5f);
            }
        }
    }
}
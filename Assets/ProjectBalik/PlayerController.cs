using UnityEngine;
namespace ProjectBalik
{

    public class PlayerController : MonoBehaviour
    {

        public float speed = 5f;

        public float boostFactor = 2f;

        public float boostDuration = 3f;

        public float boostCooldown = 5f;

        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        private float boostTimer = 0f;

        private float cooldownTimer = 0f;

        private bool isBoosting = false;

        private bool canBoost = true;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            bool isInverted = spriteRenderer.flipX;
            if ((!isInverted && horizontal < 0) || (isInverted && horizontal > 0))
            {
                spriteRenderer.flipX = !isInverted;
            }

            Vector2 direction = new Vector2(horizontal, vertical);

            direction.Normalize();

            rb.velocity = direction * speed;

            if (Input.GetKeyDown(KeyCode.Space) && canBoost)
            {
                isBoosting = true;

                canBoost = false;

                boostTimer = 0f;

                cooldownTimer = 0f;
            }

            if (isBoosting)
            {
                boostTimer += Time.deltaTime;

                if (boostTimer < boostDuration)
                {
                    rb.velocity *= boostFactor;
                }
                else
                {
                    isBoosting = false;
                }
            }

            if (!canBoost)
            {
                cooldownTimer += Time.deltaTime;

                if (cooldownTimer >= boostCooldown)
                {
                    canBoost = true;
                }
            }
        }
    }
}
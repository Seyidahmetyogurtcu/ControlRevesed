using UnityEngine;
namespace ControlReversed
{

    public class PlayerAI : MonoBehaviour
    {
        public float speed = 5f;
        public float jumpForce = 10f;
        public LayerMask groundLayer;
        private Rigidbody2D rb;
        private Animator anim;
        private SpriteRenderer sr;
        private int direction = 1;
        private float groundDistance = 0.1f;
        private float obstacleDistance = 0.5f;
        private Vector3 offset = new Vector3(0.25f, 0f, 0f);

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            Move();
            Jump();
        }

        void Move()
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            sr.flipX = direction < 0;
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            RaycastHit2D hit = Physics2D.Raycast(transform.position + offset * direction, Vector2.right * direction, obstacleDistance, groundLayer);
            if (hit.collider != null)
            {
                direction *= -1;
            }
        }

        void Jump()
        {
            bool isGrounded = Physics2D.Raycast(transform.position - offset, Vector2.down, groundDistance, groundLayer);
            anim.SetBool("IsGrounded", isGrounded);
            if (isGrounded && Random.Range(0f, 1f) < 0.01f)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("Jump");
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDistance);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * direction * obstacleDistance);

            //Gizmos.color = Color.blue;
            //Gizmos.DrawLine(transform.position, transform.position + Vector3.right * direction * enemyDistance);
        }
    }
}
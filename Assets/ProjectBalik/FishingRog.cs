using UnityEngine;
namespace ProjectBalik
{

    public class FishingRog : MonoBehaviour
    {
        public float growChance = 0.1f;

        public float growFactor = 1.5f;

        public float growDuration = 5f;

        private Collider2D col;

        private bool hasGrowAbility = false;

        private bool isGrowing = false;

        private float growTimer = 0f;

        void Start()
        {
            col = GetComponent<Collider2D>();

            float random = Random.Range(0f, 1f);

            if (random <= growChance)
            {
                hasGrowAbility = true;
            }
        }

        void Update()
        {
            if (hasGrowAbility && !isGrowing)
            {
                isGrowing = true;

                growTimer = 0f;
            }

            if (isGrowing)
            {
                growTimer += Time.deltaTime;

                if (growTimer <= growDuration)
                {
                    col.transform.localScale *= growFactor;
                }
                else
                {
                    isGrowing = false;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Player player = other.GetComponent<Player>();

                if (player != null)
                {
                    player.Lose();
                }
                else
                {
                    Debug.LogWarning("noPlayerexist");
                }
            }
        }
    }
}
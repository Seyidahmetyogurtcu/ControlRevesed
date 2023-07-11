using UnityEngine;
using UnityEngine.EventSystems;
namespace ControlReversed
{

    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private Vector2 initialPosition;
        public GameObject prefab;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            initialPosition = rectTransform.anchoredPosition;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            // Get the transform component of the gameobject
            Transform transform = GetComponent<Transform>();

            // Convert the position from screen space to world space
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(transform.position);

            // Set the z coordinate to zero to avoid clipping
            worldPosition.z = 0f;

            // Instantiate the prefab at the world position and rotation
            Instantiate(prefab, worldPosition, transform.rotation);
            rectTransform.anchoredPosition = initialPosition;

        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }



}

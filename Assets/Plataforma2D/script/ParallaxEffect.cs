using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float num = 0.5f;
    [SerializeField] private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    void Start()
    {
        previousCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * num;
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTransform.position;
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 COM = FindObjectOfType<Controller>().CenterOfMass();

        Vector3 desiredPostion = COM + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPostion, ref velocity, smoothSpeed);
    }
}

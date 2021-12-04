using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed = 5f;
    public Vector3 velo = Vector3.zero;

    void LateUpdate()
    {
        Vector3 zoom = player.position + offset;
        Vector3 BINGBONG = Vector3.SmoothDamp(transform.position, zoom, ref velo, speed * Time.deltaTime);
        transform.position = BINGBONG;
    }
}

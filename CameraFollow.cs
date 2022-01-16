using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset =  new Vector3(0, 1, -10);
    public float speed = 50f;
    public Vector3 velo = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 zoom = player.position + offset;
        Vector3 BINGBONG = Vector3.Lerp(transform.position, zoom, speed);
        transform.position = BINGBONG;
    }
}

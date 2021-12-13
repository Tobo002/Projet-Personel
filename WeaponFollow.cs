using UnityEngine;

public class WeaponFollow : MonoBehaviour
{

    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

        transform.up = direction;
    }
}

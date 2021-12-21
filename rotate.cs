using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public Transform enemy;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, enemy.rotation.z);
        //Debug.Log("Obj: " + transform.rotation.z + ", Ball: " + enemy.rotation.z + ", Sum: " + (360 - enemy.rotation.z));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModelInUI : MonoBehaviour
{
    private float speed = 10f;

    private void OnMouseDrag()
     {
        //if (Input.GetMouseButton(0))
        //{
            float OffsetX = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, -OffsetX, 0) * speed, Space.World);
        //}
    }
}

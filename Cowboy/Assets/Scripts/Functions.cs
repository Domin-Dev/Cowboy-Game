using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Functions
{
    static public Vector3 GetMousePosition()
    {
        Vector3 vector3 = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(vector3);
    }
}

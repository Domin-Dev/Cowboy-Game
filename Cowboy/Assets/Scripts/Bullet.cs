using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void SetUp(Vector3 shootDir)
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        float moveSpeed = 60f;
        rigidbody2D.AddForce(shootDir.normalized * moveSpeed, ForceMode2D.Impulse);
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle + 90);
        Destroy(gameObject, 5f);
    }

}

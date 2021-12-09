using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraBody : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
    }
}

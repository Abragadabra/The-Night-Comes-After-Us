using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsKill : MonoBehaviour
{
    public Vector3 startPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = startPosition;
        }
    }
}

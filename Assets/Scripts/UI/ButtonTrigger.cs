using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Animator anim;
    //public GameObject frame;
    //public GameObject[] otherFrames;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("isTriggered");
            //frame.SetActive(false);

            //foreach (GameObject frame in otherFrames)
            //{
            //    frame.SetActive(false);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("isTriggered");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NoNameControl : MonoBehaviour
{
    public NPCConversation dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ConversationManager.Instance.StartConversation(dialogue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ConversationManager.Instance.EndConversation();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Snake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        Snake.SetActive(true);
    }
}

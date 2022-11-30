using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderFall : MonoBehaviour
{
    [SerializeField] private GameObject Boulder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Boulder.SetActive(true);
    }
}

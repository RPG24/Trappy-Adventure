using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderGroundDetect : MonoBehaviour
{
    [SerializeField] private GameObject Traps;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Traps.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject blood;
    [HideInInspector] public bool isDead = false;
    private Scene scene;

    private void Awake()
    {
        scene = GameObject.FindGameObjectWithTag("Scene").GetComponent<Scene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            this.GetComponent<Animator>().SetTrigger("death");

            this.GetComponent<Movement>().enabled = false;

            blood.SetActive(true);

            isDead = true;

        }

        if (collision.gameObject.CompareTag("Mine"))
        {
            this.GetComponent<Animator>().SetTrigger("death");

            this.GetComponent<Movement>().enabled = false;

            collision.GetComponent<Animator>().SetTrigger("Mine");

            blood.SetActive(true);

            isDead = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private Animator fadeScreen;
    [SerializeField] private GameObject levelScreen;
    private Scene scene;

    private void Awake()
    {
        scene = GameObject.FindGameObjectWithTag("Scene").GetComponent<Scene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Movement>().enabled = false;
            collision.gameObject.GetComponent<AutoMove>().enabled = true;
            fadeScreen.SetTrigger("fade");
            StartCoroutine(LevelEndScreen());
            Destroy(collision.gameObject, 4f);
        }
    }

    IEnumerator LevelEndScreen()
    {
        yield return new WaitForSeconds(1f);
        levelScreen.SetActive(true);
    }

    public void ChangeLevel()
    {
        scene.lives = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

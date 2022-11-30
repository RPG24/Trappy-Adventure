using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{

    private Scene scene;
    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Vector3 initialStart;

    private void Awake()
    {
        scene = GameObject.FindGameObjectWithTag("Scene").GetComponent<Scene>();
        scene.lastcheckPoint = initialStart;
    }

    private void Update()
    {
        if (playerDeath.isDead)
        {
            if(scene.lives > 0)
            {
                scene.Dead();
                playerDeath.isDead = false;
            }
            else
            {
                if (SceneManager.GetActiveScene().buildIndex != 1)
                {
                    gameOverMenu.SetActive(true);
                    playerDeath.isDead = false;
                }
                else
                {
                    scene.Dead();
                    playerDeath.isDead = false;
                }
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        scene.lastcheckPoint = initialStart;
        scene.lives = 2;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        scene.lastcheckPoint = initialStart;
        scene.lives = 2;
    }
}

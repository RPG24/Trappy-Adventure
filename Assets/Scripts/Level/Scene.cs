using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public int lives = 2;
    private static Scene instance;
    [HideInInspector] public Vector3 lastcheckPoint;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Dead()
    {
            Debug.Log("Hello");
            lives--;
            StartCoroutine(startagain());
    }

    IEnumerator startagain()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

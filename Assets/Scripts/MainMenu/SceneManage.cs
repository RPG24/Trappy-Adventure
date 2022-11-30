using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField] private GameObject fade;

    public void NextLevel()
    {
        fade.SetActive(true);
        StartCoroutine(changeScene());
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}

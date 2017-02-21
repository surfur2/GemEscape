using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string levelToLoad;

    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

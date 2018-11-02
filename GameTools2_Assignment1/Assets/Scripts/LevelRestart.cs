using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour {

    public void ReloadScene()
    {
        Scene _CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(_CurrentScene.name);
    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
        {
            ReloadScene();
        }
    }
}

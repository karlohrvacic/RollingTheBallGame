using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
    AudioSource audioSource;
    public Transform canvas;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
            Debug.Log("PAUZA AKTIVIRANA");
        }
        
    }
    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("PAUZA");
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
            Debug.Log("ODPAUZA");
        }
    }
}
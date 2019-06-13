using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject UI;
     
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TogglePauseMenu();

        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        UI.SetActive(isPaused);
    }
}

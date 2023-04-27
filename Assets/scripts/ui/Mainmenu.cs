using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    // Start is called before the first frame update
   public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void gomainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void quitgame()
    {
        Application.Quit();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class papercounter : MonoBehaviour
{
    public static papercounter instance;
   private TextMeshProUGUI thetext;

   public static int papercount=0;


  
   private void Awake()
   {
    instance = this;
   }
    void Start()
    {
        papercount = 0;
        thetext= GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        thetext.text = $"{papercount}/6";
        
        if (papercount >= 6)
    {
      
        StartCoroutine(Win(2f, "slender lost"));
    }
        
    }
    IEnumerator Win (float waitTime, string sceneName)
{
    yield return new WaitForSeconds(waitTime);

    // Load the specified scene
    SceneManager.LoadScene("slender lost");
}
}

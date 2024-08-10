using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutSetting : MonoBehaviour
{
[SerializeField] public GameObject about;
[SerializeField] public GameObject how;

    private void Awake() {
        about.SetActive(false);
        how.SetActive(false);
    }
    // Start is called before the first frame update
    #region Game Over Functions
   

     

    

    //Activate game over screen
    

    public void AboutScreen()
    {
        
        about.SetActive(true);
        
    }

    public void closeAbout()
    {
       
        about.SetActive(false);
    }


    public void HowScreen()
    {
        
        how.SetActive(true);
        
    }

    public void closeHow()
    {
       
        how.SetActive(false);
    }

    //Quit game/exit play mode if in Editor
    // public void Quit()
    // {
    //     Application.Quit(); //Quits the game (only works in build)

    //     #if UNITY_EDITOR
    //     UnityEditor.EditorApplication.isPlaying = false; //Exits play mode
    //     #endif
    // }


    #endregion
}

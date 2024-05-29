using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] LoadingScreenSO LoadingScreenSO;
    
    public void LoadMap()
    {
        LoadingScreenSO.Show();
        LoadingScreenSO.LoadScene((int) SceneIndex.MAP);
        LoadingScreenSO.AddToLoadingList((int) SceneIndex.UI);
    }

    public void ExitToWindows()
    {
        if (Application.isEditor == true)
            return;

        Application.Quit();
    }
    
}

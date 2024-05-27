using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] LoadingScreenSO LoadingScreenSO;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoadMap()
    {
        LoadingScreenSO.Show();
        LoadingScreenSO.LoadScene((int) SceneIndex.MAP);
        LoadingScreenSO.AddToLoadingList((int) SceneIndex.UI);
    }
    
}

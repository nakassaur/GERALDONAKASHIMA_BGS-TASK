using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{   
    [SerializeField] LoadingScreenSO LoadingScreenSO;
    [SerializeField] GameObject _mainContainer;

    List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();

    // Built-in Functions
    void Start()
    {
        LoadingScreenSO.EventOnShow += LoadingScreenSO_EventOnShow;
        LoadingScreenSO.EventOnLoadScene += LoadingScreenSO_EventOnLoadScene;
        LoadingScreenSO.EventOnAddToLoadingList += LoadingScreenSO_EventOnAddToLoadingList;
    }
        
    // Event Signature
    void LoadingScreenSO_EventOnShow()
    {
        _mainContainer.SetActive(true);
    }
    void LoadingScreenSO_EventOnLoadScene(int sceneID)
    {
        _scenesLoading.Add(SceneManager.LoadSceneAsync(sceneID));
        StartCoroutine(GetLoadProgress());
    }

    void LoadingScreenSO_EventOnAddToLoadingList(int sceneID)
    {
        _scenesLoading.Add(SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive));
    }

    // Coroutines
    public IEnumerator GetLoadProgress()
    {
        for (int i = 0; i < _scenesLoading.Count; i++)
        {
            while (_scenesLoading[i].isDone == false)
                yield return null;
        }

        LeanTween.delayedCall(2.0f, () =>
        {
            LoadingScreenSO.LoadComplete();
            _mainContainer.SetActive(false);            
        });

    }

}

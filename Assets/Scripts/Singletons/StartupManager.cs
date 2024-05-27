using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    [SerializeField] GlobalInput GlobalInput;
    [SerializeField] GameObject splashScreen;
    [SerializeField] GameObject textMessage;

    List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();

    bool _loadComplete;

    void Start()
    {
        GlobalInput.EventOnSubmit += GlobalInput_EventOnSubmit;

        _scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndex.MENU, LoadSceneMode.Additive));
        _scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndex.SETTINGS, LoadSceneMode.Additive));

        StartCoroutine(GetLoadProgress());
    }
        
    public IEnumerator GetLoadProgress()
    {
        for (int i = 0; i < _scenesLoading.Count; i++)
        {
            while (_scenesLoading[i].isDone == false)
                yield return null;
        }

        LeanTween.delayedCall(1.0f, () =>
        {
            textMessage.SetActive(true);
            _loadComplete = true;
        });
        
    }

    // Event Signatures
    void GlobalInput_EventOnSubmit()
    {
        if (_loadComplete == false) return;
                
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int) SceneIndex.MENU));
        SceneManager.UnloadSceneAsync((int)SceneIndex.TITLE);

        // Prevents other binds of the Submit Action to execute this block multiple times;
        _loadComplete = false; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LoadingScreenSO", menuName = "ScriptableObject/LoadingScreenSO")]
public class LoadingScreenSO : ScriptableObject
{
    public delegate void ShowDelegate();
    public event ShowDelegate EventOnShow;

    public void Show() { this.EventOnShow?.Invoke(); }

    public delegate void LoadSceneDelegate(int sceneID);
    public event LoadSceneDelegate EventOnLoadScene;

    public void LoadScene(int sceneID) { this.EventOnLoadScene?.Invoke(sceneID); }

    public delegate void AddToLoadingListDelegate(int sceneID);
    public event AddToLoadingListDelegate EventOnAddToLoadingList;

    public void AddToLoadingList(int sceneID) { this.EventOnAddToLoadingList?.Invoke(sceneID); }

    public delegate void OnLoadCompleteDelegate();
    public event OnLoadCompleteDelegate EventOnLoadComplete;
    public void LoadComplete() { this.EventOnLoadComplete?.Invoke(); }
}

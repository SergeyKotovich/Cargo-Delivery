using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _sceneChangeDelay;
    [SerializeField] private CoroutinesManager _coroutinesManager;
    [SerializeField] private GameObject _defeatScreen;
    [SerializeField] private GameObject _winScreen;
    
    
    [UsedImplicitly]
    public void StartGameOverCoroutine()
    {   _coroutinesManager.StopAllCoroutines();
        _coroutinesManager.StartCoroutine(ShowDefeatScreen());
    }

    private IEnumerator ShowDefeatScreen()
    {
        yield return new WaitForSeconds(_sceneChangeDelay);
        _defeatScreen.SetActive(true);
    }

    [UsedImplicitly]
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(GlobalConstants.GAME);
    }

    [UsedImplicitly]
    public void ExitGame()
    {
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    [UsedImplicitly]
    public void StartGameWinCoroutine()
    {
        _coroutinesManager.StopAllCoroutines();
        _coroutinesManager.StartCoroutine(ShowVictoryScreen());
    }

    private IEnumerator ShowVictoryScreen()
    {
        yield return new WaitForSeconds(_sceneChangeDelay);
        _winScreen.SetActive(true);
    }
}
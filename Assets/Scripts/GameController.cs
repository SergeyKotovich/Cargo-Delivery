using System.Collections;
using JetBrains.Annotations;
using OpenCover.Framework.Model;using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _sceneChangeDelay;
    [SerializeField] private CoroutinesManager _coroutinesManager;
    
    
    [UsedImplicitly]
    public void StartGameOverCoroutine()
    {
        _coroutinesManager.StartCoroutine(ShowGameOver());
    }

    private IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(_sceneChangeDelay);
        SceneManager.LoadSceneAsync(GlobalConstants.GAME_OVER_SCENE);
    }
}
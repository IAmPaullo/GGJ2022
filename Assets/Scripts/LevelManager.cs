using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int level;
    private void OnEnable()
    {
        PlayerMovement.DeathAction += RestartLevel;
    }
    private void OnDisable()
    {
        PlayerMovement.DeathAction -= RestartLevel;
    }

    public void RestartLevel()
    {
        Tween zoomOut = DOTween.To(() => Camera.main.fieldOfView, x => Camera.main.fieldOfView = x, 180, 1);
        zoomOut.OnComplete(() =>StartCoroutine(ReloadScene()));
        zoomOut.Play();


    }
    private IEnumerator ReloadScene()
    {
        Scene actual = SceneManager.GetSceneAt(SceneManager.sceneCount-1);
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(actual.name,LoadSceneMode.Additive);
        yield return loadOp;
        SceneManager.UnloadScene(actual);
        Camera.main.fieldOfView = 180;
        Tween zoomIn = DOTween.To(() => Camera.main.fieldOfView, x => Camera.main.fieldOfView = x, 60, 1);
        zoomIn.Play();
        
    }
}

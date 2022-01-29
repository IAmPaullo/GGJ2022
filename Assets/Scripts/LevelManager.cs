using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private void Start()
    {
        cam.m_Lens.FieldOfView = 180; 
        Tween zoomIn = DOTween.To(() => cam.m_Lens.FieldOfView, x => cam.m_Lens.FieldOfView = x, 60, 1);
        zoomIn.Play();
    }
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
        Tween zoomOut = DOTween.To(() => cam.m_Lens.FieldOfView, x => cam.m_Lens.FieldOfView = x, 180, 1);
        zoomOut.OnComplete(() =>StartCoroutine(ReloadScene()));
        zoomOut.Play();
    }

    private IEnumerator ReloadScene()
    {
        Scene actual = SceneManager.GetSceneAt(SceneManager.sceneCount-1);
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(actual.name,LoadSceneMode.Additive);
        
        yield return loadOp;
        SceneManager.UnloadScene(actual);
        
        
    }
}

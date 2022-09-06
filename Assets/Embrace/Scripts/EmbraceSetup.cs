using System;
using UnityEngine;
using EmbraceSDK;
using UnityEngine.SceneManagement;

public class EmbraceSetup : MonoBehaviour
{
    public bool useJson;
    public int writeInterval;
    public int memoryInterval;
    public int direction;

    private void OnApplicationQuit()
    {
        Stop();
    }

    private void OnDestroy()
    {
        Stop();
    }

    public void StartGame()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(1);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            Embrace.Instance.StartSDK();
            Embrace.Instance.EndAppStartup();
            Embrace.Instance.StartPerformanceCapture(useJson, writeInterval, memoryInterval);
        }
    }

    public void Stop()
    {
        Embrace.Instance.StopPerformanceCapture();
    }
}

using System;
using System.Collections;
using UnityEngine;
using EmbraceSDK;
using UnityEngine.SceneManagement;

public class EmbraceSetup : MonoBehaviour
{
    public bool featureEnabled;
    public bool useJson;
    public int writeInterval;
    public int memoryInterval;
    public int direction;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        Debug.Log($"Target Framerate: {Application.targetFrameRate}");
    }

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
        Embrace.Instance.StartSDK();
        Embrace.Instance.EndAppStartup();

        if (scene.buildIndex == 1)
        {
            StartCoroutine(DelayFPS());
        }
    }

    private IEnumerator DelayFPS()
    {
        yield return new WaitForSeconds(1);

        Debug.Log("Starting FPS Capture");

        if (featureEnabled)
        {
            Embrace.Instance.HandleRemoteConfigReceived(null, new RemoteConfigEventArgs(new RemoteConfig { capture_fps_data = true }));
        }

    }

    public void Stop()
    {
        if (featureEnabled)
        {
            Embrace.Instance.StopPerformanceCapture();
        }
    }
}
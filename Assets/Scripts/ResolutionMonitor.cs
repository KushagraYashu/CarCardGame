using UnityEngine;
using System.Collections;
using System;

public class ResolutionMonitor : MonoBehaviour
{
    public static event Action<Vector2> OnResolutionChange;

    public static float checkDelay = 0.5f;

    static Vector2 resolution;
    static bool isMonitoring = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CheckForResize());
    }

    IEnumerator CheckForResize()
    {
        resolution = new Vector2(Screen.width, Screen.height);

        while (isMonitoring)
        {
            if(resolution.x != Screen.width || resolution.y != Screen.height)
            {
                resolution = new Vector2(Screen.width, Screen.height);
                OnResolutionChange?.Invoke(resolution);
            }

            yield return new WaitForSeconds(checkDelay);
        }
    }

    private void OnDestroy()
    {
        isMonitoring = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

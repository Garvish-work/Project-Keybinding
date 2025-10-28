using UnityEngine;

public class PerformanceHandler : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 1000;
    }

    
}

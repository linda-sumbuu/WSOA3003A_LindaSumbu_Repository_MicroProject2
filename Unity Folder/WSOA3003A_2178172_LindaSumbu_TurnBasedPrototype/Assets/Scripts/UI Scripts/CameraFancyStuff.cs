using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFancyStuff : MonoBehaviour
{
    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform cameraF;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;
    void Start()
    {
        cameraF = Camera.main.transform;
        startPosition = cameraF.localPosition;
        initialDuration = duration;
    }

    
    void Update()
    {
        if (shouldShake)
        {
            if(duration > 0)
            {
                cameraF.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                cameraF.localPosition = startPosition;
            }
        }
    }
}

//https://docs.unity3d.com/ScriptReference/Camera-backgroundColor.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBack : MonoBehaviour
{
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 1.0F;

    public Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2,  t);
    }
}

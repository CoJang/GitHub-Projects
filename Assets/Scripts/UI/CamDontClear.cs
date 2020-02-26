using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDontClear : MonoBehaviour
{
    [SerializeField] Camera cam;

    private void Awake()
    {
        if (cam == null)
            cam = this.GetComponent<Camera>();

        Init();
    }

    public void Init()
    {
        cam.clearFlags = CameraClearFlags.Color;
    }

    public void OnPostRender()
    {
        cam.clearFlags = CameraClearFlags.Nothing;
    }
}

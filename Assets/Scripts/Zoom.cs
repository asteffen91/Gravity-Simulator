﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float sensitivity = 10f;
    public float minView = 1f;
    private float maxView;

    public float bgWidth = 100f;

    private void Start()
    {
        maxView = bgWidth / (2f * Camera.main.aspect);
    }

    void Update()
    {
        float view = Camera.main.orthographicSize;
        view -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        view = Mathf.Clamp(view, minView, maxView);
        Camera.main.orthographicSize = view;
    }
}

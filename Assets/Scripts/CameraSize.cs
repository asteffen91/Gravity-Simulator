using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Get cammera size
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        float size = Mathf.Max(height, width);

        transform.localScale = new Vector3(size, size, 1f);
    }
}

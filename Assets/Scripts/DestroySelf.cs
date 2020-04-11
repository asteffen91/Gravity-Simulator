using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float limit = 10000;

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPosition.y < -limit || screenPosition.y > Screen.height + limit)
        {
            FindObjectOfType<Controller>().DestoryParticle(this.gameObject);
        }
        if (screenPosition.x < -limit || screenPosition.x > Screen.width + limit)
        {
            FindObjectOfType<Controller>().DestoryParticle(this.gameObject);
        }
    }
}

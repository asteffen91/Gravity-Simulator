using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class Controller : MonoBehaviour
{
    public GameObject particle;
    private LineRenderer lineRend;

    public float velScale;
    private float mass = 50f;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 curPos;
    private Vector2 vel;

    private bool launching = false;
    private static List<GameObject> particles;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
        lineRend.enabled = false;
    }

    void Update()
    {
        LaunchProjectiles();

        if (Input.GetButtonDown("Toggle Camera"))
        {
            FindObjectOfType<CameraFollow>().enabled = !FindObjectOfType<CameraFollow>().enabled;
        }

        if (Input.GetButtonDown("Clear Scene"))
        {
            ClearScene();
        }

        if (Input.GetButtonDown("Delete Last"))
        {
            if (particles != null && particles.Count > 0)
            {
                DestoryParticle(particles[particles.Count - 1]);
            }
        }
    }

    void LaunchProjectiles()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            launching = true;
            lineRend.enabled = true;
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetButton("Fire1") && launching)
        {
            curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector3(startPos.x, startPos.y, 0f));
            lineRend.SetPosition(1, new Vector3(curPos.x, curPos.y, 0f));
        }

        if(Input.GetButtonUp("Fire1") && launching)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vel = (startPos - endPos) * velScale;

            GameObject ball = Instantiate(particle, startPos, Quaternion.identity);
            if(particles == null)
            {
                particles = new List<GameObject>();
            }
            particles.Add(ball);

            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            rb.velocity = vel;

            rb.mass = mass;

            lineRend.enabled = false;
            launching = false;
        }
    }

    public void UpdateMass(float newMass)
    {
        mass = newMass;
    }

    public void ClearScene()
    {
        foreach(GameObject gobj in particles)
        {
            Destroy(gobj);
        }
        particles.Clear();
    }

    public Vector3 CenterOfMass()
    {
        Vector3 num = Vector3.zero;
        float totalmass = 0f;

        if (particles == null || particles.Count == 0)
        {
            return Vector3.zero;
        }
        else
        {
            foreach (GameObject p in particles)
            {
                num += p.GetComponent<Rigidbody2D>().mass * p.transform.position;
                totalmass += p.GetComponent<Rigidbody2D>().mass;
            }

            return num / totalmass;
        }
    }

    public void DestoryParticle(GameObject p)
    {
        particles.Remove(p);
        Destroy(p);
    }
}

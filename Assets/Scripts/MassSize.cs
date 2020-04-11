using UnityEngine;

public class MassSize : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tran;

    public float sizeScale = 0.25f;
    public float smooth = 0.25f;

    void Update()
    {
        Resize();
    }

    public void Resize()
    {
        rb = GetComponent<Rigidbody2D>();
        tran = GetComponent<Transform>();
    
        float mass = rb.mass;
        float radius = Mathf.Sqrt(mass) * sizeScale;
        Vector3 endScale = new Vector3(radius, radius, 1f);

        float blend = 1f - Mathf.Pow(1f - smooth, Time.deltaTime * 60);
        tran.localScale = Vector3.Lerp(tran.localScale,endScale,blend);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject particle;
    public bool isDestroyed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D thisRig = GetComponent<Rigidbody2D>();

        float thisMass = thisRig.mass;
        Vector2 thisVel = thisRig.velocity;

        float otherMass = collision.collider.attachedRigidbody.mass;
        Vector2 otherVel = collision.collider.attachedRigidbody.velocity;

        float newMass = thisMass + otherMass;

        if(thisMass < otherMass && !collision.gameObject.GetComponent<ProjectileCollision>().isDestroyed)
        {
            isDestroyed = true;
            FindObjectOfType<Controller>().DestoryParticle(gameObject);
        } else if (thisMass == otherMass && !collision.gameObject.GetComponent<ProjectileCollision>().isDestroyed)
        {
            isDestroyed = true;
            FindObjectOfType<Controller>().DestoryParticle(gameObject);
        } else if(collision.gameObject.GetComponent<ProjectileCollision>().isDestroyed)
        {
            thisRig.mass = newMass;
            thisRig.velocity = (otherMass * otherVel + thisMass * thisVel) / newMass;
        }
    }
}

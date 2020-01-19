using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalEntity : Entity
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ActivatePhysics(false);
    }

    void ActivatePhysics(bool activate)
    {
        if (activate)
            rb.bodyType = RigidbodyType2D.Dynamic;
        else
            rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void TakeHit(HitInfo hitInfo)
    {
        base.TakeHit(hitInfo);
        ActivatePhysics(true);
    }
}

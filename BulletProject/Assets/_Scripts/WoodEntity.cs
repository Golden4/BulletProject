using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodEntity : Entity
{
    public override void TakeHit(HitInfo hitInfo)
    {
        base.TakeHit(hitInfo);
        Destroy(gameObject);
    }
}

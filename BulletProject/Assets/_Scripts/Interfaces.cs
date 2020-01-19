using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHittable
{
    void TakeHit(HitInfo hitInfo);
}


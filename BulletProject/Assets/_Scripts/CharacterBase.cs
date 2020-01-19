using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : Entity
{
    Rigidbody2D[] rbs;
    HingeJoint2D[] hjs;

    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody2D>();
        hjs = GetComponentsInChildren<HingeJoint2D>();
        DoRagdoll(false);
    }

    void DoRagdoll(bool activate)
    {
        for (int i = 0; i < rbs.Length; i++)
        {
            if(activate)
                rbs[i].bodyType = RigidbodyType2D.Dynamic;
            else
                rbs[i].bodyType = RigidbodyType2D.Kinematic;
        }

        for (int i = 0; i < hjs.Length; i++)
        {
            hjs[i].enabled = activate;
        }
    }

    public override void TakeHit(HitInfo hitInfo)
    {
        /*foreach (Transform transform in rbs)
        {
            hitInfo.hittedObject
        }*/

        DoRagdoll(true);
    }
}
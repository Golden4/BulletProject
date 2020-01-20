using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : Entity
{
    public GameAssets.Characters characterName;
    
    Rigidbody2D[] rbs;
    HingeJoint2D[] hjs;
    public GameObject[] IKsPoints;

    public bool isPlayer = false;

    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody2D>();
        hjs = GetComponentsInChildren<HingeJoint2D>();
    }

    public void InitAsPlayer()
    {
        isPlayer = true;
        for (int i = 0; i < IKsPoints.Length; i++)
        {
            IKsPoints[i].SetActive(true);
        }
    }

    public void InitAsEnemy()
    {
        isPlayer = false;
        Destroy(gameObject.GetComponent<Player>());

        for (int i = 0; i < IKsPoints.Length; i++)
        {
            IKsPoints[i].SetActive(false);
        }
    }

    private void Start()
    {
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
        if (isPlayer)
            return;

        DoRagdoll(true);
    }
}
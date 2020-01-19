using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IHittable
{
    public enum EntityType
    {
        Character,
        Wood,
        Dynamite,
        Physical
    }

    public EntityType type;
    
    public virtual EntityType GetEntityType()
    {
        return type;
    }

    public virtual void TakeHit(HitInfo hitInfo)
    {

    }

    public virtual void AddForce(Vector2 force)
    {

    }

    public virtual void AddForceAtPosition(Vector2 position, float force)
    {

    }

}


public class HitInfo
{
    public GameObject owner;
    public Transform hittedObject;
    public Vector2 point;
    public Vector2 direction;
    public float force;

    public HitInfo()
    {
    }
    

    public HitInfo(GameObject owner, Transform hittedObject, Vector2 point, Vector2 direction, float force)
    {
        this.owner = owner;
        this.hittedObject = hittedObject;
        this.point = point;
        this.direction = direction;
        this.force = force;
    }
}


public class GunShotHitInfo : HitInfo
{
    public Bullet bullet;
    public RaycastHit2D raycastHit;

    public GunShotHitInfo(Bullet bullet, RaycastHit2D raycastHit)
    {
        this.bullet = bullet;
        this.raycastHit = raycastHit;
    }
}

public class CollisionHitInfo : HitInfo
{
    public GameObject owner;
    public Collision2D collision;
}

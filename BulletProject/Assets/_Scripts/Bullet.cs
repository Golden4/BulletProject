using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [System.NonSerialized] public Gun gun;
    public float bulletRadius = .1f;
    public float bulletSpeed = 3;
    public LayerMask mask;
    public LayerMask maskWithoutPlayer;
    public int maxHitCount = 7;
    public float bulletForce = 1000;
    int curHitCount;
    Collider2D oldHit;
    IHittable lastHittable;

    public void Setup(Gun gun)
    {
        this.gun = gun;
    }

    private void FixedUpdate()
    {
        transform.position += transform.up * Time.fixedDeltaTime * bulletSpeed;

        //RaycastHit2D hit = Physics2D.Raycast(transform.position - (transform.up * bulletRadius), transform.up, bulletRadius * 2, mask);
        Vector3 directionVec = transform.up * bulletSpeed * Time.fixedDeltaTime;
        RaycastHit2D hit = Physics2D.Linecast(transform.position - directionVec, transform.position, mask);

        if(curHitCount == 0)
        {
            hit = Physics2D.Linecast(transform.position - directionVec, transform.position, maskWithoutPlayer);
        }

        if (hit.collider == null)
            return;
        

        if (!hit.collider.isTrigger)
            {
                OnHitColliderBlock(hit);
            }
    }

    void OnHitColliderBlock(RaycastHit2D hit)
    {
        bool needDestoy = false;
        bool needReflect = true;

        IHittable hittableObject = hit.transform.GetComponentInParent<IHittable>();

        if (hittableObject != null && lastHittable != hittableObject)
        {
            HitInfo hitInfo = new HitInfo(gameObject, hit.transform, hit.point, transform.up, bulletForce);
            hittableObject.TakeHit(hitInfo);
            //Примение силы
            

            //Проверка на отражание
            Entity entity = (Entity)hittableObject;
            if (entity)
            {
                switch(entity.GetEntityType()){
                    case Entity.EntityType.Physical:
                        needReflect = true;
                        break;
                    case Entity.EntityType.Character:
                        needReflect = false;
                        break;
                    case Entity.EntityType.Dynamite:
                        needDestoy = true;
                        break;
                    case Entity.EntityType.Wood:
                        needReflect = false;
                        break;
                }
            }

            lastHittable = hittableObject;
        }

        Rigidbody2D rb = hit.transform.GetComponent<Rigidbody2D>();

        if (rb)
        {
            rb.AddForceAtPosition(transform.up * 500, hit.point);
        }

        if (maxHitCount <= curHitCount)
        {
            needDestoy = true;
        }

        if (needDestoy)
            Die();
        else
        {
            if (needReflect && lastHittable != null && lastHittable != hittableObject)
            {
                curHitCount++;
                Vector3 reflectDir = Vector3.Reflect(transform.up, hit.normal.normalized);

                float angle = Quaternion.Angle(Quaternion.Euler(reflectDir), transform.rotation);

                transform.position = hit.point - (Vector2)transform.up * bulletRadius;

                ChangeDirection(reflectDir);
            }
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void ChangeDirection(Vector3 rot)
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, rot);
    }


    public void OnHit()
    {

    }
}

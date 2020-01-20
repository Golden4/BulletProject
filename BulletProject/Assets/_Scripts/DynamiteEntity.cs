using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteEntity : Entity
{

    float explodeRadius = 6;

    public override void TakeHit(HitInfo hitInfo)
    {
        base.TakeHit(hitInfo);
        Explode();
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, explodeRadius);

        for (int i = 0; i < collider2Ds.Length; i++)
        {
            Rigidbody2D rb = collider2Ds[i].GetComponent<Rigidbody2D>();
            if (rb)
                rb.AddForce(transform.position - collider2Ds[i].transform.position);
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }*/
}

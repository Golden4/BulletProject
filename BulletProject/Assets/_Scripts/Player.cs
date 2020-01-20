using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Gun handGunPrefab;

    public Transform handHolder;
    public Transform startHandPoint;
    Gun curGunInHand;

    public Transform handIk;

    private void Start()
    {
        curGunInHand = Instantiate(handGunPrefab.gameObject, handHolder, false).GetComponent<Gun>();
        curGunInHand.transform.localPosition = Vector3.zero;
        curGunInHand.transform.localScale = new Vector3(-curGunInHand.transform.localScale.x, curGunInHand.transform.localScale.y);
    }

    Vector2 mouseWorldPoint;
    Vector2 direction;
    private void Update()
    {
        mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (-(Vector2)startHandPoint.position + mouseWorldPoint).normalized;

        handIk.transform.position = (Vector2)startHandPoint.position + direction * 5;

        if (Input.GetMouseButtonDown(0))
        {
            curGunInHand.Shot(direction);
        }
    }


  /*  private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(mouseWorldPoint, .2f);

        Gizmos.DrawWireSphere(startHandPoint.position, .2f);


        Gizmos.DrawWireSphere((Vector2)curGunInHand.muzzlePoint.position + direction * 5, .2f);

    }*/
}

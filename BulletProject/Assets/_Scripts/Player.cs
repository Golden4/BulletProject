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

    private void Update()
    {
        Vector2 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (-(Vector2)startHandPoint.position + mouseWorldPoint).normalized;

        handIk.transform.position = direction * 20;

        if (Input.GetMouseButtonDown(0))
        {
            curGunInHand.Shot(direction);
        }
    }

}

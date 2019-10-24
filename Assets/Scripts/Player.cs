using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Player : MonoBehaviour
{

    public GameObject bullet;
    public GameObject shootPosition;
    public float shootSpeed = 1000f;
    public int playerHP = 3;
    public int playerAttack = 1;

    void Start() => shootPosition.transform.parent = transform.Find("Camera Left");

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Bullet のゲームオブジェクトを生成する
            GameObject bulletInstance = Instantiate<GameObject>(bullet);
            // 生成した Bullet の位置を shootPosition に合わせる
            bulletInstance.transform.position = shootPosition.transform.position;
            bulletInstance.GetComponent<Rigidbody>().AddForce(shootPosition.transform.forward * shootSpeed);
        }
    }
}


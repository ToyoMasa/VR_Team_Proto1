using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 1;
    public int enemyAttack = 1;
    public float enemySpeed = 1;

    private Player player;

    void Start()
    {
        // プレイヤーゲームオブジェクトを探し、Playerコンポーネント（クラス）をメンバ変数に格納する
        player = GameObject.Find("Main Camera").GetComponent<Player>();
    }

    void Update()
    {
        // プレイヤーの方を向く
        transform.LookAt(player.transform);
        // 自分の前方（forward）へ移動する
        transform.Translate(transform.forward * enemySpeed, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {

        GameObject collisionTarget = collision.gameObject;

        if (collisionTarget.name.Contains("Main Camera"))
        {
            // プレイヤーの HP を攻撃力分減らす
            collisionTarget.GetComponent<Player>().playerHP -= enemyAttack;
            collisionTarget.GetComponent<Enemy>().enemyHP -= player.playerAttack;
            // 自身(エネミー)を Scene 上から削除
            Destroy(gameObject);
        }
        else if (collisionTarget.name.Contains("Bullet"))
        {
            // 自身(エネミー)を Scene 上から削除
            Destroy(gameObject);
        }
    }

}

/// <summary>
/// プレイヤークラス
/// YuuhoAritomi
/// 2017/02/05
/// </summary>
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// プレイヤークラス
/// </summary>
public class Player : MonoBehaviour
{
    //ジャンプする力
    [SerializeField]
    private float m_jumpPower;
    //どこまで飛ぶか
    [SerializeField]
    private float m_maxJump;
    //ジャンプしているか？
    private bool m_isJump;

    //初期化
    public void Start()
    {
        m_isJump = false;
    }

    //更新
    private void Update()
    {
        RestrictJump();
    }

    //更新
    private void FixedUpdate()
    {
        Jump();
    }

    //他のコリジョンに当たっているときの処理
    private void OnCollisionEnter(Collision collision)
    {
        IsGround(collision);
    }

    private void RestrictJump()
    {
        if (m_isJump == false) return;

        Vector3 position = this.transform.localPosition;
        position.y = Math.Min(position.y, m_maxJump);
        this.transform.position = position;
    }

    //ジャンプ処理
    private void Jump()
    {

        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (m_isJump == false)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(0f, m_jumpPower, 0f);
            m_isJump = true;
        }
    }

    // 着地しているか？
    private void IsGround(Collision _col)
    {
        if (_col.transform.tag.Contains("Floor"))
        {
            m_isJump = false;
        }
    }
}

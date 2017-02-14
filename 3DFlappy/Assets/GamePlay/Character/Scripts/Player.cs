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
    [SerializeField]
    private HP_UI m_HP;
    //ジャンプする力
    [SerializeField]
    private float m_jumpPower;
    //どこまで飛ぶか
    [SerializeField]
    private float m_maxJump;
    //無敵時間
    [SerializeField]
    private float m_invincibleTime;
    //ジャンプしているか？
    private bool m_isJump;
    //攻撃したか？
    private bool m_isAttack;
    //無敵か？
    private bool m_isInvincible;
    //タイマー
    private Timer m_invincibleTimer;

    // エンディング開始
    // byさの
    [SerializeField]
    private EndingSprites m_endingSpite;

    //初期化
    public void Start()
    {
        m_isJump = false;
        m_isAttack = false;
        m_isInvincible = false;

        m_invincibleTimer = new Timer();
        m_invincibleTimer.SetTime(m_invincibleTime);
    }

    //更新
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_HP.Damage(1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            m_HP.Heal(1);
        }

        RestrictJump();

        Invincible();

        m_invincibleTimer.Update();

        StartEnding();
    }

    /// <summary>
    /// 攻撃しているか？
    /// </summary>
    /// <returns></returns>
    public bool IsAttack()
    {
        bool isAttack = m_isAttack;
        m_isAttack = false;
        return isAttack;
    }

    //更新
    private void FixedUpdate()
    {
        Jump();
    }

    //他のコリジョンに当たっているときの処理
    private void OnCollisionEnter(Collision collision)
    {
        IsHit_Ground(collision);

        IsHit_Enemy(collision);

        IsHit_Barrel(collision);

        IsHit_FireBall(collision);
    }

    //他のコリジョンに当たったときの処理
    private void OnTriggerEnter(Collider other)
    {
        IsHit_HealingItem(other);

        IsHit_InvincibleItem(other);
    }

    //ジャンプ高度を制限
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
            Rigidbody rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddForce(0f, m_jumpPower, 0f);
            m_isJump = true;
        }
    }

    //無敵処理
    private void Invincible()
    {
        if (!m_isInvincible) return;

        m_invincibleTimer.Start();

        if (!m_invincibleTimer.IsEnd()) return;

        m_invincibleTimer.Reset();
        m_isInvincible = false;
    }

    // 着地しているか？
    private void IsHit_Ground(Collision _col)
    {
        if (!_col.transform.tag.Contains("Floor")) return;

        m_isJump = false;
    }

    //樽に当たったときの処理
    private void IsHit_Barrel(Collision _col)
    {
        if (m_isInvincible) return;
        if (!_col.transform.tag.Contains("Barrel")) return;

        m_HP.Damage(1);
    }

    //火の玉に当たったときの処理
    private void IsHit_FireBall(Collision _col)
    {
        if (m_isInvincible) return;
        if (!_col.transform.tag.Contains("FireBall")) return;

        m_HP.Damage(1);
    }

    //エネミーに当たったときの処理
    private void IsHit_Enemy(Collision _col)
    {
        if (!_col.transform.tag.Contains("Enemy")) return;

        m_isAttack = true;
    }

    //回復アイテムを取った時の処理
    private void IsHit_HealingItem(Collider _other)
    {
        if (!_other.transform.tag.Contains("HealingItem")) return;

        m_HP.Heal(1);
    }

    //無敵アイテムを取ったときの処理
    private void IsHit_InvincibleItem(Collider _other)
    {
        if (!_other.transform.tag.Contains("InvincibleItem")) return;

        m_isInvincible = true;
    }

    // エンディング開始
    // byさの
    private void StartEnding()
    {
        if(m_HP.IsDead())
        m_endingSpite.SetEndingBeginFlag(true, true);
    }
}

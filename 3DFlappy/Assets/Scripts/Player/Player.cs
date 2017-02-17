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
    private GamePlayManager m_manager;
    [SerializeField]
    private GameObject m_healingEffect;
    [SerializeField]
    private GameObject m_invincibleEffect;
    [SerializeField]
    private GameObject m_speedUpEffect;
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
    [SerializeField]
    MeshRenderer m_PlayerMesh;
    //ジャンプしているか？
    private bool m_isJump;
    //攻撃したか？
    private bool m_isAttack;
    //無敵か？
    private bool m_isInvincible;
    //タイマー
    private Timer m_invincibleTimer;
    private bool m_isFlash;
    float m_knockTime;

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

        m_knockTime = 0f;
        m_isFlash = false;
    }

    //更新
    private void Update()
    {
        RestrictJump();

        if (m_manager.IsPlay() == false) return;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_HP.Damage(1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            m_HP.Heal(1);
        }

        Invincible();

        m_invincibleTimer.Update();

        Flash();
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
        if (m_manager.IsPlay() == false) return;

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

        IsHit_SpeedUpItem(other);

        IsHit_LaserBeam(other);
    }

    //ジャンプ高度を制限
    private void RestrictJump()
    {
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
            AudioManager.Instance.PlaySE("Jump", 0);
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
        Material material = m_PlayerMesh.material;
        material.color = new Color(1f, 1f, 0f, 1f);

        if (!m_invincibleTimer.IsEnd()) return;

        material.color = new Color(1f, 1f, 1f, 1f);
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

        AudioManager.Instance.PlaySE("PlayerDamage", 0f);
        m_HP.Damage(1);
        m_isFlash = true;
    }

    //火の玉に当たったときの処理
    private void IsHit_FireBall(Collision _col)
    {
        if (m_isInvincible) return;
        if (!_col.transform.tag.Contains("FireBall")) return;

        AudioManager.Instance.PlaySE("PlayerDamage", 0f);
        m_HP.Damage(1);
        m_isFlash = true;
    }

    //エネミーに当たったときの処理
    private void IsHit_Enemy(Collision _col)
    {
        if (!_col.transform.tag.Contains("Enemy")) return;

        AudioManager.Instance.PlaySE("EnemyDamage", 0f);
        m_isAttack = true;
    }

    //回復アイテムを取った時の処理
    private void IsHit_HealingItem(Collider _other)
    {
        if (!_other.transform.tag.Contains("HealingItem")) return;

        AudioManager.Instance.PlaySE("PowerUp", 0f);
        m_HP.Heal(1);
        m_healingEffect.SetActive(true);
    }

    //無敵アイテムを取ったときの処理
    private void IsHit_InvincibleItem(Collider _other)
    {
        if (!_other.transform.tag.Contains("InvincibleItem")) return;

        AudioManager.Instance.PlaySE("PowerUp", 0f);
        m_isInvincible = true;
        m_invincibleEffect.SetActive(true);
    }

    //スピードアップアイテムを取ったときの処理
    private void IsHit_SpeedUpItem(Collider _other)
    {
        if (!_other.transform.tag.Contains("SpeedUpItem")) return;

        AudioManager.Instance.PlaySE("PowerUp", 0f);
        m_speedUpEffect.SetActive(true);
    }

    // レーザーに当たったときの処理
    private void IsHit_LaserBeam(Collider _other)
    {
        if (m_isInvincible) return;
        if (!_other.tag.Contains("Laser")) return;

        m_HP.Damage(3);
        m_isFlash = true;
    }

    /// <summary>
    ///  被ダメージ後点滅
    /// </summary>
    private void Flash()
    {
        if (!m_isFlash) return;

        m_knockTime += 0.1f;

        if (m_knockTime % 0.5f <= 0.2f)
        {
            m_PlayerMesh.enabled = false;
        }
        else
        {
            m_PlayerMesh.enabled = true;
        }

        if (m_knockTime >= 4)
        {
            m_knockTime = 0;
            m_PlayerMesh.enabled = true;
            m_isFlash = false;
        }
    }
}

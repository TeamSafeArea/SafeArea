using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  敵クラス
///  by 佐野直樹
/// </summary>
public class EnemyAi : MonoBehaviour {
    [SerializeField]
    GamePlayManager m_manager;
    [SerializeField]    // バレル
    EnemyBarrel m_Barrel;   
    [SerializeField]    // レーザー
    EnemyLaser m_Laser;     
    [SerializeField]     // インターバルタイム値の最大と最小
    int m_MinInterval, m_MaxInterval;
    [SerializeField]    // HP
    HP_UI m_HP;
    [SerializeField]    // プレイヤー取得
    Player m_Player;
    [SerializeField]    // エンディング
    EndingSprites m_Ending;
    [SerializeField]
    MeshRenderer m_EnemyMesh;
    [SerializeField]
    float m_power;

    Timer m_Timer;  // タイマー
    bool m_IsAttack, m_IsFlash;
    float m_KnockTime;

    // Use this for initialization
    void Start () {
        m_Player = m_Player.GetComponent<Player>();
        m_KnockTime = 0;

        /* タイマーの初期化 */
        m_Timer = new Timer();
        m_Timer.SetTime(SetIntervalByRandom());
        m_Timer.Start();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_manager.IsPlay() == false) return;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_HP.Damage(1);
        }

        // ダメージ
        Damage();

        // 点滅
        Flash();

        // タイマー更新
        Timer();

        // 死んだか
        IsDead();
	}

    void FixedUpdate()
    {
        KnockBack();
    }

    /// <summary>
    ///  インターバル時間をランダムに設定
    /// </summary>
    /// <returns></returns>
    float SetIntervalByRandom()
    {
        float random = Random.Range(m_MinInterval, m_MaxInterval + 1);
        return random;
    }

    /// <summary>
    ///  攻撃がヒットしたかを取得
    /// </summary>
    /// <returns></returns>
    bool HitDamage()
    {
        return m_Player.IsAttack();
    }

    /// <summary>
    ///  ダメージとノックバック
    /// </summary>
    void Damage()
    {
        // ダメージフラグが立ったか
        if (!HitDamage()) return;

        // 立ってたら1ダメージ
         m_HP.Damage(1);
        m_IsAttack = true;
        m_IsFlash = true;
    }

    void KnockBack()
    {
        // 死んでたらノックバックしない
        if (!m_IsAttack) return;

        this.GetComponent<Rigidbody>().AddForce(Vector3.right * m_power, ForceMode.Impulse);

        m_IsAttack = false;
    }

    /// <summary>
    ///  被ダメージ後点滅
    /// </summary>
    void Flash()
    {
        if (!m_IsFlash) return;

        m_KnockTime += 0.1f;
        
        if(m_KnockTime % 0.5f <= 0.2f )
        {
            m_EnemyMesh.enabled = false;
        }
        else
        {
            m_EnemyMesh.enabled = true;
        }

        if(m_KnockTime >= 4)
        {
            m_KnockTime = 0;
            m_EnemyMesh.enabled = true;
            m_IsFlash = false;
        }
    }

    void Timer()
    {
        m_Timer.Update();

        // タイマーが終了していなければ攻撃しない
        if (!m_Timer.IsEnd()) return;

        /* HPが2以上ならバレル攻撃だけ */
        if(m_HP.GetHp() >= 2)
        {
            ShotBarrel();
            TimerReset();
            return;
        }

        /* HPが1以下ならバレルかレーザー */
        // 攻撃割合設定のための乱数決定
        int attackPattern = Random.Range(1, 101);

        /* ２割の確率でレーザー発射、それ以外はバレル */
        if (attackPattern >= 41) ShotBarrel();
        else ShotLaser();

        TimerReset();

    }

    /// <summary>
    ///  タイマーリセット
    /// </summary>
    void TimerReset()
    {
        m_Timer.SetTime(SetIntervalByRandom());
        m_Timer.Reset();
        m_Timer.Start();
    }

    /// <summary>
    ///  バレル発射
    /// </summary>
    void ShotBarrel()
    {
        m_Barrel.ShotBarrel();
    }

    /// <summary>
    ///  レーザー発射
    /// </summary>
    void ShotLaser()
    {
        m_Laser.Initialize();
    }

    /// <summary>
    ///  死んだか？
    /// </summary>
    private void IsDead()
    {
        if (m_HP.IsDead())
            m_Ending.SetEndingBeginFlag(true, false);
    }
}

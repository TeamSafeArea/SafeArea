using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃用アイテムクラス
/// Yuuho Aritomi
/// 2017/02/10
/// </summary>
public class AttackItem : MonoBehaviour
{
    [SerializeField]
    Vector3 m_power;

    //初期化
    private void Start() {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(m_power);
    }

    //更新
    private void Update() {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃用アイテム管理者クラス
/// Yuuho Aritomi
/// 2017/02/10
/// </summary>
public class AttackItemManager : ItemManager
{
    //衝突した時の処理
    private void OnCollisionEnter(Collision collision)
    {
        ObjectDestroy(
            transform.gameObject,
            collision.gameObject.tag.Contains("Player"));
        ObjectDestroy(
            transform.gameObject,
            collision.transform.tag.Contains("Enemy"));
    }
}

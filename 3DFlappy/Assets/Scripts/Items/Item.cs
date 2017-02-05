using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム
/// Yuuho Aritomi
/// 2017/02/06
/// </summary>
public class Item : MonoBehaviour
{
    //画面左上
    [SerializeField]
    Vector2 m_min;
    //画面右下
    [SerializeField]
    Vector2 m_max;
    
    //初期化
    private void Start()
    {
        ObjectStart();
    }
    
    //更新
    private void Update()
    {
        ObjectUpdate();

        Destroy();
    }

    //オブジェクト初期化
    virtual protected void ObjectStart()
    {

    }

    //オブジェクト更新
    virtual protected void ObjectUpdate()
    {

    }

    //削除処理
    private void Destroy()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        if (m_min.x > position.x)
        {
            DestroyObject();
            return;
        }
        if (m_min.y < position.y)
        {
            DestroyObject();
            return;
        }
        if (m_max.x < position.x)
        {
            DestroyObject();
            return;
        }
        if (m_max.y > position.y)
        {
            DestroyObject();
            return;
        }
    }

    //オブジェクトの削除
    private void DestroyObject()
    {
        Destroy(transform.gameObject);
    }
}

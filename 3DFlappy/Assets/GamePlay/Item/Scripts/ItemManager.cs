using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム管理者
/// Yuuho Aritomi
/// 2017/02/10
/// </summary>
public class ItemManager : MonoBehaviour {
    [SerializeField]
    protected Rect m_clamp;

	//初期化
	private void Start () {

	}
	
	//更新
	private void Update () {
        Clamp();
	}

    //衝突した時の処理
    private void OnTriggerEnter(Collider other)
    {
        ObjectDestroy(transform.gameObject, other.transform.tag.Contains("Player"));
    }

    //活動範囲
    private void Clamp() {
        Vector3 pos = transform.position;
        ObjectDestroy(transform.gameObject, m_clamp.x > pos.x, 1);
        ObjectDestroy(transform.gameObject, m_clamp.y < pos.y, 1);
        ObjectDestroy(transform.gameObject, m_clamp.width < pos.x, 1);
        ObjectDestroy(transform.gameObject, m_clamp.height > pos.y, 1);
    }

    //条件が合っていればオブジェクトを削除
    protected void ObjectDestroy(GameObject _obj, bool _flag, float _time = 0f) {
        if (!_flag) return;
        Destroy(_obj, _time);
    }
}

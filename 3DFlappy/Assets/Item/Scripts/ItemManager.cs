using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    [SerializeField]
    Rect m_clamp;

	//初期化
	private void Start () {
		
	}
	
	//更新
	private void Update () {
        Clamp();
	}

    //活動範囲
    private void Clamp() {
        Vector3 pos = transform.position;
        ObjectDestroy(transform.gameObject, m_clamp.x > pos.x, 1);
        ObjectDestroy(transform.gameObject, m_clamp.y < pos.y, 1);
        ObjectDestroy(transform.gameObject, m_clamp.width < pos.x, 1);
        ObjectDestroy(transform.gameObject, m_clamp.height > pos.y, 1);
    }

    protected void ObjectDestroy(GameObject _obj, bool _flag, float _time = 0f) {
        if (!_flag) return;
        Destroy(_obj, _time);
    }
}

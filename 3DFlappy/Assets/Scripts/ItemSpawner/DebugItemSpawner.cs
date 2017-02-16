using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デバッグ用アイテムスポナークラス
/// </summary>
public class DebugItemSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject m_p_barrel;
    [SerializeField]
    private GameObject m_e_barrel;
    [SerializeField]
    private GameObject m_p_fireBall;
    [SerializeField]
    private GameObject m_e_fireBall;
    [SerializeField]
    private GameObject m_healingItem;
    [SerializeField]
    private GameObject m_speedUpItem;
    [SerializeField]
    private GameObject m_invincibleItem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
            Instantiate(m_p_barrel, transform.position, m_p_barrel.transform.rotation);
        if (Input.GetKeyDown(KeyCode.F2))
            Instantiate(m_e_barrel, transform.position, m_e_barrel.transform.rotation);
        if (Input.GetKeyDown(KeyCode.F3))
            Instantiate(m_p_fireBall, transform.position, m_p_fireBall.transform.rotation);
        if (Input.GetKeyDown(KeyCode.F4))
            Instantiate(m_e_fireBall, transform.position, m_e_fireBall.transform.rotation);
        if (Input.GetKeyDown(KeyCode.F5))
            Instantiate(m_healingItem, transform.position, m_healingItem.transform.rotation);
        if (Input.GetKeyDown(KeyCode.F6))
            Instantiate(m_speedUpItem, transform.position, m_speedUpItem.transform.rotation);
        if (Input.GetKeyDown(KeyCode.F7))
            Instantiate(m_invincibleItem, transform.position, m_invincibleItem.transform.rotation);
    }
}

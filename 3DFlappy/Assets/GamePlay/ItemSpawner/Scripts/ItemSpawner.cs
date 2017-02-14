using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムスポナークラス
/// Yuuho Aritomi
/// 2017/02/10
/// </summary>
public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GamePlayManager m_manager;
    //アイテムコンテナ
    [SerializeField]
    private List<GameObject> m_itemContainer;
    //アイテムのスポーン間隔
    [SerializeField]
    private float m_spawnTime;

    //開始
    void Start()
    {
        StartCoroutine("CreateItem");
    }

    //更新
    void Update()
    {

    }

    //アイテムを一定間隔で生成する
    private IEnumerator CreateItem()
    {
        while (true)
        {
            if (m_itemContainer.Count == 0) yield break; ;

            if (m_manager.IsPlay() == true)
            {
                int index = Random.Range(0, m_itemContainer.Count);
                Instantiate(m_itemContainer[index], transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(m_spawnTime);
        }
    }
}

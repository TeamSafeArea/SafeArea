using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フロアクラス
/// Yuuho Aritomi
/// 2017/02/10
/// </summary>
public class Floor : MonoBehaviour {
    [SerializeField]
    private GamePlayManager m_manager;
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private Rect m_rect;
    private float x;
    private Renderer m_renderer;
    private Material m_material;
    private int m_textureWidth, m_textureHeight;

	//初期化
	void Start () {
        x = 0f;
        m_renderer = this.GetComponent<Renderer>();
        m_material = m_renderer.material;
        Texture texture = m_material.mainTexture;
        m_textureWidth = texture.width;
        m_textureHeight = texture.height;

        Vector2 offset = new Vector2(m_rect.x / m_textureWidth, m_rect.y / m_textureHeight);
        Vector2 scale = new Vector2(m_rect.width / m_textureWidth, m_rect.height / m_textureHeight);
        m_material.SetTextureOffset("_MainTex", offset);
        m_material.SetTextureScale("_MainTex", scale);
    }
	
	//初期化
	void Update () {
        if (m_manager.IsPlay() == false) return;

        x += m_speed;
        m_rect.x = x;
        Vector2 offset = new Vector2(m_rect.x / m_textureWidth, m_rect.y / m_textureHeight);
        Vector2 scale = new Vector2(m_rect.width / m_textureWidth, m_rect.height / m_textureHeight);
        m_material.SetTextureOffset("_MainTex", offset);
        m_material.SetTextureScale("_MainTex", scale);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* スター〇ォーズ風のスクロール */
public class StarScroll_Wall : MonoBehaviour {

    RectTransform fRectPosition; // 微妙
    [SerializeField]
    Image[] fStaffNameImage;// スタッフロールの画像
    [SerializeField]
    float fScrollSpeed;     // スクロールスピード

	// Use this for initialization
	void Start () {
        fRectPosition = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        Scroll();
        Scaler();
        
        // 位置を取って、いつ戻るか
        if (fRectPosition.localPosition.y <= 1300) return;

        SceneManager.LoadScene("TitleScene");
	}


    void Scroll()
    {
        // 上スクロール
        transform.position += new Vector3(0, fScrollSpeed, 0);
    }

    void Scaler()
    {
        // 小さくしていく
        transform.localScale -= new Vector3(0.0005f, 0.0005f, 0);
    }
}

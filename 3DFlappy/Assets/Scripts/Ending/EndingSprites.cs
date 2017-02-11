using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* === エンディング処理 === */
public class EndingSprites : MonoBehaviour {

    public Image fWinImageSprite;
    public Image fDefeatedSprite;
    public GameObject fReturnTitleButton;

    Color fNowColor;
    float fPlayerHp;    
    bool fBeginEnding;

    // Use this for initialization
    void Start () {
        fBeginEnding = false;
        fWinImageSprite = fWinImageSprite.GetComponent<Image>();
        fDefeatedSprite = fDefeatedSprite.GetComponent<Image>();
        fNowColor = fWinImageSprite.GetComponent<Image>().color;
	}
	
	// Update is called once per frame
	void Update () {
        IsWin();
	}

    void IsWin()
    {
        // 開始フラグ
        if (!fBeginEnding) return;

        // プレイヤーの残HPが０より上なら勝ち
        if (fPlayerHp > 0)
        {
            SpriteWin();
        }
        else
        {
            SpriteDefeated();
        }
    }

    // 勝ちのパターン
    void SpriteWin()
    {
        /* 今の色を保存し、そのアルファ値をいじり適用する */
        fNowColor = fWinImageSprite.GetComponent<Image>().color;
        fNowColor.a += 0.01f;
        fWinImageSprite.color = fNowColor;

        // アルファ値が最大値ならボタン有効
        if (fWinImageSprite.color.a >= 2)   // アルファ値は最大255のはず。なぜかUnityでは１？
        {   
            fReturnTitleButton.SetActive(true);
        }

    }

    // 負けのパターン
    void SpriteDefeated()
    {
        /* 今の色を保存し、そのアルファ値をいじり適用する */
        fNowColor = fDefeatedSprite.GetComponent<Image>().color;
        fNowColor.a += 0.01f;
        fDefeatedSprite.color = fNowColor;

        // アルファ値が最大値ならボタン有効
        if (fDefeatedSprite.color.a >= 2)
        {
            fReturnTitleButton.SetActive(true);
        }
    }

    /// <summary>
    ///  エンディング開始するか
    /// </summary>
    /// <param name="_flag">trueで開始</param>
    /// <param name="_playerHp">プレイヤーのHPをいれる</param>
    public void SetEndingBeginFlag(bool _flag, float _playerHp)
    {
        fBeginEnding = _flag;
        _playerHp = fPlayerHp;
    }

}

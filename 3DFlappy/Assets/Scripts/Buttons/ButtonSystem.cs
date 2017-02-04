using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSystem : MonoBehaviour {

    [SerializeField]
    private Button[] buttons; // ボタンの配列
    private int buttonsCount; // ボタンの個数を取る
    private int nowButton;    // 選択ボタン

    void Start()
    {
        nowButton = 0; // 選択ボタン番号初期化
        buttonsCount = buttons.Length;  // ボタン個数を設定
    }

     void Update()
    {
        HighLightButtons(nowButton);
        SelectButtons();
    }

    /// <summary>
    ///  ボタンの選択
    /// </summary>
    /// <returns></returns>
    int SelectButtons()
    {
        /* 上下キーの処理 */
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {   
            nowButton += 1;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {   
            nowButton -= 1;
        }

        /* 最下段から最上段、またはその反対 */
        if (nowButton >= buttons.Length)
        {
            nowButton = 0;
        }
        else if (nowButton <= -1)
        {
            nowButton = buttons.Length-1;
        }
        return nowButton;
    }

    /// <summary>
    ///  ボタンをハイライト
    /// </summary>
    /// <param name="now">今の選択ボタン</param>
    void HighLightButtons(int now)
    {
        // 今のボタン番号を選択状態にする
        buttons[now].Select();
    }
}

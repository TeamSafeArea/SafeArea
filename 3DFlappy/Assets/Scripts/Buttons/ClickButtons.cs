using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickButtons : MonoBehaviour {

    protected int nowButton;      // ボタン番号
    protected string nowSceneName;// ロード中のシーン名

	// Use this for initialization
	void Start () {
        // 今のシーン名を取得
        nowSceneName = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void SelectBySceneName()
    {
        AudioManager.Instance.PlaySE("Decision", 0f);

        switch (nowSceneName)
        {
            case "TitleScene":
                TitleButton();
                break;
            case "GamePlayScene":
                SceneManager.LoadScene("TitleScene");
                break;
            case "StaffRollScene":
                SceneManager.LoadScene("StaffRollScene");
                break;
        }
    }


    void TitleButton()
    {
        nowButton = GetComponent<ButtonSystem>().GetNowButton();

        if(nowButton == 0)
        {
            SceneManager.LoadScene("GamePlayScene");
        }
        else if(nowButton == 1)
        {
            SceneManager.LoadScene("StaffRollScene");
        }
        else if(nowButton == 2)
        {
            Application.Quit();
        }
    }
}

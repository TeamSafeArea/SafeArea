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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (nowSceneName == "GamePlayScene" || nowSceneName == "StaffRollScene" || nowSceneName == "TutorialScene")
            {
                AudioManager.Instance.PlaySE("Decision", 0f);
                SceneManager.LoadScene("TitleScene");
            }
        }

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
                SceneManager.LoadScene("TitleScene");
                break;
            case "TutorialScene":
                SceneManager.LoadScene("TitleScene");
                break;
        }
    }

    public void GoGamePlay()
    {
        AudioManager.Instance.PlaySE("Decision", 0f);
        SceneManager.LoadScene("GamePlayScene");
    }

    public void GoSaffRoll()
    {
        AudioManager.Instance.PlaySE("Decision", 0f);
        SceneManager.LoadScene("StaffRollScene");
    }

    public void GoTrutorial()
    {
        AudioManager.Instance.PlaySE("Decision", 0f);
        SceneManager.LoadScene("TutorialScene");
    }


    public void Exit()
    {
        Application.Quit();
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
            SceneManager.LoadScene("TutorialScene");
        }
        else if(nowButton == 3)
        {
            Application.Quit();
        }
    }
}

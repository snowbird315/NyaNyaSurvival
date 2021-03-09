using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //定数定義
    public const int WALL_JOB = 0; //画面：バイト
    public const int WALL_SHOPPING = 1; //画面：買い物
    public const int WALL_GAME = 2; //画面：娯楽
    public const int WALL_SLEEP = 3; //画面：就寝
    public const int WALL_OPTION = 4; //画面：設定
    public const int WALL_PANS = 5; //画面：買い物：食料
    public const int WALL_MASK = 6; //画面：買い物：マスク
    public const int WALL_KADENS = 7; //画面：買い物：家電
    public const int WALL_GAMES = 8; //画面：買い物：娯楽品


    //ゲームオブジェクト
    public GameObject panelWalls; //パネル：壁
    public Slider sliderInfection; //スライダー：感染率
    public Slider sliderStress; //スライダー：ストレス
    public GameObject buttonJobs; //ボタン：バイト
    public GameObject buttonShoppings; //ボタン：買い物
    public GameObject buttonGames; //ボタン：娯楽
    public GameObject buttonSleeps; //ボタン：就寝
    public GameObject buttonOptions; //ボタン：設定
    public GameObject buttonShoppingPans; //ボタン：買い物：食料
    public GameObject buttonShoppingMasks; //ボタン：買い物：マスク
    public GameObject buttonShoppingKadens; //ボタン：買い物：家電
    public GameObject buttonShoppingGames; //ボタン：買い物：娯楽品
    public GameObject buttonShoppingBack; //ボタン：買い物：戻る
    public GameObject textCoin; //テキスト：お金
    public GameObject textPan; //テキスト：食料
    public GameObject textMask; //テキスト：マスク
    public GameObject textDate; //テキスト：日付
    public GameObject textTime; //テキスト：時間
    public GameObject nukoComment; //テキスト付きぬこ
    public GameObject textShoppingPan; //テキスト：買い物：食料
    public GameObject textShoppingMask; //テキスト：買い物：マスク


    //変数
    private int wallNo; //現在の画面
    private int coin; //お金
    private int pan; //食料
    private int mask; //マスク
    private int date; //日付
    private bool time; //時間：true,午前：false,午後
    private int infection; //感染率
    private int stress; //ストレス
    private int count; //個数


    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_SLEEP;

        coin = 0; //pp候補
        pan = 5;
        mask = 5;
        date = 1;
        time = true;
        infection = 0;
        stress = 0;

        TotalUpdate();
        WallUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //バイトボタンをプッシュ
    public void PushButtonJob()
    {
        UIUpdate();
        wallNo = WALL_JOB;
        WallUpdate();
    }

    //買い物ボタンをプッシュ
    public void PushButtonShopping()
    {
        UIUpdate();
        wallNo = WALL_SHOPPING;
        WallUpdate();
    }

    //娯楽ボタンをプッシュ
    public void PushButtonGame()
    {
        UIUpdate();
        wallNo = WALL_GAME;
        WallUpdate();
    }

    //就寝ボタンをプッシュ
    public void PushButtonSleep()
    {
        UIUpdate();
        wallNo = WALL_SLEEP;
        WallUpdate();
    }

    //設定ボタンをプッシュ
    public void PushButtonOption()
    {
        UIUpdate();
        wallNo = WALL_OPTION;
        WallUpdate();
    }

    //バイト内容ボタンをプッシュ
    public void PushButtonJobWage(int wage)
    {
        if(mask > 0 && pan > 0)
        {
            coin += wage;
        }
    }
    public void PushButtonJobInfection(int count)
    {
        if(mask > 0 && pan > 0)
        {
            infection += count;
            mask -= 1;
            pan -= 1;
            time = !time;
            if (time)
            {
                date += 1;
            }

            TotalUpdate();
        }
    }

    //買い物：食料ボタンをプッシュ
    public void PushButtonShoppingPan()
    {
        UIUpdate();
        wallNo = WALL_PANS;
        WallUpdate();
    }

    //買い物：マスクボタンをプッシュ
    public void PushButtonShoppingMask()
    {
        UIUpdate();
        wallNo = WALL_MASK;
        WallUpdate();
    }

    //買い物：家電ボタンをプッシュ
    public void PushButtonShoppingKaden()
    {
        UIUpdate();
        wallNo = WALL_KADENS;
        WallUpdate();
    }

    //買い物：娯楽品ボタンをプッシュ
    public void PushButtonShoppingGame()
    {
        UIUpdate();
        wallNo = WALL_GAMES;
        WallUpdate();
    }

    //買い物：戻るボタンをプッシュ
    public void PushButtonShoppingBack()
    {
        UIUpdate();
        wallNo = WALL_SHOPPING;
        WallUpdate();
    }

    //プラスボタンをプッシュ
    public void PushButtonPlus()
    {
        count += 1;
    }

    //マイナスボタンをプッシュ
    public void PushButtonMinus()
    {
        if(count > 0)
        {
            count -= 1;
        }
    }

    //まとめて更新
    void TotalUpdate()
    {
        CoinUpdate();
        PanUpdate();
        MaskUpdate();
        DateUpdate();
        TimeUpdate();
        SliderInfectionUpdate();
        SliderStressUpdate();
    }

    //画面更新(表示)
    void WallUpdate()
    {
        switch (wallNo)
        {
            case WALL_JOB:
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                buttonJobs.SetActive(true);
                nukoComment.SetActive(true);
                break;
            case WALL_SHOPPING:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                buttonShoppings.SetActive(true);
                nukoComment.SetActive(true);
                break;
            case WALL_GAME:
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                buttonGames.SetActive(true);
                nukoComment.SetActive(true);
                break;
            case WALL_SLEEP:
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                buttonSleeps.SetActive(true); 
                nukoComment.SetActive(false);
                break;
            case WALL_OPTION:
                panelWalls.transform.localPosition = new Vector3(-4000.0f, 0.0f, 0.0f);
                buttonOptions.SetActive(true);
                nukoComment.SetActive(false);
                break;
            case WALL_PANS:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 1500.0f, 0.0f);
                buttonShoppingPans.SetActive(true);
                nukoComment.SetActive(true);
                buttonShoppingBack.SetActive(true);
                count = 0;
                break;
            case WALL_MASK:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 3000.0f, 0.0f);
                buttonShoppingMasks.SetActive(true);
                nukoComment.SetActive(true);
                buttonShoppingBack.SetActive(true);
                count = 0;
                break;
            case WALL_KADENS:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 4500.0f, 0.0f);
                buttonShoppingKadens.SetActive(true);
                nukoComment.SetActive(true);
                buttonShoppingBack.SetActive(true);
                break;
            case WALL_GAMES:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 6000.0f, 0.0f);
                buttonShoppingGames.SetActive(true);
                nukoComment.SetActive(true);
                buttonShoppingBack.SetActive(true);
                break;
        }
    }

    //画面更新(非表示)
    void UIUpdate()
    {
        switch (wallNo)
        {
            case WALL_JOB:
                buttonJobs.SetActive(false);
                break;
            case WALL_SHOPPING:
                buttonShoppings.SetActive(false);
                break;
            case WALL_GAME:
                buttonGames.SetActive(false);
                break;
            case WALL_SLEEP:
                buttonSleeps.SetActive(false);
                break;
            case WALL_OPTION:
                buttonOptions.SetActive(false);
                break;
            case WALL_PANS:
                buttonShoppingPans.SetActive(false);
                buttonShoppingBack.SetActive(false);
                break;
            case WALL_MASK:
                buttonShoppingMasks.SetActive(false);
                buttonShoppingBack.SetActive(false);
                break;
            case WALL_KADENS:
                buttonShoppingKadens.SetActive(false);
                buttonShoppingBack.SetActive(false);
                break;
            case WALL_GAMES:
                buttonShoppingGames.SetActive(false);
                buttonShoppingBack.SetActive(false);
                break;
        }
    }

    //感染率更新
    void SliderInfectionUpdate()
    {
        sliderInfection.value = infection / 100.0f;
    }

    //ストレス更新
    void SliderStressUpdate()
    {
        sliderStress.value = stress / 100.0f;
    }

    //日付更新
    void DateUpdate()
    {
        Text targetText = textDate.GetComponent<Text>();
        targetText.text = date + "日目";
    }

    //時間更新
    void TimeUpdate()
    {
        Text targetText = textTime.GetComponent<Text>();
        if (time)
        {
            targetText.text = "午前";
            targetText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        else
        {
            targetText.text = "午後";
            targetText.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }
    }

    //お金更新
    void CoinUpdate()
    {
        Text targetText = textCoin.GetComponent<Text>();
        targetText.text = coin + "円";
    }

    //食料更新
    void PanUpdate()
    {
        Text targetText = textPan.GetComponent<Text>();
        targetText.text = pan + "食";
    }

    //マスク更新
    void MaskUpdate()
    {
        Text targetText = textMask.GetComponent<Text>();
        targetText.text = mask + "枚";
    }

    //買い物：食料個数更新
    public void PanShoppingUpdate()
    {
        Text targetText = textShoppingPan.GetComponent<Text>();
        targetText.text = count + "食";
    }

    //買い物：マスク個数更新
    public void MaskShoppingUpdate()
    {
        Text targetText = textShoppingMask.GetComponent<Text>();
        targetText.text = count + "枚";
    }
}

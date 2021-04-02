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

    private const int PAN = 300; //金額：食料
    private const int MASK = 200; //金額：マスク
    private const int FUTON = 5000; //金額：布団
    private const int DESK = 7500; //金額：机
    private const int FLEEZER = 10000; //金額：冷蔵庫
    private const int TRUMP = 500; //金額：トランプ
    private const int SHOUGI = 2000; //金額：将棋
    private const int VIDEO = 10000; //金額：テレビ
    private const int GAME = 15000; //金額：据置型ゲーム


    //ゲームオブジェクト
    public GameObject panelWalls; //パネル：壁
    public Slider sliderInfection; //スライダー：感染率
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
    public GameObject textInfection; //テキスト：感染
    public GameObject pause; //ポーズ用画像UI
    public GameObject buttonReset;

    public GameObject textCoin; //テキスト：お金
    public GameObject textPan; //テキスト：食料
    public GameObject textMask; //テキスト：マスク
    public GameObject textDate; //テキスト：日付
    public GameObject textTime; //テキスト：時間
    public GameObject textNuko; //テキスト：ぬこ
    public GameObject imageNuko; //画像：ぬこ
    public GameObject nukoComment; //ぬこ全部
    public GameObject nuko;
    public GameObject textShoppingPan; //テキスト：買い物：食料：個数
    public GameObject textShoppingMask; //テキスト：買い物：マスク：個数
    public GameObject textShoppingTotalPan; //テキスト：買い物：食料：金額
    public GameObject textShoppingTotalMask; //テキスト：買い物：マスク：金額

    public GameObject imageFuton; //画像：布団
    public GameObject imageFleezer; //画像：冷蔵庫
    public GameObject imageDesk; //画像：机
    public GameObject imageTrump; //画像：トランプ
    public GameObject imageShougi; //画像：将棋
    public GameObject imageVideo; //画像：テレビ
    public GameObject imageGame; //画像：ゲーム


    //変数
    private int wallNo; //現在の画面
    private int coin; //お金
    private int pan; //食料
    private int mask; //マスク
    private int date; //日付
    private bool time; //時間：true,午前：false,午後
    private float infection; //感染率
    private int count; //個数
    private bool trump; //トランプ
    private bool shougi; //将棋
    private bool video; //テレビ
    private bool game; //据置型ゲーム
    private bool sleep; //睡眠：true,寝れる：false,寝れない
    private bool futon; //布団
    private bool fleezer; //冷蔵庫
    private bool desk; //机
    private int status; //状況
    private float percent; //ストレス係数(?)

    private int DATEs;
    private int TIMEs;
    private int TRUMPs;
    private int SHOUGIs;
    private int VIDEOs;
    private int GAMEs;
    private int SLEEPs;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_SLEEP;
        animator = nuko.GetComponent<Animator>();

        if (PlayerPrefs.HasKey("COIN"))
        {
            coin = PlayerPrefs.GetInt("COIN");
            pan = PlayerPrefs.GetInt("PAN");
            mask = PlayerPrefs.GetInt("MASK");
            date = PlayerPrefs.GetInt("DATE");
            TIMEs = PlayerPrefs.GetInt("TIME");
            infection = PlayerPrefs.GetFloat("INFECTION");
            TRUMPs = PlayerPrefs.GetInt("TRUMP");
            SHOUGIs = PlayerPrefs.GetInt("SHOUGI");
            VIDEOs = PlayerPrefs.GetInt("VIDEO");
            GAMEs = PlayerPrefs.GetInt("GAME");
            SLEEPs = PlayerPrefs.GetInt("SLEEP");
            status = PlayerPrefs.GetInt("STATUS");
            percent = PlayerPrefs.GetFloat("PERCENT");

            if(TIMEs == 1)
            {
                time = true;
            }
            else
            {
                time = false;
            }

            if(TRUMPs == 1)
            {
                trump = true;
            }
            else
            {
                trump = false;
            }

            if (SHOUGIs == 1)
            {
                shougi = true;
            }
            else
            {
                shougi = false;
            }

            if (VIDEOs == 1)
            {
                video = true;
            }
            else
            {
                video = false;
            }

            if (GAMEs == 1)
            {
                game = true;
            }
            else
            {
                game = false;
            }

            if(SLEEPs == 1)
            {
                sleep = true;
            }
            else
            {
                sleep = false;
            }
        }
        else
        {
            coin = 0; 
            pan = 5;
            mask = 5;
            date = 1;
            time = true;
            infection = 0;
            trump = false;
            shougi = false;
            video = false;
            game = false;
            sleep = true;
            status = -1;
            percent = 1;

            PlayerPrefs.SetInt("COIN", coin);
            PlayerPrefs.SetInt("PAN",pan);
            PlayerPrefs.SetInt("MASK",mask);
            PlayerPrefs.SetInt("DATE",date);
            PlayerPrefs.SetInt("TIME",1);
            PlayerPrefs.SetFloat("INFECTION",infection);
            PlayerPrefs.SetInt("TRUMP",0);
            PlayerPrefs.SetInt("SHOUGI",0);
            PlayerPrefs.SetInt("VIDEO",0);
            PlayerPrefs.SetInt("GAME",0);
            PlayerPrefs.SetInt("SLEEP",1);
            PlayerPrefs.SetInt("STATUS",status);
            PlayerPrefs.SetFloat("PERCENT",percent);
        }


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
            if(status == WALL_JOB)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_JOB;
            infection += count * percent;
            mask -= 1;
            pan -= 1;
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
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

    //買い物：パン：購入ボタンをプッシュ
    public void PushButtonShoppingPanBuy()
    {
        if(count * PAN <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            pan += count;
            coin -= count * PAN;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //買い物：マスク：購入ボタンをプッシュ
    public void PushButtonShoppingMaskBuy()
    {
        if (count * MASK <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            mask += count;
            coin -= count * MASK;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //買い物：家電：布団ボタンをプッシュ
    public void PushButtonShoppingFutonBuy()
    {
        if (!futon && FUTON <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            futon = true;
            coin -= FUTON;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            imageFuton.SetActive(true);
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //買い物：家電：机ボタンをプッシュ
    public void PushButtonShoppingDeskBuy()
    {
        if (!desk && DESK <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            desk = true;
            coin -= DESK;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            imageDesk.SetActive(true);
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //買い物：家電：冷蔵庫ボタンをプッシュ
    public void PushButtonShoppingFleezerBuy()
    {
        if(!fleezer && FLEEZER <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            fleezer = true;
            coin -= FLEEZER;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            imageFleezer.SetActive(true);
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //買い物：娯楽：トランプボタンをプッシュ
    public void PushButtonShoppingTrumpBuy()
    {
        if (!trump && TRUMP <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            trump = true;
            coin -= TRUMP;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            imageTrump.SetActive(true);
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //買い物：娯楽：将棋ボタンをプッシュ
    public void PushButtonShoppingShougiBuy()
    {
        if (!shougi && SHOUGI <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            shougi = true;
            coin -= SHOUGI;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            imageShougi.SetActive(true);
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //買い物：娯楽：テレビボタンをプッシュ
    public void PushButtonShoppingVideoBuy()
    {
        if (!video && VIDEO <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            video = true;
            coin -= VIDEO;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            imageVideo.SetActive(true);
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //買い物：娯楽：据置型ゲームボタンをプッシュ
    public void PushButtonShoppingGameBuy()
    {
        if (!game && GAME <= coin && pan > 0 && mask > 0)
        {
            if (status == WALL_SHOPPING)
            {
                percent *= 1.25f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_SHOPPING;
            game = true;
            coin -= GAME;
            pan -= 1;
            mask -= 1;
            infection += 10 * percent;
            imageGame.SetActive(true);
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //娯楽：トランプボタンをプッシュ
    public void PushButtonGameTramp()
    {
        if (trump && pan > 0)
        {
            if (status == WALL_GAME)
            {
                percent *= 0.75f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_GAME;
            infection -= 5 * percent;
            pan -= 1;
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //娯楽：将棋ボタンをプッシュ
    public void PushButtonGameShougi()
    {
        if (shougi && pan > 0)
        {
            if (status == WALL_GAME)
            {
                percent *= 0.75f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_GAME;
            infection -= 10 * percent;
            pan -= 1;
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //娯楽：映画ボタンをプッシュ
    public void PushButtonGameVideo()
    {
        if (video && pan > 0)
        {
            if (status == WALL_GAME)
            {
                percent *= 0.75f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_GAME;
            infection -= 12 * percent;
            pan -= 1;
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //娯楽：据置型ゲームボタンをプッシュ
    public void PushButtonGameGame()
    {
        if (game && video && pan > 0)
        {
            if (status == WALL_GAME)
            {
                percent *= 0.75f;

            }
            else
            {
                percent = 1;
            }
            status = WALL_GAME;
            infection -= 15 * percent;
            pan -= 1;
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
        }
    }

    //就寝：就寝ボタンをプッシュ
    public void PushButtonSleepSleep()
    {
        if (sleep && pan > 0)
        {
            infection -= 10;
            pan -= 1;
            if (InfectionCheck())
            {
                Tomorrow();
                PushButtonSleep();
            }
            sleep = false;
        }
    }

    //感染：リセットボタンをプッシュ
    public void PushButtonReset()
    {
        Reset();
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
    }

    //画面更新(表示)
    void WallUpdate()
    {
        switch (wallNo)
        {
            case WALL_JOB:
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                buttonJobs.SetActive(true);
                break;
            case WALL_SHOPPING:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                buttonShoppings.SetActive(true);
                break;
            case WALL_GAME:
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                buttonGames.SetActive(true);
                break;
            case WALL_SLEEP:
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                buttonSleeps.SetActive(true);

                Random.InitState(System.DateTime.Now.Millisecond);

                int r = Random.Range(1, 3);

                if (r == 1)
                {
                    animator.SetTrigger("walkright");
                }
                else
                {
                    animator.SetTrigger("walkleft");
                }
                break;
            case WALL_OPTION:
                panelWalls.transform.localPosition = new Vector3(-4000.0f, 0.0f, 0.0f);
                buttonOptions.SetActive(true);
                break;
            case WALL_PANS:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 1500.0f, 0.0f);
                buttonShoppingPans.SetActive(true);
                buttonShoppingBack.SetActive(true);
                count = 0;
                break;
            case WALL_MASK:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 3000.0f, 0.0f);
                buttonShoppingMasks.SetActive(true);
                buttonShoppingBack.SetActive(true);
                count = 0;
                break;
            case WALL_KADENS:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 4500.0f, 0.0f);
                buttonShoppingKadens.SetActive(true);
                buttonShoppingBack.SetActive(true);
                break;
            case WALL_GAMES:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 6000.0f, 0.0f);
                buttonShoppingGames.SetActive(true);
                buttonShoppingBack.SetActive(true);
                break;
        }
        NukoUpdate();
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

    //ぬこ更新
    void NukoUpdate()
    {
        Text targetText = textNuko.GetComponent<Text>();

        switch (wallNo)
        {
            case WALL_JOB:
                nukoComment.SetActive(true);
                if(mask < 1)
                {
                    targetText.text = "マスクがないにゃ";
                }
                else if(pan < 1)
                {
                    targetText.text = "食べ物がないにゃ";
                }
                else if(infection == 100)
                {
                    targetText.text = "感染するにゃ…";
                }
                else if(infection > 80)
                {
                    targetText.text = "もう感染しそうにゃ…";
                }
                else if(infection > 60)
                {
                    targetText.text = "そろそろ感染しそうにゃ…";
                }
                else if(infection > 40)
                {
                    targetText.text = "感染するかもにゃ…";
                }
                else if(infection > 20)
                {
                    targetText.text = "感染怖いにゃ";
                }
                else
                {
                    targetText.text = "お金稼ぐにゃ";
                }
                break;

            case WALL_SHOPPING:
                nukoComment.SetActive(true);
                if (mask < 1)
                {
                    targetText.text = "マスクがないにゃ";
                }
                else if (pan < 1)
                {
                    targetText.text = "食べ物がないにゃ";
                }
                else if (infection == 100)
                {
                    targetText.text = "感染するにゃ…";
                }
                else if (infection > 80)
                {
                    targetText.text = "もう感染しそうにゃ…";
                }
                else if (infection > 60)
                {
                    targetText.text = "そろそろ感染しそうにゃ…";
                }
                else if (infection > 40)
                {
                    targetText.text = "感染するかもにゃ…";
                }
                else if (infection > 20)
                {
                    targetText.text = "感染怖いにゃ";
                }
                else
                {
                    if(coin < MASK)
                    {
                        targetText.text = "お金ないにゃ";
                    }
                    else
                    {
                        targetText.text = "買い物するにゃ";
                    }
                }
                break;

            case WALL_GAME:
                nukoComment.SetActive(true);
                if(!(trump || shougi || video || game)){
                    targetText.text = "遊ぶ物がないにゃ";
                }
                break;
            case WALL_SLEEP:
                nukoComment.SetActive(false);
                break;
            case WALL_OPTION:
                nukoComment.SetActive(false);
                break;
            case WALL_PANS:
                nukoComment.SetActive(true);
                if (mask < 1)
                {
                    targetText.text = "マスクがないにゃ";
                }
                else if (pan < 1)
                {
                    targetText.text = "食べ物がないにゃ";
                }
                else if (infection == 100)
                {
                    targetText.text = "感染するにゃ…";
                }
                else if (infection > 80)
                {
                    targetText.text = "もう感染しそうにゃ…";
                }
                else if (infection > 60)
                {
                    targetText.text = "そろそろ感染しそうにゃ…";
                }
                else if (infection > 40)
                {
                    targetText.text = "感染するかもにゃ…";
                }
                else if (infection > 20)
                {
                    targetText.text = "感染怖いにゃ";
                }
                else
                {
                    if(coin < PAN)
                    {
                        targetText.text = "お金ないにゃ";
                    }
                    else
                    {
                        targetText.text = "食べ物買うにゃ";
                    }
                }
                break;
            case WALL_MASK:
                nukoComment.SetActive(true);
                if (mask < 1)
                {
                    targetText.text = "マスクがないにゃ";
                }
                else if (pan < 1)
                {
                    targetText.text = "食べ物がないにゃ";
                }
                else if (infection == 100)
                {
                    targetText.text = "感染するにゃ…";
                }
                else if (infection > 80)
                {
                    targetText.text = "もう感染しそうにゃ…";
                }
                else if (infection > 60)
                {
                    targetText.text = "そろそろ感染しそうにゃ…";
                }
                else if (infection > 40)
                {
                    targetText.text = "感染するかもにゃ…";
                }
                else if (infection > 20)
                {
                    targetText.text = "感染怖いにゃ";
                }
                else
                {
                    if (coin < MASK)
                    {
                        targetText.text = "お金ないにゃ";
                    }
                    else
                    {
                        targetText.text = "マスク買うにゃ";
                    }
                }
                break;
            case WALL_KADENS:
                nukoComment.SetActive(true);
                if (mask < 1)
                {
                    targetText.text = "マスクがないにゃ";
                }
                else if (pan < 1)
                {
                    targetText.text = "食べ物がないにゃ";
                }
                else if (infection == 100)
                {
                    targetText.text = "感染するにゃ…";
                }
                else if (infection > 80)
                {
                    targetText.text = "もう感染しそうにゃ…";
                }
                else if (infection > 60)
                {
                    targetText.text = "そろそろ感染しそうにゃ…";
                }
                else if (infection > 40)
                {
                    targetText.text = "感染するかもにゃ…";
                }
                else if (infection > 20)
                {
                    targetText.text = "感染怖いにゃ";
                }
                else
                {
                    if (!futon)
                    {
                        if (coin < FUTON)
                        {
                            targetText.text = "お金ないにゃ";
                        }
                        else
                        {
                            targetText.text = "布団買うにゃ";
                        }
                    }
                    else if (!fleezer)
                    {
                        if(coin < FLEEZER)
                        {
                            targetText.text = "お金ないにゃ";
                        }
                        else
                        {
                            targetText.text = "冷蔵庫買うにゃ";
                        }
                    }

                    else
                    {
                        targetText.text = "家電そろってるにゃ";
                    }
                }
                break;
            case WALL_GAMES:
                nukoComment.SetActive(true);
                if (mask < 1)
                {
                    targetText.text = "マスクがないにゃ";
                }
                else if (pan < 1)
                {
                    targetText.text = "食べ物がないにゃ";
                }
                else if (infection == 100)
                {
                    targetText.text = "感染するにゃ…";
                }
                else if (infection > 80)
                {
                    targetText.text = "もう感染しそうにゃ…";
                }
                else if (infection > 60)
                {
                    targetText.text = "そろそろ感染しそうにゃ…";
                }
                else if (infection > 40)
                {
                    targetText.text = "感染するかもにゃ…";
                }
                else if (infection > 20)
                {
                    targetText.text = "感染怖いにゃ";
                }
                else
                {
                    if (!trump)
                    {
                        if (coin < TRUMP)
                        {
                            targetText.text = "お金ないにゃ";
                        }
                        else
                        {
                            targetText.text = "トランプ買うにゃ";
                        }
                    }
                    else if (!shougi)
                    {
                        if (coin < SHOUGI)
                        {
                            targetText.text = "お金ないにゃ";
                        }
                        else
                        {
                            targetText.text = "将棋買うにゃ";
                        }
                    }
                    else if (!video)
                    {
                        if(coin < VIDEO)
                        {
                            targetText.text = "お金ないにゃ";
                        }
                        else
                        {
                            targetText.text = "テレビ買うにゃ";
                        }
                    }
                    else if (!game)
                    {
                        if(coin < GAME)
                        {
                            targetText.text = "お金ないにゃ";
                        }
                        else
                        {
                            targetText.text = "ゲーム買うにゃ";
                        }
                    }
                    else
                    {
                        targetText.text = "遊ぶもの揃ったにゃ";
                    }
                }
                break;
        }
    }

    //感染率更新
    void SliderInfectionUpdate()
    {
        if(infection > 100)
        {
            infection = 100;
        }
        if(infection < 0)
        {
            infection = 0;
        }
        sliderInfection.value = infection / 100.0f;
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

    //日時進行
    void Tomorrow()
    {
        sleep = true;
        time = !time;
        if (time)
        {
            date += 1;
        }

        PlayerPrefs.SetInt("COIN", coin);
        PlayerPrefs.SetInt("PAN", pan);
        PlayerPrefs.SetInt("MASK", mask);
        PlayerPrefs.SetInt("DATE", date);
        if (time)
        {
            PlayerPrefs.SetInt("TIME", 1);
        }
        else
        {
            PlayerPrefs.SetInt("TIME", 0);
        }
        PlayerPrefs.SetFloat("INFECTION", infection);
        if (trump)
        {
            PlayerPrefs.SetInt("TRUMP", 1);
        }
        else
        {
            PlayerPrefs.SetInt("TRUMP", 0);
        }
        if (shougi)
        {
            PlayerPrefs.SetInt("SHOUGI", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SHOUGI", 0);
        }
        if (video)
        {
            PlayerPrefs.SetInt("VIDEO", 1);
        }
        else
        {
            PlayerPrefs.SetInt("VIDEO", 0);
        }
        if (game)
        {
            PlayerPrefs.SetInt("GAME", 1);
        }
        else
        {
            PlayerPrefs.SetInt("GAME", 0);
        }
        if (sleep)
        {
            PlayerPrefs.SetInt("SLEEP", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SLEEP", 0);
        }
        PlayerPrefs.SetInt("STATUS", status);
        PlayerPrefs.SetFloat("PERCENT", percent);

        TotalUpdate();
    }

    //買い物：食料：個数更新
    public void PanShoppingUpdate()
    {
        Text targetText = textShoppingPan.GetComponent<Text>();
        targetText.text = count + "食";
    }

    //買い物：マスク：個数更新
    public void MaskShoppingUpdate()
    {
        Text targetText = textShoppingMask.GetComponent<Text>();
        targetText.text = count + "枚";
    }

    //買い物：食料：金額更新
    public void PanTotalShoppingUpdate()
    {
        Text targetText = textShoppingTotalPan.GetComponent<Text>();
        targetText.text = count * PAN + "円";
    }

    //買い物：マスク：金額更新
    public void MaskTotalShoppingUpdate()
    {
        Text targetText = textShoppingTotalMask.GetComponent<Text>();
        targetText.text = count * MASK + "円";
    }

    //感染チェック
    private bool InfectionCheck()
    {

        Random.InitState(System.DateTime.Now.Millisecond);

        int d = Random.Range(1, 101);
        bool check = true;

        if(infection >= d)
        {
            Infection();
            check = false;
        }

        return check;
    }

    //感染
    private void Infection()
    {
        textInfection.SetActive(true);
        pause.SetActive(true);
        buttonReset.SetActive(true);
    }

    //リセット
    private void Reset()
    {
        UIUpdate();
        wallNo = WALL_SLEEP;

        coin = 0; 
        pan = 5;
        mask = 5;
        date = 1;
        time = true;
        infection = 0;
        trump = false;
        shougi = false;
        video = false;
        game = false;
        sleep = true;
        status = -1;
        percent = 1;

        PlayerPrefs.SetInt("COIN", coin);
        PlayerPrefs.SetInt("PAN", pan);
        PlayerPrefs.SetInt("MASK", mask);
        PlayerPrefs.SetInt("DATE", date);
        PlayerPrefs.SetInt("TIME", 1);
        PlayerPrefs.SetFloat("INFECTION", infection);
        PlayerPrefs.SetInt("TRUMP", 0);
        PlayerPrefs.SetInt("SHOUGI", 0);
        PlayerPrefs.SetInt("VIDEO", 0);
        PlayerPrefs.SetInt("GAME", 0);
        PlayerPrefs.SetInt("SLEEP", 1);
        PlayerPrefs.SetInt("STATUS", status);
        PlayerPrefs.SetFloat("PERCENT", percent);

        textInfection.SetActive(false);
        pause.SetActive(false);
        buttonReset.SetActive(false);

        TotalUpdate();
        WallUpdate();
    }
}

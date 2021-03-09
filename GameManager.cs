using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�萔��`
    public const int WALL_JOB = 0; //��ʁF�o�C�g
    public const int WALL_SHOPPING = 1; //��ʁF������
    public const int WALL_GAME = 2; //��ʁF��y
    public const int WALL_SLEEP = 3; //��ʁF�A�Q
    public const int WALL_OPTION = 4; //��ʁF�ݒ�
    public const int WALL_PANS = 5; //��ʁF�������F�H��
    public const int WALL_MASK = 6; //��ʁF�������F�}�X�N
    public const int WALL_KADENS = 7; //��ʁF�������F�Ɠd
    public const int WALL_GAMES = 8; //��ʁF�������F��y�i


    //�Q�[���I�u�W�F�N�g
    public GameObject panelWalls; //�p�l���F��
    public Slider sliderInfection; //�X���C�_�[�F������
    public Slider sliderStress; //�X���C�_�[�F�X�g���X
    public GameObject buttonJobs; //�{�^���F�o�C�g
    public GameObject buttonShoppings; //�{�^���F������
    public GameObject buttonGames; //�{�^���F��y
    public GameObject buttonSleeps; //�{�^���F�A�Q
    public GameObject buttonOptions; //�{�^���F�ݒ�
    public GameObject buttonShoppingPans; //�{�^���F�������F�H��
    public GameObject buttonShoppingMasks; //�{�^���F�������F�}�X�N
    public GameObject buttonShoppingKadens; //�{�^���F�������F�Ɠd
    public GameObject buttonShoppingGames; //�{�^���F�������F��y�i
    public GameObject buttonShoppingBack; //�{�^���F�������F�߂�
    public GameObject textCoin; //�e�L�X�g�F����
    public GameObject textPan; //�e�L�X�g�F�H��
    public GameObject textMask; //�e�L�X�g�F�}�X�N
    public GameObject textDate; //�e�L�X�g�F���t
    public GameObject textTime; //�e�L�X�g�F����
    public GameObject nukoComment; //�e�L�X�g�t���ʂ�
    public GameObject textShoppingPan; //�e�L�X�g�F�������F�H��
    public GameObject textShoppingMask; //�e�L�X�g�F�������F�}�X�N


    //�ϐ�
    private int wallNo; //���݂̉��
    private int coin; //����
    private int pan; //�H��
    private int mask; //�}�X�N
    private int date; //���t
    private bool time; //���ԁFtrue,�ߑO�Ffalse,�ߌ�
    private int infection; //������
    private int stress; //�X�g���X
    private int count; //��


    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_SLEEP;

        coin = 0; //pp���
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


    //�o�C�g�{�^�����v�b�V��
    public void PushButtonJob()
    {
        UIUpdate();
        wallNo = WALL_JOB;
        WallUpdate();
    }

    //�������{�^�����v�b�V��
    public void PushButtonShopping()
    {
        UIUpdate();
        wallNo = WALL_SHOPPING;
        WallUpdate();
    }

    //��y�{�^�����v�b�V��
    public void PushButtonGame()
    {
        UIUpdate();
        wallNo = WALL_GAME;
        WallUpdate();
    }

    //�A�Q�{�^�����v�b�V��
    public void PushButtonSleep()
    {
        UIUpdate();
        wallNo = WALL_SLEEP;
        WallUpdate();
    }

    //�ݒ�{�^�����v�b�V��
    public void PushButtonOption()
    {
        UIUpdate();
        wallNo = WALL_OPTION;
        WallUpdate();
    }

    //�o�C�g���e�{�^�����v�b�V��
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

    //�������F�H���{�^�����v�b�V��
    public void PushButtonShoppingPan()
    {
        UIUpdate();
        wallNo = WALL_PANS;
        WallUpdate();
    }

    //�������F�}�X�N�{�^�����v�b�V��
    public void PushButtonShoppingMask()
    {
        UIUpdate();
        wallNo = WALL_MASK;
        WallUpdate();
    }

    //�������F�Ɠd�{�^�����v�b�V��
    public void PushButtonShoppingKaden()
    {
        UIUpdate();
        wallNo = WALL_KADENS;
        WallUpdate();
    }

    //�������F��y�i�{�^�����v�b�V��
    public void PushButtonShoppingGame()
    {
        UIUpdate();
        wallNo = WALL_GAMES;
        WallUpdate();
    }

    //�������F�߂�{�^�����v�b�V��
    public void PushButtonShoppingBack()
    {
        UIUpdate();
        wallNo = WALL_SHOPPING;
        WallUpdate();
    }

    //�v���X�{�^�����v�b�V��
    public void PushButtonPlus()
    {
        count += 1;
    }

    //�}�C�i�X�{�^�����v�b�V��
    public void PushButtonMinus()
    {
        if(count > 0)
        {
            count -= 1;
        }
    }

    //�܂Ƃ߂čX�V
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

    //��ʍX�V(�\��)
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

    //��ʍX�V(��\��)
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

    //�������X�V
    void SliderInfectionUpdate()
    {
        sliderInfection.value = infection / 100.0f;
    }

    //�X�g���X�X�V
    void SliderStressUpdate()
    {
        sliderStress.value = stress / 100.0f;
    }

    //���t�X�V
    void DateUpdate()
    {
        Text targetText = textDate.GetComponent<Text>();
        targetText.text = date + "����";
    }

    //���ԍX�V
    void TimeUpdate()
    {
        Text targetText = textTime.GetComponent<Text>();
        if (time)
        {
            targetText.text = "�ߑO";
            targetText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        else
        {
            targetText.text = "�ߌ�";
            targetText.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }
    }

    //�����X�V
    void CoinUpdate()
    {
        Text targetText = textCoin.GetComponent<Text>();
        targetText.text = coin + "�~";
    }

    //�H���X�V
    void PanUpdate()
    {
        Text targetText = textPan.GetComponent<Text>();
        targetText.text = pan + "�H";
    }

    //�}�X�N�X�V
    void MaskUpdate()
    {
        Text targetText = textMask.GetComponent<Text>();
        targetText.text = mask + "��";
    }

    //�������F�H�����X�V
    public void PanShoppingUpdate()
    {
        Text targetText = textShoppingPan.GetComponent<Text>();
        targetText.text = count + "�H";
    }

    //�������F�}�X�N���X�V
    public void MaskShoppingUpdate()
    {
        Text targetText = textShoppingMask.GetComponent<Text>();
        targetText.text = count + "��";
    }
}

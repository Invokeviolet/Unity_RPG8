using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Windows;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    // UI
    #region UI

    // Canvas UI
    #region Canvas
    [Header("[CANVAS]")]
    [SerializeField] Canvas[] canvas;
    /*Canvas TITLECANVAS;
    Canvas GENERALCANVAS;
    Canvas LOGINCANVAS;
    Canvas QUESTIONCANVAS;
    Canvas STORECANVAS;
    Canvas GAMECLEARCANVAS;
    Canvas GAMEOVERCANVAS;
    Canvas WINCANVAS;
    Canvas EXITCANVAS;*/
    #endregion


    // PlayerInfo UI
    #region PlayerInfo UI
    [Header("[PLAYER INFO]")]
    [SerializeField] public Text Player_Lv;
    [SerializeField] public Text Player_ID;
    [SerializeField] public Text Player_Gold;
    [SerializeField] public Text Player_Potion;
    [SerializeField] public Text Player_Attack;

    private string playerName = null;

    [SerializeField] public Slider Player_Staminar;
    [SerializeField] public Slider Player_Exp;
    [SerializeField] public Image[] Player_HP;
    #endregion

    [Header("[MAP UI]")]
    [SerializeField] GameObject MapInfoPrefab;
    [SerializeField] Text MapInfo;

    [Header("[MONSTER UI]")]
    [SerializeField] GameObject MonsterInfoPrefab;
    [SerializeField] Text MonsterInfo;

    [Header("[INPUT UI]")]
    [SerializeField] GameObject objInputName; // �̸� �Է� UI
    [SerializeField] Text inputName; // �Է¹��� �̸�

    [Header("[GENERAL UI]")]
    [SerializeField] Button StartButton;
    [SerializeField] Button ExitButton;
    [SerializeField] Button QuitButton;
    [SerializeField] Button QuitCancleButton;
    [SerializeField] Button RunButton; // �ӽ� ��ư

    [Header("[STORE UI]")]
    [SerializeField] Button BackButton;
    [SerializeField] Button BuyButton;
    [SerializeField] Text StorePotionValue;
    [SerializeField] Text StoreGoldValue;


    [Header("[WIN UI]")]
    [SerializeField] Button ReturnButton;
   // [SerializeField] TextMeshProUGUI ResultText;
    #endregion
    


    // �̱���
    #region �̱���

    private static UIManager Instance = null;
    public static UIManager INSTANCE
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<UIManager>();
                /* if (Instance == null)
                 {
                     Instance = new GameObject("UIManager").AddComponent<UIManager>();
                 }*/
            }
            // DontDestroyOnLoad(Instance.gameObject);
            return Instance;
        }
    }
    #endregion

    // Action action;

    public Action ingame;
    public Action action;
    public Action store;

    private void Awake()
    {
        // action += BUYPOTION;
        // BuyButton.onClick.AddListener(delegate () { action(); });

        ingame += GENERALSCENE;
        action += ACTIONSCENE;
        store += STORESCENE;

        Player.INSTANCE.CURSTAMINAR = Player.INSTANCE.MAXSTAMINAR;
        Player_Staminar.value = Player.INSTANCE.CURSTAMINAR;
        Player_Staminar.gameObject.SetActive(false);

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].gameObject.SetActive(false);
        }     
        RunButton.gameObject.SetActive(false);
    }

    public void Start()
    {
        TITLESCENE();
    }

    public void Update()
    {

    }

    //
    // UI SCENE 
    #region UI SCENE 


    // Ÿ��Ʋ ��
    public void TITLESCENE()
    {
        
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].gameObject.SetActive(false);
        }
        canvas[0].gameObject.SetActive(true);

    }

    public void ChangeCanvas(int num) 
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].gameObject.SetActive(false);
        }
        canvas[num].gameObject.SetActive(true);
    }

    // �ΰ��� UI
    public void GENERALSCENE()
    {
        ChangeCanvas(1);

        if (inputName.text.Length >= 2 && inputName.text.Length <= 8) //&& UnityEngine.Input.GetKeyDown(KeyCode.Return)
        {
            PlayerInputName();
            //Debug.Log(Player_ID.text);
        }
        else if (inputName.text.Length < 2 && inputName.text.Length > 8)
        {
            Debug.LogError("ID�� �ּ� 2�ڸ����� 8�ڸ����� �����մϴ�.");
        }
        UpdatePlayerInfo();

        Player_Staminar.gameObject.SetActive(false);
        RunButton.gameObject.SetActive(false);

    }

    // �÷��̾� �̸� �Է¹ޱ�
    void PlayerInputName()
    {
        Player_ID.text = inputName.text;
    }

    // �÷��̾� ���� ������Ʈ
    void UpdatePlayerInfo() 
    {
        StoreGoldValue.text = Player.INSTANCE.PlayerGold.ToString();
        StorePotionValue.text = Player.INSTANCE.PlayerPotion.ToString();
        Player_Gold.text = Player.INSTANCE.PlayerGold.ToString();
        Player_Potion.text = Player.INSTANCE.PlayerPotion.ToString();
    }

    // ���� �� UI
    public void ACTIONSCENE()
    {
        ChangeCanvas(1);                
        RunButton.gameObject.SetActive(true);
    }

    // �̵����� ����� UI
    public void ONQUESTION()
    {
        canvas[3].gameObject.SetActive(true);
        GameManager.INSTANCE.IsWindowOpen = true;
    }
    public void OFFQUESTION()
    {
        canvas[3].gameObject.SetActive(false);
        GameManager.INSTANCE.IsWindowOpen = false;
    }
    
    
    // ���� �� UI
    public void STORESCENE()
    {
        ChangeCanvas(4);

        UpdatePlayerInfo();
        RunButton.gameObject.SetActive(false);
    }

    // ���� ��� UI
    public void GAMECLEARSCENE()
    {
        ChangeCanvas(5);
        RunButton.gameObject.SetActive(false);
    }
    public void GAMEOVERSCENE()
    {
        ChangeCanvas(6);
        RunButton.gameObject.SetActive(false);
    }

    // ���� ��� UI
    bool IsWin = false;
    public void RESULTSCENE()
    {
        if (IsWin == true) // �÷��̾� �¸� �� Win �����
        {
            ChangeCanvas(5);
            canvas[5].transform.GetChild(0).gameObject.SetActive(true);
            canvas[5].transform.GetChild(1).gameObject.SetActive(false);            
        }
        else // ���� Lose �����
        {
            ChangeCanvas(5);
            canvas[5].transform.GetChild(0).gameObject.SetActive(false);
            canvas[5].transform.GetChild(1).gameObject.SetActive(true);            
        }
    }

    public bool Check4WhoIsWin(bool who)
    {
        // �÷��̾ ���׾��ٸ�? �÷��̾� �¸�
        if (Player.INSTANCE.IsDead == false) IsWin = true;
        // �÷��̾ �׾��ٸ�? �÷��̾� �й�
        else if (Player.INSTANCE.IsDead == true) IsWin = false;

        return who;
    }

    //
    // LOGIN UI
    #region LOGIN SCENE & INPUT PLAYER NAME
    public void ONLOGINSCENE()
    {
        canvas[2].gameObject.SetActive(true);
    }
    public void OFFLOGINSCENE()
    {
        canvas[2].gameObject.SetActive(false);
    }
    #endregion


    //
    // EXIT SCENE
    #region EXIT SCENE
    public void ONEXITSCENE()
    {
        ChangeCanvas(7);
        GameManager.INSTANCE.IsWindowOpen = true;
    }
    public void OFFEXITSCENE()
    {
        canvas[7].gameObject.SetActive(false);
    }

    #endregion
    // 

    #endregion
    //

    private void ValueChanged(Slider slider)
    {
        int value = (int)slider.value;

    }

    //
    // GET INFO
    #region GET INFO
    public void GETPLAYERINFO(string Lv, string Attack) // �÷��̾�� �浹�ؼ� ���� ���� ���
    {
        Player_Lv.text = Lv.ToString();
        Player_Attack.text = Attack.ToString();
    }
    public void GETMAPINFO(MAPINFO mapinfo) // �÷��̾�� �浹�ؼ� ���� ���� ���
    {
        MapInfo.text = mapinfo.ToString();
    }
    public void GETMOBINFO(MonsterMarble mobinfo) // �÷��̾�� �浹�ؼ� ���� ���� ���
    {
        MonsterInfo.text = mobinfo.GetComponent<MonsterMarble>().MOBINFO.ToString();
    }
    #endregion

    //
    // Button UI
    #region Button UI
    public void BUYPOTION()
    {
        if (Player.INSTANCE.Shop4BuyAvailable == false) // ��尡 ���� �� ���౸�� ����
        {
            Player.INSTANCE.PlayerPotion=0;
            Player.INSTANCE.PlayerGold =0;
        }
        else //if (Player.INSTANCE.Shop4BuyAvailable == true)
        {
            Player.INSTANCE.PlayerPotion += 1;
            Player.INSTANCE.PlayerGold -= 10;
        }
        UpdatePlayerInfo();
    }
    #endregion
    


}

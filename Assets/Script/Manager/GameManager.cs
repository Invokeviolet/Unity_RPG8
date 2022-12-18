using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// ��ü ������ ����
// ����� UI�Ŵ����� �ϰԲ�

// ���� ����
public enum MOBINFO
{
    EASY,
    NORMAL,
    HARD,
    BOSS
}

// �� ����
public enum MAPINFO
{
    FOREST,
    SWAMP,
    GROUND,
    SHOP,
    START,
    END
}


public class GameManager : MonoBehaviour
{
    // �̱���
    #region �̱���

    private static GameManager Instance = null;
    public static GameManager INSTANCE
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<GameManager>();
            }
            return Instance;
        }
    }
    #endregion

    // �÷��̾ �ΰ����̴�?
    public bool myPlayerInGame { get; set; }
    // �ٸ� ������ â�� �����ֳ�?
    public bool IsWindowOpen { get; set; }
    // �÷��̾ �������̴�?
    public bool myPlayerAction { get; set; }

    Player player;
    Monster monster;
    public Player GetPlayer() => player;
    public Monster GetMonster() => monster;
    //public GameObject PlayerCam=null;

    public int POTION;
    public int GOLD;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        monster = FindObjectOfType<Monster>();
        TITLESCENE();
    }
   

    /*public void BUYPOTION(string potion, string gold)
    {        
        UIManager.INSTANCE.HaveAGold.text = "GOLD " + potion;
        UIManager.INSTANCE.HaveAPotion.text = "POTION " + gold;                
    }*/


    public void TITLESCENE() // Ÿ��Ʋ
    {
        // ī�޶� ��ġ
        UIManager.INSTANCE.TITLESCENE();
        GameManager.INSTANCE.myPlayerInGame = false;

    }

    public void INGAMESCENE() // �ΰ���
    {
        // ī�޶� ��ġ
        UIManager.INSTANCE.GENERALSCENE();
        UIManager.INSTANCE.OFFQUESTION();
        GameManager.INSTANCE.myPlayerInGame = true;
        GameManager.INSTANCE.myPlayerAction = false;
        Debug.Log("�ΰ���?");
        Player.INSTANCE.transform.position = Player.INSTANCE.PlayerPos.transform.position;

    }

    public void STORESCENE() // ����
    {
        // ī�޶� ��ġ
        UIManager.INSTANCE.STORESCENE();
        UIManager.INSTANCE.OFFQUESTION();
        GameManager.INSTANCE.myPlayerInGame = false;
        GameManager.INSTANCE.myPlayerAction = false;
    }


    public void ACTIONFORESTSCENE() // ����
    {
        // ī�޶� ��ġ   
        UIManager.INSTANCE.ACTIONSCENE();
        UIManager.INSTANCE.OFFQUESTION();
        GameManager.INSTANCE.myPlayerInGame = false;
        GameManager.INSTANCE.myPlayerAction = true;

        Player.INSTANCE.transform.position = Player.INSTANCE.ActionPlayerPos.transform.position;

    }

    /* public void LOADINGSECNE()
     {
         // ī�޶� ��ġ
         SceneManager.LoadScene("10_LOADING_Scene");
         GameManager.INSTANCE.myPlayerInGame = false;
     }*/

    static public void Quit() // ���� ����
    {
        Application.Quit();
    }

}


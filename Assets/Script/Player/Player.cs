using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.U2D.Path.GUIFramework;


public class Player : MonoBehaviour
{
    // �̱���
    #region �̱���

    private static Player Instance = null;
    public static Player INSTANCE
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<Player>();
                if (Instance == null)
                {
                    // �÷��̾� ����
                    Debug.Log("�̱���! �÷��̾�! ����!");
                    Instance = Instantiate(Resources.Load<Player>("Player"));
                    Instance.name = Instance.name.Replace("(Clone)", "");
                    //Instance = new GameObject("PlayerCam").AddComponent<PlayerCamera>();                   
                }
            }
            // DontDestroyOnLoad(Instance.gameObject);
            return Instance;
        }
    }
    #endregion


    MonsterMarble monsterMarble;

    // �÷��̾� ��ġ �޾ƿ���
    private Transform SaveMyPos { get; set; }
    public Transform PlayerPos;
    public Transform ActionPlayerPos;

    Cube cube;
    // �÷��̾� ���� üũ
    public bool IsDead { get; set; }
    // �÷��̾� ���� ��
    float JumpForce;

    // �÷��̾� ������ٵ�
    private Rigidbody PlayerRB;

    // �÷��̾� ���� 
    //
    // Player Info Property
    #region Player Info Property

    // �ӵ� 
    public int PlayerSpeed { get; set; }
    // ����

    public int PlayerLevel { get; set; }

    // ü��
    public int PlayerHP { get; set; }

    // ����ġ
    public int PlayerEXP { get; set; }

    // ���ݷ�
    public int PlayerAttackPower { get; set; }

    // ���ݹ���
    public int PlayerAttackRange { get; set; }

    // ����
    public int PlayerPotion { get; set; }

    // ���
    private int playerGold;
    public int PlayerGold
    {
        get
        {
            if (playerGold <= 0)
            {
                playerGold = 0;
                Shop4BuyAvailable = false;
            }
            return playerGold;
        }
        set
        {
            playerGold = value;
        }

    }

    private int PlayerMaxHP = 100;
    private int PlayerMaxEXP = 1000;

    public float CURSTAMINAR { get; set; }
    public float MAXSTAMINAR { get; set; }

    public bool Shop4BuyAvailable { get; set; }

    #endregion


    private void Awake()
    {
        monsterMarble = FindObjectOfType<MonsterMarble>();
       
        PlayerRB = this.gameObject.GetComponent<Rigidbody>();
        Shop4BuyAvailable = true;

        PlayerSpeed = 8;

        PlayerLevel = 1;

        PlayerMaxHP = 100;
        PlayerHP = 1 / PlayerMaxHP;
        PlayerAttackPower = 1;
        PlayerAttackRange = 1;
        PlayerEXP = 0;
        PlayerMaxEXP = 1000;
        PlayerPotion = 1;
        playerGold = 100;
        //CURSTAMINAR = 0;
        //MAXSTAMINAR = 0.5f;
    }


    // �÷��̾� ���� UI
    string MyLV = "";
    // �÷��̾� ���ݷ� UI
    string MyAttack = "";


    private void Start()
    {
        // �÷��̾� ���� ��ġ
        PlayerPos.transform.position = new Vector3(0, 0.5f, 0);
        this.transform.position = PlayerPos.transform.position;

        PlayerRB = GetComponent<Rigidbody>();
        if (PlayerRB == null)
        {
            this.gameObject.AddComponent<Rigidbody>();
        }
    }


    // Update
    #region Update
    private void Update()
    {
        MyLV = "LV ." + PlayerLevel.ToString();
        MyAttack = PlayerAttackPower.ToString() + " / " + PlayerAttackRange.ToString();

        // �ΰ��� ���̰�, � �˸�â�� ���� �ʾ��� ��
        if ((GameManager.INSTANCE.myPlayerInGame == true) && (GameManager.INSTANCE.IsWindowOpen == false))
        {
            PlayerMoveToIngame();
        }
        // ���� ���̰�, � �˸�â�� ���� �ʾ��� ��
        if ((GameManager.INSTANCE.myPlayerAction == true) && (GameManager.INSTANCE.IsWindowOpen == false))
        {
            // �ΰ��Ӿ� �÷��̾ �̵��Ǵ� ����
            PlayerMoveToAction();
        }
        PlayerCharge(); // ���� �Ծ��� ��
        UpdatePlayerInfo(); // UI ������Ʈ
    }
    #endregion 




    private void UpdatePlayerInfo() // ���߿� �Ⱦ��� ����
    {
        // �÷��̾� ���� ������Ʈ ���� - ������ ��,��
        UIManager.INSTANCE.GETPLAYERINFO(MyLV, MyAttack);
    }



    //
    // �÷��̾� ����ġ �� ������
    #region �÷��̾� ����ġ �� ������
    public void ExpUpdate(int exp) // ���� ��� ������ ȣ��
    {
        UIManager.INSTANCE.Player_Exp.value += exp;
        if (PlayerEXP >= PlayerMaxEXP)
        {
            // ����ġ�� �ִ��� �� �������� �ɷ� ����
            PlayerLevel += 1;
            PlayerEXP = 0;
            PlayerMaxHP = PlayerMaxHP * 2;
            PlayerHP = PlayerMaxHP;
            PlayerAttackPower = PlayerAttackPower * 2;
        }
    }
    #endregion
    //


    //
    // �÷��̾� �ΰ��� �̵�
    #region �÷��̾� �ΰ��� �̵�
    void PlayerMoveToIngame()
    {
        // WASD Ű�� �̵�
        if (Input.GetKeyDown((KeyCode.T))) // ��
        {
            transform.position += Vector3.forward;
            if (transform.position.z >= 9)
            {
                transform.position = new Vector3(transform.position.x, 0.5f, 9);
            }
        }
        else if (Input.GetKeyDown((KeyCode.F))) // �� 
        {
            transform.position += Vector3.left;
            if (transform.position.x <= 0)
            {
                transform.position = new Vector3(0, 0.5f, transform.position.z);
            }
        }
        else if (Input.GetKeyDown((KeyCode.G))) // ��
        {
            transform.position += Vector3.back;
            if (transform.position.z <= 0)
            {
                transform.position = new Vector3(transform.position.x, 0.5f, 0);
            }
        }
        else if (Input.GetKeyDown((KeyCode.H))) // ����
        {
            transform.position += Vector3.right;
            if (transform.position.x >= 9)
            {
                transform.position = new Vector3(9, 0.5f, transform.position.z);
            }
        }

    }
    #endregion

    
    //
    //
    // �÷��̾� ������ �̵�
    #region �÷��̾� ������ �̵�

    protected float hAxis = 0f;
    protected float vAxis = 0f;
    protected bool isMove = false;
    protected Vector3 moveDir;

    public float speed = 2.5f;
    private float xRotate = 0.0f;
    private float yRotate = 0.0f;

    void PlayerMoveToAction()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        // �¿��̵� * �ӵ�
        float yRotateSize = Input.GetAxis("Mouse X") * speed;
        // y�� ȸ���� + ���ο� ȸ������
        yRotate = transform.eulerAngles.y + yRotateSize;

        // ���Ʒ��̵� * �ӵ�
        float xRotateSize = -Input.GetAxis("Mouse Y") * speed;

        // ī�޶� ȸ���� = ī�޶� �ݿ�
        transform.eulerAngles = new Vector3(0, yRotate, 0);

        // ���Ʒ� ȸ���� + ���ο� ȸ������, ���� ����
        // Clamp ���� ������ ���� -> min, max
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -40, 60);

        // ī�޶�
        Camera.main.transform.eulerAngles = new Vector3(xRotate, 0, 0);        

        // isMove�� hAxis�� 0�� �ٻ簪�� �� false�� ��.
        isMove = !Mathf.Approximately(hAxis, 0f) || !Mathf.Approximately(vAxis, 0f);

        moveDir = new Vector3(hAxis, 0, vAxis).normalized;

        if (isMove)
        {            
            transform.Translate(moveDir * Time.deltaTime * PlayerSpeed, Space.Self);
        }

        // ����
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // �޸���
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        
    }
    void Jump()
    {
        JumpForce = 1.5f;
        PlayerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }
    void Run()
    {
        PlayerSpeed = PlayerSpeed * 2;
    }

    #endregion
    //



    // �÷��̾� ü��
    #region
    void PlayerCharge()
    {
        int curPotion = PlayerPotion;
        if (Input.GetKeyDown((KeyCode.I)))
        {
            PlayerPotion -= 1;
            PlayerHP += 10;

            if (PlayerPotion <= 0)
            {
                PlayerPotion = 0;
            }
            if (PlayerHP >= PlayerMaxHP) // HP�� �̹� �������� �� ���� ��� ����
            {
                PlayerHP = PlayerMaxHP;
                PlayerPotion = curPotion;
            }
        }
    }
    #endregion

    //
    // �÷��̾� ��ġ ���� ���
    #region �÷��̾� ��ġ ���� ���

    private void OnCollisionEnter(Collision collision)
    {
        // �ʿ� �ִ� ��ť��� �浹�ϸ� �� ���� ���
        if (collision.gameObject.TryGetComponent<Cube>(out cube) == true) // (collision.collider.CompareTag("Cube"))
        {
            Debug.Log(cube.MAPINFO);
            UIManager.INSTANCE.GETMAPINFO(cube.MAPINFO); // UI�� �� ���� ���
        }
        if (collision.collider.CompareTag("Store"))
        {
            // �������� �̵��Ұ��� ����� â ����
            UIManager.INSTANCE.ONQUESTION();
        }
        if (collision.collider.CompareTag("NPC"))
        {
            Debug.Log("�ȳ� NPC");
        }
        if (collision.collider.CompareTag("End"))
        {
            Debug.Log("����!");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<MonsterMarble>(out monsterMarble) == true) //(collision.collider.CompareTag("Monster"))
        {
            PlayerPos.transform.position = transform.position;
            ActionPlayerPos.transform.position = new Vector3(2000, 0.5f, 0);
            transform.position = ActionPlayerPos.transform.position;

            // �浹���� �� �÷��̾� �׼� ��ġ�� �̵�
            Debug.Log("�÷��̾� ���� �غ� ��ġ�� �̵� �Ϸ�");
            UIManager.INSTANCE.GETMOBINFO(monsterMarble); // UI�� ���� ���� ���

            // ī�޶� ��ġ �̵�
            GameManager.INSTANCE.ACTIONFORESTSCENE();
        }
    }

    #endregion


    //
    // �÷��̾� Ÿ�� �� ����
    #region �÷��̾� Ÿ�� �� ����
    public void HitPlayer(int damage)
    {
        PlayerHP -= damage;
        if (PlayerHP <= 0)
        {
            IMDEAD();
        }
    }
    public void IMDEAD()
    {
        IsDead = true;
        UIManager.INSTANCE.Check4WhoIsWin(true);
        // 1 �� �� �÷��̾� ���ٴ� â ����
        // Invoke("UIManager.INSTANCE.RESULTSCENE()", 1f);

    }
    #endregion
}

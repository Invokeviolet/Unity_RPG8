using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMarble : MonoBehaviour
{

    MOBINFO mobInfo;

    int AttackPower;

    // ��ǥ �޾ƿ���
    public Vector3 pos { get; set; }
    // ���� �޾ƿ���
    public Color prefabCol { get; set; }
    // ���� �޾ƿ���
    public string monster { get; set; }
    // ü�� �޾ƿ���
    public int HP { get; set; }
    // ����ġ �޾ƿ���
    public int EXP { get; set; }

    // �� ���� 
    public MOBINFO MOBINFO { get { return mobInfo; } set { mobInfo = value; } }


    void Update()
    {

    }
    

    // ����
    public void Init(Vector3 pos, MOBINFO info)
    {
        // ť�긶�� ������ ���� ���
        this.pos = pos;
        this.mobInfo = info;

        // �� ������Ʈ�� Meterial�� �����ͼ� ���� ����
        Material myM = GetComponent<MeshRenderer>().material;

        if (info == MOBINFO.EASY) //0
        {
            // this.gameObject.tag = "Easy";
            prefabCol = Color.cyan;
            HP = 50;
            EXP = 50;
            AttackPower = 10;
        }
        if (info == MOBINFO.NORMAL) //1
        {
            // this.gameObject.tag = "Normal";
            prefabCol = Color.blue;
            HP = 100;
            EXP = 100;
            AttackPower = 30;
        }
        if (info == MOBINFO.HARD) //2
        {
            // this.gameObject.tag = "Hard";
            prefabCol = Color.magenta;
            HP = 180;
            EXP = 180;
            AttackPower = 50;
        }
        if (info == MOBINFO.BOSS) //3
        {
            // this.gameObject.tag = "Boss";
            prefabCol = Color.black;
            HP = 300;
            EXP = 300;
            AttackPower = 100;
        }
        myM.color = prefabCol;
    }

}
      

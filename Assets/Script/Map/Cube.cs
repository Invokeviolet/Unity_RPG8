using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cube : MonoBehaviour
{
    MAPINFO myInfo;
    // ��ǥ �޾ƿ���
    public Vector3 MAPPOSITION { get; set; }
    // ���� �޾ƿ���
    public Color MAPCOLOR { get; set; }
    // ����
    public MeshRenderer MAPMESH { get; set; }
    [SerializeField] Material Forest;
    [SerializeField] Material Ground;
    [SerializeField] Material Swamp;
    [SerializeField] Material Start;
    [SerializeField] Material Final;
    [SerializeField] Material Shop;

    // �̸� �޾ƿ���
    public string MAPNAME { get; set; }
    // �� �޾ƿ���
    public int MAPNUM { get; set; }
    // ���� �޾ƿ���
    public string MONSTER { get; set; }
    // �� ���� 
    public MAPINFO MAPINFO { get { return myInfo; } set { myInfo = value; } }


    // ����
    public void Init(Vector3 pos, MAPINFO info)
    {

        // ť�긶�� ������ ���� ���
        this.MAPPOSITION = pos;
        this.myInfo = info;

        // �� ������Ʈ�� Meterial�� �����ͼ� ���� ����
        Material myM = GetComponent<MeshRenderer>().material;
        MAPMESH = GetComponent<MeshRenderer>();

        if (info == MAPINFO.FOREST) //0
        {
            MAPMESH.material = Forest;
            //MAPCOLOR = Color.green;
            MAPNAME = "FOREST";
            MAPNUM = 0;
            this.gameObject.tag = "Forest";
        }
        if (info == MAPINFO.SWAMP) //1
        {
            MAPMESH.material = Swamp;
            //MAPCOLOR = Color.blue;
            MAPNAME = "SWAMP";
            MAPNUM = 1;
            this.gameObject.tag = "Swamp";
        }
        if (info == MAPINFO.GROUND) //2
        {
            MAPMESH.material = Ground;
            //MAPCOLOR = Color.yellow;
            MAPNAME = "GROUND";
            MAPNUM = 2;
            this.gameObject.tag = "Ground";
        }
        if (info == MAPINFO.SHOP) //3
        {
            MAPMESH.material = Shop;
            //MAPCOLOR = Color.black;
            MAPNAME = "STORE";
            MAPNUM = 3;
            this.gameObject.tag = "Store";
            // ������ �� ���� ����
        }
        if (info == MAPINFO.START) //4
        {
            MAPMESH.material = Start;
            //MAPCOLOR = Color.white;
            MAPNAME = "START";
            MAPNUM = 4;
            this.gameObject.tag = "Start";
        }
        if (info == MAPINFO.END) //5
        {
            MAPMESH.material = Final;
            //MAPCOLOR = Color.white;
            MAPNAME = "ARRIVAL";
            MAPNUM = 5;
            this.gameObject.tag = "End";
        }

        myM = MAPMESH.material;
    }



}

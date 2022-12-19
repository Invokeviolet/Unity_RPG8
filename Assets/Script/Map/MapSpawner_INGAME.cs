using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class MapSpawner_INGAME : MonoBehaviour
{

    // ������ ������
    Vector3 zeroPos;
    Vector3 finPos;


    // �÷��̾�
    [SerializeField] Player PlayerPrefab;
    // ����
    [SerializeField] MonsterMarble MonsterPrefab;
    // �� ť��
    [SerializeField] Cube CubePrefab;
    

    // 1�� -> 10 x 10 �迭�� �޾Ƽ� ����    
    MonsterMarble MOBS = null;
    Cube MAPTILE = null;
    Player PLAYER = null; // �÷��̾� ����
    GameObject EmptyBox;
    Cube[,] cubes;
    MonsterMarble[] mobs;

    // ť�� ����
    private int count = 10;
    // �������� ǥ�� -> 1
    private int stage = 1;
    // ���� ��
    private int CurMobCount = 0;
    private int MaxMobCount = 30;
    // ���� ��ġ ���� �ؼ� �迭�� ����
    int random;

    public void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);

        // ť�꿡 �� �־�� ��
        CubePrefab.transform.position = new Vector3(0f, 0f, 0f);
        zeroPos = new Vector3(0f, 0f, 0f);
        finPos = new Vector3(9f, 0f, 9f);


        // ť�� ���� �迭
        cubes = new Cube[count, count];
        // ���� ���� �迭
        mobs = new MonsterMarble[MaxMobCount];

        // ���� ������ �޾ƿ���
        float xScale = CubePrefab.transform.localScale.x;
        float zScale = CubePrefab.transform.localScale.z;

        // ť�꿡 ������ �������ֱ�
        int CubeRandom = 0;
        int MonsterRandom = 0;
        int[] rand = new int[10];
        int range = 5;


        // �� �̸����� �ٲ㼭 �� ���ӿ�����Ʈ�� ����
        for (int i = 0; i < (int)MAPINFO.START; i++)
        {
            EmptyBox = new GameObject((MAPINFO)i + "BOX");
        }


        // ���� ��ǥ ����
        for (int i = 0; i < rand.Length; i++)
        {
            rand[i] = Random.Range(range - 5, range);

            if (i % 2 == 0)
                range += 5;
            else
                range = 5;
        }
        Vector3 area1 = new Vector3(rand[0], 0, rand[4]);
        Vector3 area2 = new Vector3(rand[1], 0, rand[5]);
        Vector3 area3 = new Vector3(rand[2], 0, rand[7]);
        Vector3 area4 = new Vector3(rand[3], 0, rand[6]);

        // ��ǥ�� 0,0 �̰ų� 9,9 �϶�
        while ((area1 == zeroPos) || (area1 == finPos))
        {
            Debug.Log(area1);
            rand[0] = Random.Range(range - 5, range);
            rand[4] = Random.Range(range - 5, range);
        }
        while ((area2 == zeroPos) || (area2 == finPos))
        {
            Debug.Log(area2);
            rand[1] = Random.Range(range, range + 5);
            rand[5] = Random.Range(range - 5, range);
        }
        while ((area3 == zeroPos) || (area3 == finPos))
        {
            Debug.Log(area3);
            rand[2] = Random.Range(range - 5, range + 5);
            rand[7] = Random.Range(range, range);
        }
        while ((area4 == zeroPos) || (area4 == finPos))
        {
            Debug.Log(area4);
            rand[3] = Random.Range(range, range + 5);
            rand[6] = Random.Range(range, range + 5);
        }

        // 4������ �� 1���� ���� ���� ����
        #region 4������ �� 1���� ���� ���� ����
        // (0,0) <= (5,5) / rnd[0], rnd[4]
        // (5,0) <= (10, 5) / rnd[1], rnd[5]
        // (0,5) <= (10,5) / rnd[2], rnd[7]
        // (5,5) <= (10,10) / rnd[3], rnd[6]
        #endregion


        // ���͸� �����ϴ� ĭ : �� �� ��(random)

        // ����, ����, ��, ��, ��
        for (int i = 0; i < cubes.GetLength(0); i++)
        {
            for (int j = 0; j < cubes.GetLength(1); j++)
            {
                CubeRandom = Random.Range(0, 3);

                Vector3 vec3 = new Vector3(j * xScale, 0, i * zScale);

                // ť�� ��Ÿ�� ����
                MAPTILE = Instantiate(CubePrefab, vec3, Quaternion.identity);
                MAPTILE.Init(vec3, (MAPINFO)CubeRandom);
                Debug.Log(MAPTILE);
                // ť�� ��ǥ�� ��Ÿ�� �ֱ�
                cubes[i, j] = MAPTILE;
                cubes[i, j].transform.SetParent(this.gameObject.transform);

                // �� ������Ʈ�� ������ü�� �־��ٰ�
                //cubes[i, j].transform.SetParent(EmptyBox.transform);

                // �� ���ӿ�����Ʈ ������ ���� ã�Ƽ� �־��ֱ�
                /*string cubeObject = (MAPINFO)CubeRandom + "BOX";
                EmptyBox = GameObject.Find(cubeObject);
                cubes[i, j].transform.SetParent(EmptyBox.transform);*/

                // �� ũ�⸸ŭ ������ ����Ʈ�� �ְ�, ������ �������� 20���� ����

                // ������ ���
                if (j == 0 && i == 0)
                {
                    cubes[i, j].Init(vec3, (MAPINFO)4);
                    //MAPTILE.transform.parent = this.transform;
                    //cubes[i, j].transform.SetParent(EmptyBox.transform);
                }
                // ������ ���
                if (j == 9 && i == 9)
                {
                    cubes[i, j].Init(vec3, (MAPINFO)5);
                    //MAPTILE.transform.parent = this.transform;
                    //cubes[i, j].transform.SetParent(EmptyBox.transform);
                }
                
            }

        }

        // ���� �������Ʈ �����ؼ� ���
        /*string ShopObject = MAPINFO.SHOP + "BOX";
        EmptyBox = GameObject.Find(ShopObject);*/

        // ���� 4���� ��ġ �����
        cubes[(int)area1.z, (int)area1.x].Init(area1, MAPINFO.SHOP);
        cubes[(int)area1.z, (int)area1.x].transform.SetParent(this.gameObject.transform);

        cubes[(int)area2.z, (int)area2.x].Init(area2, MAPINFO.SHOP);
        cubes[(int)area2.z, (int)area2.x].transform.SetParent(this.gameObject.transform);

        cubes[(int)area3.z, (int)area3.x].Init(area3, MAPINFO.SHOP);
        cubes[(int)area3.z, (int)area3.x].transform.SetParent(this.gameObject.transform);

        cubes[(int)area4.z, (int)area4.x].Init(area4, MAPINFO.SHOP);
        cubes[(int)area4.z, (int)area4.x].transform.SetParent(this.gameObject.transform);
                

        //���� ���� ����
        int mobOverLap = 0;
        for (int i = 0; i < MaxMobCount; i++)
        {
            Vector3 randvec = new Vector3(Random.Range(0, 9) * xScale, 0, Random.Range(0, 9) * zScale);
            MonsterRandom = Random.Range(0, 3);

            // ���� ����ó��
            if (cubes[(int)area1.z, (int)area1.x].transform.position == randvec) { --i; continue; }
            if (cubes[(int)area2.z, (int)area2.x].transform.position == randvec) { --i; continue; }
            if (cubes[(int)area3.z, (int)area3.x].transform.position == randvec) { --i; continue; }
            if (cubes[(int)area4.z, (int)area4.x].transform.position == randvec) { --i; continue; }
            // ���� ���� ����ó��
            if (zeroPos == randvec) { --i; continue; }
            if (finPos == randvec) { --i; continue; }
            // �ߺ� ����ó��
            for (int j = 0; j < CurMobCount; j++)
            {
                mobOverLap = j;
                if (mobs[j].transform.position == randvec)
                { break; }
            }
            if (CurMobCount > mobOverLap + 1) { --i; continue; }
            // �̹� ������ ���� ��ġ�� ���� ������ ���� ��ġ�� ���ؾ���.

            MOBS = Instantiate(MonsterPrefab, Vector3.zero, Quaternion.identity);
            mobs[CurMobCount] = MOBS;
            MOBS.Init(Vector3.zero, (MOBINFO)MonsterRandom);
            mobs[CurMobCount].transform.position = randvec;

            mobs[CurMobCount].transform.SetParent(gameObject.transform);
            CurMobCount++;
        }

        // �÷��̾� ����
        /*PLAYER = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);
        Debug.Log("������! �÷��̾�! ����!");
        PLAYER.name = PlayerPrefab.name.Replace("(Clone)", "");
        PLAYER.transform.SetParent(gameObject.transform);*/
    }
    private void Start()
    {
     /*   Debug.Log(Player.INSTANCE.PlayerCam.gameObject.activeSelf);
        Player.INSTANCE.PlayerCam.gameObject.SetActive(false);*/        
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(Player.INSTANCE.PlayerCam.gameObject.activeSelf);
            Player.INSTANCE.PlayerCam.gameObject.SetActive(true);
        }*/
    }
}

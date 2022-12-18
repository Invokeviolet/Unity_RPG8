using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner_ACTION : MonoBehaviour
{
    // �̱���
    #region �̱���

    private static MapSpawner_ACTION Instance = null;
    public static MapSpawner_ACTION INSTANCE
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<MapSpawner_ACTION>();
            }

            return Instance;
        }
    }
    #endregion

    // �� ���� ����
    [SerializeField] GameObject MapCubePrefab;

    // ���� ������ �޾ƿ���
    [SerializeField] BossMonster MonsterParentPrefab;
    [SerializeField] Monster MonsterPrefab;

    GameObject MAPCUBE = null;
    BossMonster ActionMobParents = null;
    Monster ActionMob;

    // ���� ��
    private int CurActionMobCount = 0;
    private int MaxActionMobCount = 10;


    Vector3 MobPos;
    Vector3 MobParentPos;

    private void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);

        MobPos = new Vector3(2000,0,10);
        MobParentPos = new Vector3(2000,0,100);
    }

    void Start()
    {
        MAPCUBE = Instantiate(MapCubePrefab, transform.position, Quaternion.identity,transform);        
        ActionMobParents = Instantiate(MonsterParentPrefab, MobParentPos, Quaternion.identity, transform);
        ActionMob = Instantiate(MonsterPrefab, MobPos, Quaternion.identity, transform);
       
    }
    
    void Update()
    {
        
    }

    // ���� 1
    // ���� ��ü
    // ���� ���ʹ� ��ü�ֺ����� �����Ǿ� �÷��̾�� �̵�
    // �÷��̾ ���⸦ ����ؼ� ����
    // ���� ���͸� �� ������ 5�� �ڿ� �����
    // ��ü�� �� ���� ������ ����� �ݺ�

    // ���� 2
    // ���� ��ü
    // ���� ���� ���� ����
    // ������ ��ġ�� ��ų ������ �־���
    // �÷��̾�� �̵�Ű�� �̵��ϸ鼭 ���ϱ� ����
    // �� ����Ŭ �� ��ų ������ 2��, 4��, 6��, 8��, 10������ �̾���.
    // �ʿ� �����ϰ� ���ݾ����� ���� -> ������ ��ü���� ������
    // ���� ����Ƚ���� ä��� ��ü�� ���ݰ����� ���°� ��.
    // ��ü�� ������ ���� ��

    // ���� 3
    // ��ü
    // ���� ���� ����
    // 



    // ���̵��� ���� ����(���� ����)
    // EASY - ��� 100, ����ġ 100, ������ 1
    // NORMAL - ��� 200, ����ġ 200, ������ 2
    // HARD - ��� 300, ����ġ 300, ������ 3

}

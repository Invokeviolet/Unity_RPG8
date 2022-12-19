using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner_ACTION : MonoBehaviour
{

    // �� ���� ����
    [SerializeField] GameObject ActionMapPrefab;

    // ���� ������ �޾ƿ���
    [SerializeField] BossMonster MonsterParentPrefab;
    [SerializeField] Monster[] MonsterPrefab;

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
        // MobPos = new Vector3(2000, 0.5f, 10);
        MobParentPos = new Vector3(2000, 1f, 100);
        CurActionMobCount = MaxActionMobCount;
    }

    void Start()
    {
        MAPCUBE = Instantiate(ActionMapPrefab, transform.position, Quaternion.identity, transform);
        ActionMobParents = Instantiate(MonsterParentPrefab, MobParentPos, Quaternion.identity, transform);

        for (int i = 0; i < MonsterPrefab.Length; i++)
        {
            MobPos = new Vector3(Random.Range(1950,2000), 0.5f, Random.Range(0, 100));
            ActionMob = Instantiate(MonsterPrefab[i], MobPos, Quaternion.identity, transform);
        }
    }

    void Update()
    {
        MobPos += new Vector3(Random.Range(-100, 100), 0.5f, Random.Range(-100, 100));        
    }

   
    // ���̵��� ���� ����(���� ����)
    // EASY - ��� 100, ����ġ 100, ������ 1
    // NORMAL - ��� 200, ����ġ 200, ������ 2
    // HARD - ��� 300, ����ġ 300, ������ 3

}

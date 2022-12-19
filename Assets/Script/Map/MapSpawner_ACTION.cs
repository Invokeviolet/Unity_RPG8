using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner_ACTION : MonoBehaviour
{

    // 맵 지면 생성
    [SerializeField] GameObject ActionMapPrefab;

    // 몬스터 프리팹 받아오기
    [SerializeField] BossMonster MonsterParentPrefab;
    [SerializeField] Monster[] MonsterPrefab;

    GameObject MAPCUBE = null;
    BossMonster ActionMobParents = null;
    Monster ActionMob;

    // 몬스터 수
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

   
    // 난이도에 따른 보상(추후 변경)
    // EASY - 골드 100, 경험치 100, 아이템 1
    // NORMAL - 골드 200, 경험치 200, 아이템 2
    // HARD - 골드 300, 경험치 300, 아이템 3

}

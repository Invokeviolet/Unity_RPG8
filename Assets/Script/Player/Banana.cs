using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    // Ǯ �Ŵ���
    PoolingManager poolManager;

    // �ڱ� �ڽ��� ������
    Banana bananaPrefab;

    // �ٳ��� �ӵ� & ���ݷ�
    float BananaSpeed = 10f;
    // int BananaPower = 10;

    Transform bananaTarget;

    private void Awake()
    {
        poolManager = FindObjectOfType<PoolingManager>();
        bananaPrefab = GetComponent<Banana>();
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        BananaLaunch();
    }
    // �ٳ����� ȭ�� �߾ӿ� �ִ� ���� UI �߾����θ� �߻�ǵ��� ������ ��
    public void BananaLaunch()
    {
        transform.Translate(Vector3.forward * BananaSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.CompareTag("Monster")) || (other.gameObject.CompareTag("BossMonster")))
        {
            poolManager.DestroyBanana(bananaPrefab);
        }
        
    }
}

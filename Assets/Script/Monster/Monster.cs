using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public int CurMobCount { get; set; }
    public int MaxMobCount = 10;
    public bool IsDead { get; set; }


    MOBINFO mobInfo;

    // ü�� �޾ƿ���
    public int HP { get; set; }

    // �� ���� 
    public MOBINFO MOBINFO { get { return mobInfo; } set { mobInfo = value; } }

    private void Start()
    {
        CurMobCount = MaxMobCount;
    }
    private void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Banana"))
        {
            HP -= Player.INSTANCE.PlayerAttackPower;
            if (HP <= 0)
            {
                DeadMonster();
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            // �÷��̾�� ������ �ֱ�
            int rndDamage = Random.Range(0, 10);
            GameManager.INSTANCE.GetPlayer().PlayerHP -= rndDamage;
        }
    }
    public void DeadMonster()
    {
        IsDead = true;
        Destroy(this.gameObject);
        UIManager.INSTANCE.Check4WhoIsWin(false);

        CurMobCount--;
        if (CurMobCount == 0)
        {
            UIManager.INSTANCE.Check4WhoIsWin(true);
            UIManager.INSTANCE.RESULTSCENE(); // �� ��Ҵ�! ���â �����
        }
        // �÷��̾� ����ġ ����
        Player.INSTANCE.ExpUpdate(10);
    }

    // ���ʹ� �����Ǹ� �÷��̾ ã�� �̵��Ѵ�.
    // Ÿ��, �̵� ���ǵ�, �̵� ����    
    // NONE, IDLE, MOVE, TRACKING, ATTACK, DIE
}


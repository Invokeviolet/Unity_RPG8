using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public bool IsDead { get; set; }

    int AttackPower;

    MOBINFO mobInfo;
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

    // ���ݹ����� ���� ��������ŭ HP ����
    public void HitMonster(int damage)
    {
        
    }
    public void IMDEAD()
    {
        IsDead = true;
        Destroy(this.gameObject);
        UIManager.INSTANCE.Check4WhoIsWin(false);
        // 2�� �� ���� ��Ҵٴ� â ����
        Invoke("UIManager.INSTANCE.RESULTSCENE()", 2f);
        // �÷��̾� ����ġ ����
        Player.INSTANCE.ExpUpdate(10);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wepon")) 
        {
            HP -= Player.INSTANCE.PlayerAttackPower;
            if (HP <= 0)
            {
                IMDEAD();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // �÷��̾�� ������ �ֱ�
            int rndDamage = Random.Range(0, 10);
            GameManager.INSTANCE.GetPlayer().PlayerHP -= rndDamage;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        { 
            // �ִϸ��̼� �Ǵ� ����Ʈ ���
        }
    }

}
      

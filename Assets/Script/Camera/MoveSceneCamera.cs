using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneCamera : MonoBehaviour
{
    // ī�޶� ��ġ
    [Header("ī�޶� �̵� ��ġ ����")]
    [SerializeField] Transform[] C_Pos; // ���� ��ġ �迭�� ���

    // �̵� ����
    float cameraMove;
    float speed;
    float time = 0f;



    private void Awake()
    {
        speed = 50f;
    }

    void Start()
    {
        // ī�޶� ���� ��ġ ����        
        // Ÿ��Ʋ �� ��ġ ����
        // ��ŸƮ��ư ������ �ΰ��� ��ġ�� �̵�
        // ���Ϳ� �浹�ϸ� ������ ��ġ�� �̵�
        // ������ �����ų� ��ư�� ������ �ΰ��� ��ġ�� �̵�
        // 
    }


    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CameraPos1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CameraPos2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CameraPos3();
        }*/

    }

    public enum STATE
    {
        NONE, TITLE, MOVEPOSSTATE
    }

    Coroutine curCoroutine = null;
    STATE curState = STATE.NONE;

    void newSTATE(STATE newState)
    {
        // newState = curState
        if (newState == curState) return;
        if (curCoroutine != null)
        {
            StopCoroutine(curCoroutine);
        }
        curState = newState;
        curCoroutine = StartCoroutine(newState.ToString() + "_STATE");
        
    }


    // GameObject -> ��ġ�� ���� / Camera -> ȸ���� ����
    IEnumerator MOVEPOSSTATE(Vector3 target)
    {
        Vector3 temp = target; // temp�� target ��ġ ���
        target = new Vector3(this.transform.position.x, target.y+20, this.transform.position.z); // Ÿ�� ��ġ ��ǥ ���� y���� 0���� ����
        // ��ǥ ��ġ - �� ��ġ . normalize
        Vector3 dir = (target - gameObject.transform.position).normalized; // ���⺤�� ���ϱ�

        while (Vector3.Distance(target, transform.position) >= 1f) // Ÿ�� ��ġ�� �� ��ġ ���� �Ÿ� ���ϱ�
        {
            transform.Translate(dir * speed * Time.deltaTime); // ������ ����� �������� �̵�
            yield return null;
        }
        //this.transform.position = temp;

    }

   /* public void CameraPos1() 
    {
        StartCoroutine(MOVEPOSSTATE(C_Pos[0].position));
    }
    public void CameraPos2()
    {
        StartCoroutine(MOVEPOSSTATE(C_Pos[1].position));
    }
    public void CameraPos3()
    {
        StartCoroutine(MOVEPOSSTATE(C_Pos[2].position));
    }*/
}

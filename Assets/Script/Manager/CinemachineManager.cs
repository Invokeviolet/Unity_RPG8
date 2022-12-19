using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineManager : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera TitleCamera;
    [SerializeField] CinemachineVirtualCamera IngameCamera;
    [SerializeField] CinemachineVirtualCamera ActionCamera;
    [SerializeField] CinemachineVirtualCamera StoreCamera;


    private void Awake()
    {        
       
    }
    private void Start()
    {
        OnTitleCamera();
        UIManager.INSTANCE.ingame += OnIngameCamera;
        UIManager.INSTANCE.action += OnActionCamera;
        UIManager.INSTANCE.store += OnStoreCamera;
    }

    private void Update()
    {

    }

    // ó�� ī�޶� ��ġ�� Ÿ��Ʋ �� ��ġ���� ����
    public void OnTitleCamera()
    {
        TitleCamera.MoveToTopOfPrioritySubqueue();
    }

    // �α��� ��ư�� ������ �ΰ��� �� ��ġ�� �̵�

    public void OnIngameCamera() 
    {
        IngameCamera.MoveToTopOfPrioritySubqueue();
    }
    public void MoveIngameScene() 
    { 
        // �ΰ��Ӿ����� �÷��̾�� �׻� ī�޶��� �߽���ġ�� ��ġ�ϵ��� �Ѵ�.
        
    }

    // �÷��̾ ���������� �̵��ϸ� ������ ī�޶� �Ѱ�
    public void OnActionCamera() 
    {
        ActionCamera = FindObjectOfType<Player>().GetComponentInChildren<CinemachineVirtualCamera>();
        ActionCamera.MoveToTopOfPrioritySubqueue();
    }

    public void OnStoreCamera()
    {
        StoreCamera.MoveToTopOfPrioritySubqueue();
    }
}

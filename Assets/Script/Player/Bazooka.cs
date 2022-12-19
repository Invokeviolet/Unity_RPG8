using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class Bazooka : MonoBehaviour
{
    // Ǯ �Ŵ���
    PoolingManager poolManager;

    // ����ĳ��Ʈ
    RaycastHit hit;

    // ���� �Կ��� �ٳ��� �����ϱ�
    [SerializeField] Transform BazookaPoint;

    // �ٳ��� ������
    [SerializeField] Banana bananaPrefab;


    private void Awake()
    {

    }
    void Start()
    {
        poolManager = FindObjectOfType<PoolingManager>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit,Mathf.Infinity)) //touchPlaneLayerMask
        {
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward)*hit.distance, Color.red);
            // Debug.Log(hit.collider.name);

            if (Input.GetMouseButtonDown(0) && (GameManager.INSTANCE.myPlayerAction == true))
            {
                poolManager.CreateBanana(transform.position, transform.rotation);
            }
        }

    }
    /*void InitBanana()
    {
        Banana banana = Instantiate(bananaPrefab, BazookaPoint.transform.position, Quaternion.identity);
    }*/
}

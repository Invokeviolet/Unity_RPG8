using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // ���콺Ŀ���� ���� ī�޶� ȸ��
    public float speed = 2.5f;
    private float xRotate = 0.0f;

    void Update()
    {
        // �¿��̵� * �ӵ�
        float yRotateSize = Input.GetAxis("Mouse X") * speed;
        // y�� ȸ���� + ���ο� ȸ������
        float yRotate = transform.eulerAngles.y + yRotateSize;
        // ���Ʒ��̵� * �ӵ�
        float xRotateSize = -Input.GetAxis("Mouse Y") * speed;
        // ���Ʒ� ȸ���� + ���ο� ȸ������, ���� ����
        // Clamp ���� ������ ���� -> min, max
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -40, 60);
        // ī�޶� ȸ���� = ī�޶� �ݿ�
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }
}

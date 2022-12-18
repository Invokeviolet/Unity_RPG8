using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineManager : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera IngameCamera;
    [SerializeField] CinemachineVirtualCamera ActionCamera;

    // 인게임에서 전투씬으로 넘어갈 때 로직
    //

    private void Awake()
    {
        // IngameCamera.MoveToTopOfPrioritySubqueue();

    }
    float time = 0;
    private void Update()
    {
        ActionCamera = FindObjectOfType<Player>().GetComponentInChildren<CinemachineVirtualCamera>();

        time += Time.deltaTime;
        if (time >= 3f)
        {
            IngameCamera.MoveToTopOfPrioritySubqueue();
            time = 0;
        }

    }
}

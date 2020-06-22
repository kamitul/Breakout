using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField]
    public static Camera mainCamera = default;

    [SerializeField]
    private Transform upBorder = default;

    [SerializeField]
    private Transform downBorder = default;

    [SerializeField]
    private Transform leftBorder = default;

    [SerializeField]
    private Transform rightBorder = default;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        SetBorderCubePosition();
        ActivateBorderCubes();
    }

    private void ActivateBorderCubes()
    {
        upBorder.gameObject.SetActive(true);
        downBorder.gameObject.SetActive(true);
        rightBorder.gameObject.SetActive(true);
        leftBorder.gameObject.SetActive(true);
    }

    private void SetBorderCubePosition()
    {
        upBorder.position = new Vector3(0f, GetCameraHeight() + 0.5f, 15f);
        downBorder.position = new Vector3(0f, -GetCameraHeight() - 2f, 15f);
        leftBorder.position = new Vector3(-GetCameraWidth() - 0.5f, 0f, 15f);
        rightBorder.position = new Vector3(GetCameraWidth() + 0.5f, 0f, 15f);
    }

    public float GetCameraWidth()
    {
        return mainCamera.orthographicSize * Screen.width / Screen.height;
    }

    public float GetCameraHeight()
    {
        return mainCamera.orthographicSize;
    }
}

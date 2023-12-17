using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    [SerializeField] private float trackingSpeed = 2f;
    [SerializeField] private float offsetZ = 3f;
    [SerializeField] private float offsetY = 3f;
    [SerializeField] private float offsetX = 0.66f;
    public Transform target;
    public Vector3 inGameCameraPos;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (target)
        {
            Vector3 tempPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, target.position.z - offsetZ);
            transform.position = Vector3.Lerp(transform.position, tempPosition, trackingSpeed * Time.deltaTime);
        }
    }
    public void SetTarget(Transform ttarget)
    {
        target = ttarget;
    }
    public void ChangeCamPos()
    {
        transform.DORotate(inGameCameraPos, 1f);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public GameObject model;
    public Animator animator;
    public Transform checkGroundPoint;
    public float checkGroundRadius;
    public float checkSphereDelay;
    public Joystick joystick;
    public LayerMask layerMask;
    public LayerMask trampMask;
    public Rigidbody rigidbody;
    public float moveSpeed;
    private bool isGrounded;
    private float ySpeed=-5;
    private void Awake()
    {
        if (!rigidbody)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        if (!joystick)
        {
            joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        }
    }
    private void Start()
    {
        if (GameManager.instance.isGameStarted)
        {
            animator.SetBool("isGameStarted", true);
        }
    }
    private void Update()
    {
        if (GameManager.instance.isGameStarted)
        {
            IsGrounded();
            float h = joystick.Horizontal;
            Vector3 directionVector = new Vector3(h, ySpeed, 1);
            rigidbody.velocity = Vector3.ClampMagnitude(directionVector, 1) * moveSpeed;
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - joystick.Horizontal * 9f);
            model.transform.DORotateQuaternion(Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - joystick.Horizontal * 9f), Time.deltaTime);
        }

    }
    private void FixedUpdate()
    {
        
    }
    private void IsGrounded()
    {
        isGrounded = false;
        if (Physics.CheckSphere(checkGroundPoint.position, checkGroundRadius, layerMask))
        {
            isGrounded = true;
            ySpeed = -0.5f;
        }
        if (Physics.CheckSphere(checkGroundPoint.position, checkGroundRadius, trampMask))
        {
            isGrounded = true;
            ySpeed = 0;
        }
        if (!isGrounded)
        {
            ySpeed = -1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Obstacle")
        {
            Death();
        }
        if (other.tag=="Coin")
        {
            GameManager.instance.AddMoney();
            Destroy(other.gameObject);
        }
    }
    public void Death()
    {
        animator.SetBool("isDead", true);
        GameManager.instance.EndGame();
    }
}

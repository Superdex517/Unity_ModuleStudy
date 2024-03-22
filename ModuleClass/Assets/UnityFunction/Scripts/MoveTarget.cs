using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTarget : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button moveToward;
    [SerializeField] private Button lerpMoveToward;
    [SerializeField] private Button rigidBody;
    [SerializeField] private Button translate;
    [SerializeField] private Button stop;

    private bool isMoveTo = false;
    private bool isLerpMoveTo = false;
    private bool isRigidbody = false;
    private bool isTranslate = false;

    [Header("Transform")]
    public Transform originPos;
    public Transform player;
    public Transform target;
    public Rigidbody rb;
    public Vector3 moveDirection;

    [Header("Speed")]
    public float speed;
    public float t;
    public float force;

    void Start()
    {
        moveToward.onClick.AddListener(() => isMoveTo = true);
        lerpMoveToward.onClick.AddListener(() => isLerpMoveTo = true);
        rigidBody.onClick.AddListener(() => isRigidbody = true);
        translate.onClick.AddListener(() => isTranslate = true);

        stop.onClick.AddListener(() => FalseAll());
    }

    private void FixedUpdate()
    {
        Vector3 a = player.position;
        Vector3 b = target.position;
        
        if(isMoveTo)
            player.position = Vector3.MoveTowards(a, b, speed);

        if (isLerpMoveTo)
            player.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed);

        if (isRigidbody)
        {
            Vector3 f = target.position - player.position;
            f = f.normalized;
            f = f * force;
            rb.AddForce(f);
        }

        //self일때는 transform 기준으로 움직임
        if (isTranslate)
            player.Translate(moveDirection, Space.World);
    }

    public void FalseAll()
    {
        player.position = originPos.position;
        isMoveTo = false;
        isLerpMoveTo = false;
        isRigidbody = false;
        isTranslate = false;
    }
}

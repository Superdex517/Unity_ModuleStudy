using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private Button moveToward;
    [SerializeField] private Button stop;

    private bool isMoveTo = false;

    public Transform originPos;
    public Transform player;
    public Transform target;

    public float speed;

    void Start()
    {
        moveToward.onClick.AddListener(() => isMoveTo = true);
        stop.onClick.AddListener(() => FalseAll());

    }

    private void FixedUpdate()
    {
        Vector3 a = player.position;
        Vector3 b = target.position;
        
        if(isMoveTo)
            player.position = Vector3.MoveTowards(a, b, speed);

    }

    public void FalseAll()
    {
        player.position = originPos.position;
        isMoveTo = false;
    }

}

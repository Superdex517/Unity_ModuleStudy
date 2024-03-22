using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseLerp : MonoBehaviour
{
    [SerializeField] private Button originLerp;
    [SerializeField] private Button certainLerp;
    [SerializeField] private Button curvedLerp;
    [SerializeField] private Button stopCo;

    [SerializeField] private Transform player;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    private bool isArrive = true;

    [SerializeField] private float moveTime;
    [SerializeField] private AnimationCurve moveCurve;

    private void Awake()
    {
        player.position = start.position;

        originLerp.onClick.AddListener(() =>  StartCoroutine(CoOriginLerpMove()));
        certainLerp.onClick.AddListener(() => StartCoroutine(CoConstantLerpTransform()));
        curvedLerp.onClick.AddListener(() => StartCoroutine(CoCurvedLerpTransform()));
        stopCo.onClick.AddListener(() => StopAllCoroutines());
    }

    void Update()
    {
    //    if (isArrive)
    //        UpdateTransform(end);
    //    else
    //        UpdateTransform(start);
    }

    void UpdateTransform(Transform tr)
    {
        player.position = Vector3.Lerp(player.position, tr.position, Time.deltaTime);

        if (Vector3.Distance(player.position, end.position) <= 0.1f)
        {
            player.position = end.position;
            isArrive = false;
        }
        else if(Vector3.Distance(player.position, start.position) <= 0.1f)
        {
            player.position = start.position;
            isArrive = true;
        }
    }

    //등속 이동
    IEnumerator CoConstantLerpTransform()
    {
        player.position = start.position;

        float current = 0;
        float percent = 0;

        Transform st = start;
        Transform en = end;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            player.position = Vector3.Lerp(st.position, en.position, percent);


            if (Vector3.Distance(player.position, end.position) <= 0.1f)
            {
                player.position = end.position;
                st = end;
                en = start;
                percent = 0;
                current = 0;
            }
            else if (Vector3.Distance(player.position, start.position) <= 0.1f)
            {
                player.position = start.position;
                st = start;
                en = end;
                percent = 0;
                current = 0;
            }
            //current = 0;

            yield return null;
        }
    }

    IEnumerator CoOriginLerpMove()
    {
        player.position = start.position;
        Transform tr = end;

        while (true)
        {
            player.position = Vector3.Lerp(player.position, tr.position, Time.deltaTime);

            if (Vector3.Distance(player.position, end.position) <= 0.1f)
            {
                player.position = end.position;
                tr = start;
            }
            else if (Vector3.Distance(player.position, start.position) <= 0.1f)
            {
                player.position = start.position;
                tr = end;
            }

            yield return null;
        }
    }

    IEnumerator CoCurvedLerpTransform()
    {
        player.position = start.position;

        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            player.position = Vector3.Lerp(start.position, end.position, moveCurve.Evaluate(percent));

            yield return null;
        }
    }
}

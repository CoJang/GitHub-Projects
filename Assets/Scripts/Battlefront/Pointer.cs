using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    static public Pointer pointer;

    private LineRenderer Line;
    private Material LineMat;
    [SerializeField] Transform ArrowHead;

    private Vector3 mousePos;
    public Vector3[] points = new Vector3[2];

    private void Awake()
    {
        ArrowHead = GameObject.Find("TargetArrow").GetComponent<Transform>();
        gameObject.SetActive(false);

        pointer = this;

        Line = GetComponent<LineRenderer>();
        LineMat = Line.materials[0];

    }

    public float matLength = 0.5f;
    public float matSpeed = 0.05f;

    public void Init()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.SetActive(false);
        }

        // Moves Arrow To Mouse Position
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        ArrowHead.LookAt(points[0], new Vector3(1, 0, 0));
        //transform.LookAt(startPos);
        //ArrowHead.rotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z));
        //ArrowHead.rotation = Quaternion.Euler(new Vector3(0f, 0f,
        //    Mathf.Acos(Vector3.Dot(Vector3.up, ArrowHead.position.normalized)) * Mathf.Rad2Deg));

        points[1] = transform.position;
        Line.SetPositions(points);

        LineMat.mainTextureScale = new Vector2(Vector2.Distance(points[0], transform.position) * matLength, 1);
        LineMat.mainTextureOffset = new Vector2(LineMat.mainTextureOffset.x - matSpeed, 0);
    }
}

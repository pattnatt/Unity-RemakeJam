﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour {

    public float speed = 5.0f;
    [Range(0f, 8f)]  public float upperVericalLimit = 8f;
    [Range(-8f, 0f)] public float lowerVerticalLimit = -8f;
    [Range(0f, 4.5f)]  public float upperHorizontalcalLimit = 4.5f;
    [Range(-4.5f, 0f)] public float lowerHorizontalLimit = -4.5f;
    private float currentHorizontalDirection = 0f;
    private float currentVerticalDirection = 0f;
    private float sqrtHalf = Mathf.Sqrt(0.5f);

    void Start () {
    }

  // Update is called once per frame
    void Update () {
        Movement();
    }

    private void Movement()
    {
        currentHorizontalDirection = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            currentHorizontalDirection += 1f;
            transform.localScale = (Vector3.left * 2) + Vector3.one ;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            currentHorizontalDirection += -1f;
            transform.localScale = Vector3.one;
        }
        currentVerticalDirection = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            currentVerticalDirection += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            currentVerticalDirection += -1f;

        if (currentHorizontalDirection != 0f && currentVerticalDirection != 0f)
        {
            currentHorizontalDirection *= sqrtHalf;
            currentVerticalDirection *= sqrtHalf;
        }

        transform.position += Vector3.right * speed * Time.deltaTime * currentHorizontalDirection;
        transform.position += Vector3.up * speed * Time.deltaTime * currentVerticalDirection;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, lowerHorizontalLimit, upperHorizontalcalLimit),
            Mathf.Clamp(transform.position.y, lowerVerticalLimit, upperVericalLimit), transform.position.z);
    }
}

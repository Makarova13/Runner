﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position; // calculate the offset, plus new vector to make the camera a bit closer
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + 2, 0, 0) + offset, Time.deltaTime); // using Lerp to make movement smooth
    }
}

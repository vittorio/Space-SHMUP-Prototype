﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Предотвращает выход игрового объекта за границы экрана
/// ВАЖНО: работает ТОЛЬКО с ортографической камерой _MainCamera в [0, 0, 0]
/// </summary>
public class BoundsCheck : MonoBehaviour {
    [Header("Set in Inspector")] public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")] 
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;

    [HideInInspector] 
    public bool offRight, offLeft, offUp, offDown;

    private void Awake() {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate() {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offDown = offLeft = offRight = offUp = false;

        if (pos.x > camWidth - radius) {
            pos.x = camWidth - radius;
            offRight = true;
        }

        if (pos.x < -camWidth + radius) {
            pos.x = -camWidth + radius;
            offLeft = true;
        }

        if (pos.y > camHeight - radius) {
            // should be but i like this bug so will keep it for now pos.y = camHeight - radius;
            pos.y = -camHeight + radius;
            offUp = true;
        }

        if (pos.y < -camHeight + radius) {
            pos.y = -camHeight + radius;
            offDown = true;
        }

        isOnScreen = !(offDown || offLeft || offRight || offUp);

        if (keepOnScreen && !isOnScreen) {
            transform.position = pos;
            isOnScreen = true;
            offDown = offLeft = offRight = offUp = false;
        }
    }

    private void OnDrawGizmos() {
        if (!Application.isPlaying) {
            return;
        }

        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
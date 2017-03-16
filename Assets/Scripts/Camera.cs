﻿using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;

        //print(" Método Start ");
	}

    
	// Update is called once per frame
	void LateUpdate() {
        transform.position = player.transform.position + offset;
	}
}

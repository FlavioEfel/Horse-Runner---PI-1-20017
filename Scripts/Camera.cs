﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // segue o jogador com a distância desejada
        transform.position = new Vector3 ( playerBehaviour.playerTransform.position.x + 7.5F, 5, -15 );
       


	}
}

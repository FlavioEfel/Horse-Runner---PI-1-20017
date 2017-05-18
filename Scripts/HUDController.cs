using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    [SerializeField] Text scoreText;
    [SerializeField] Slider healthBar, energyBar;

    public static int score;

	// Use this for initialization
	void Start () {
        

		
	}
	
	// Update is called once per frame
	void Update () {
        // mostrar a pontuação
        score = (int) playerBehaviour.playerTransform.position.x + (playerBehaviour.coins*400);
        scoreText.text = "Score:" + score;

        // vida e energia
        healthBar.value = (playerBehaviour.health / 100);
        energyBar.value = (playerBehaviour.energy / 100);
	}
}


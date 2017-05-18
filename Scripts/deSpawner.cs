using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // caso a  distãncia no eixo x seja maior do que 20, o objeto se auto-destruirá
		if ( transform.position.x < (playerBehaviour.playerTransform.position.x - 20))
        {
            Destroy ( gameObject );
        }
	}
}

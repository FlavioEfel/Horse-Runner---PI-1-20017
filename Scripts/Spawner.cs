 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    GameObject groundPrefab;
    public float groundSpawningPositionX = 0;

    // variaveis para spawn de obstáculos
    public GameObject coinPrefab;
    public GameObject treePrefab;
    public GameObject wallPrefab;
    public float obstacleSpawningDelay = 5;

    //variaveis para o spawn do background
    public GameObject backGroundPrefab;
    public float backGroundSpawningPosition = 0;

    // Use this for initialization
    void Start () {
        spawnGround ( );
        spawnBackGround ( );
        

	}
	
	// Update is called once per frame
	void Update () {

        // caso a distância entre o jogador e groundSpawningPositionX seja menor do que 23, será spawnado um obj Chão
        // esse objeto server para o jogador passar
        if (playerBehaviour.playerTransform.position.x >= (groundSpawningPositionX - 23))
        {
            spawnGround ( );
        }

        // caso a distancia entre o jogador e backGroundSpawningPosition seja maior do que 35, será spawnado um background
        if (playerBehaviour.playerTransform.position.x > (backGroundSpawningPosition-35))
        {
            spawnBackGround ( );
        }

        // spawna os osbstáculos e controla o delay e o ritmo em que eles serão spawnados
        if (obstacleSpawningDelay <= 0)
        {
            int spawnNext = Random.value > .5f ? 0 : 1 ;

            switch (spawnNext)
            {
                case 0:
                    SpawnRock ( groundSpawningPositionX, 1 );
                    break;
                case 1:
                    SpawnTree ( groundSpawningPositionX );
                    break;

            };

                  
        }
        else
        {
            obstacleSpawningDelay -= 1 * Time.deltaTime;
        }
		
	}

    public void SpawnTree ( float xPosition, float spacing = 0 )
    {

        Instantiate ( treePrefab, new Vector3 ( xPosition, .5f, 0 ), Quaternion.Euler ( 0, 0, 0 ) ); // cria a árvore
        Instantiate ( coinPrefab, new Vector3 ( xPosition, 5.5f, 0 ), Quaternion.Euler ( 0, 0, 0 ) );// cria uma moeda em cima da arvore

        obstacleSpawningDelay += (2f + (Random.value * 1));
    }

    /**
     *  cria um inimigo coma  posição X especificada
     * 
     * param name="xPosition" a posição X que o objeto será spawnado
     * */
    public void SpawnRock ( float xPosition, float spacing = 0 )
    {

        Instantiate ( wallPrefab, new Vector3 ( xPosition, 1.2f, 0 ), Quaternion.Euler ( 0, 0, 0 ) );
                
        obstacleSpawningDelay += 2;
    }

    /**
     * instancia o chão que o jogador vai pisar
     */ 
    public void spawnGround ( )
    {
        Instantiate ( groundPrefab, new Vector3 ( groundSpawningPositionX, 0, 0 ), new Quaternion ( ) );
        groundSpawningPositionX += 5;
    }

    public void spawnBackGround ( )
    {
        Instantiate ( backGroundPrefab, new Vector3 ( backGroundSpawningPosition, 4.6f, 3 ), Quaternion.Euler ( 90, 0, -180 ) );
        backGroundSpawningPosition += 18.8f;
    }
}

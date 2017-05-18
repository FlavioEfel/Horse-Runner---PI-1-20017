using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour {

    public static Transform playerTransform;       //transform do personagem
    public static Rigidbody playerRigidbody;       // rb do personagem

    //variáveis relacionadas ao pulo \/ \/ \/ 
    public  bool isOnGround;                       // diz se o jogador está no chão
    public int maxAirJump = 1, currentAirJump = 0; // máximo de pulos que o jogador pode realizar no ar
    public float jumpTime;                         //momento do último pulo( usado para calcular o tempo de delay)

    // variáveis de vida , energia e pontuação
    public static int  coins = 0;
    public static float health = 100, energy = 100;


	
	void Start () {
        playerTransform = transform;   // define a varoável playerTransform como o transform desse GameObject

        // busca e retorna o primeiro rb no GameObject, caso a variável seja nula
        if (playerRigidbody == null)
        {
            playerRigidbody = gameObject.GetComponent<Rigidbody> ( );
        }
	}
	
	
	void FixedUpdate () {

        transform.Translate ( .15f, 0, 0 ); // move o jogaodor no eixo x

        /*
         * Caso o jogador aperte a tecla de pulo e esteja no chão, o personagem irá pular. 
         * Caso ele esteja no ar ele só pulará no caso de currentAirJump ser maior do que 0.
         */
        if ( (Input.GetKeyDown ( KeyCode.Space )) && (isOnGround) ) 
        {
            Jump ( );
            isOnGround = false;
        }
        else if ((Input.GetKeyDown ( KeyCode.Space )) && (currentAirJump > 0))
        {
            Jump ( );
            isOnGround = false;
            currentAirJump -= 1;
        }



    }

    /**
     *  Faz o personagem saltar usando o rb preso a ele ( 500 * a massa do personagem).
     */
    void Jump ( )
    {
        playerRigidbody.AddForce ( 0, 500    * playerBehaviour.playerRigidbody.mass, 0 );


      
    }

    private void OnCollisionStay ( Collision collision )
    {
        // diz se o jogador está no chão
        isOnGround = true;
        currentAirJump = maxAirJump;
    }

    private void OnCollisionExit ( Collision collision )
    {
        // diz se o jogador saiu do chão
        isOnGround = false;        
    }

    // calcula as colisões e o dano recebido caso o jogador bata em algo
    private void OnCollisionEnter ( Collision c )
    {
        
        if(c.transform.gameObject.tag.Equals("Wall"))
        {
            Destroy ( c.transform.gameObject );
            health -= 50; Debug.Log ( "hit simething!" );
        }
        else if (c.transform.gameObject.tag.Equals ( "Tree" ))
        {
            Destroy ( c.transform.gameObject );
            health -= 30;
        }

        
    }

    private void OnTriggerEnter ( Collider t )
    {
        if (t.transform.gameObject.tag.Equals ( "Coin" ))
        {
            Destroy ( t.transform.gameObject );
            coins++;
        }
    }
}

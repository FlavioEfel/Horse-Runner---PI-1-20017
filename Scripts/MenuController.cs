using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class MenuController : MonoBehaviour {

   	
	void Start () {
        Debug.Log ( "a" ); 
    }

    private void Update ( )
    {

    }

   

    public void changeScene ( int scene )
    {
        SceneManager.LoadScene ( scene );
    }

    public void exitGame (  )
    {
      
    }
}

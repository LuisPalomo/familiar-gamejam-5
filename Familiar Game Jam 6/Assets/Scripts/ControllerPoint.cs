 using UnityEngine;
using System.Collections;

public class ControllerPoint : MonoBehaviour 
{
public Vector2 v1 = new Vector2(0,0);	
 
  public Transform push;
  public int cuadrante=0;
  float Tiempo=0.0f;

  
  public int contador_push = 5;
  
  public int cont_invulnerable=10;
  int cont_invulnerable_inicial = 10;
  
  public int invulnerable=0;

	int modoJuego= 1;

	void Start () {
		cont_invulnerable_inicial = cont_invulnerable;

		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat ("volumeFX");
		modoJuego=PlayerPrefs.GetInt ("modoDeJuego");
	}

	void Update () {
		Vector3 inputPosition = Input.mousePosition;

		Vector3 raton = new Vector3 (inputPosition.x,inputPosition.y,21); 

		Debug.Log (modoJuego);

		float d=Vector3.Distance (raton,transform.position);

		if (d < 450f &&  modoJuego== 1) {
						transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (inputPosition.x, inputPosition.y, 21));
				} else {
			transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (inputPosition.x, inputPosition.y, 21));
				}
	

		Tiempo = Tiempo + 1 * Time.deltaTime;


if(Tiempo >= 1.0f){
         
         contador_push--;
         if(invulnerable==1){
          cont_invulnerable--;
         }
         Tiempo = 0;
	}

		if(cont_invulnerable<0){
			invulnerable=0;
			cont_invulnerable=cont_invulnerable_inicial;
		}


       
         
        
        if (contador_push <= 0){
        if(cuadrante==1){
          Instantiate(push,new Vector3(-1.712132f,-1.438826f,-2f),Quaternion.identity);
        }else if(cuadrante==2){
          Instantiate(push,new Vector3(2.412416f,-1.610682f,-2f),Quaternion.identity);
        }else if(cuadrante==3){
          Instantiate(push,new Vector3(2.859242f,2.410752f,-2f),Quaternion.identity);
        }else if(cuadrante==4){
          Instantiate(push,new Vector3(-2.2277f,2.10141f,-2f),Quaternion.identity);
          }
        contador_push = 5;

        }
		


	}

	void OnTriggerStay2D(Collider2D col) {
        if	(col.gameObject.tag== "Cuadrante1"){
        	cuadrante=1;
        	
        }else if (col.gameObject.tag== "Cuadrante2"){
        	cuadrante=2;  	 
        }else if (col.gameObject.tag== "Cuadrante3"){
        	cuadrante=3;
        	
        }else if (col.gameObject.tag== "Cuadrante4"){
        	cuadrante=4;
        	
        }else if(col.gameObject.tag=="push"){
			GetComponent<AudioSource>().Play();
          Destroy(col.gameObject);
          invulnerable=1;
        }
    }
		

}
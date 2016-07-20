using UnityEngine;
using System.Collections;

public class SimpleCameraFade : MonoBehaviour{	
	void Start (){	
		//create a Camera Fade filled with a default color of black at a default depth of 999999:
		iTween.CameraFadeAdd();
		//fade the camera fade "from" an "amount" of 1 over 1 second (we can use the simple version of iTween here):
		iTween.CameraFadeFrom(1,1); 
	}
	
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			//by default iTween will call callbacks on the object that is being animated (in this case the "iTween Camera Fade" that was created in Start())
			//we need to provide a "oncompletetarget" to tell iTween that the method we want it to call is in this GameObject and NOT in "iTween Camera Fade"
			iTween.CameraFadeTo(iTween.Hash("amount",1,"time",1,"oncomplete","SwitchScene","oncompletetarget",gameObject)); 
		}
	}
	
	void SwitchScene(){
		Application.LoadLevel("C#");	
	}
}
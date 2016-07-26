using UnityEngine;
using System.Collections;

public class CameraFadeExample : MonoBehaviour{
	//The song in this project is copyright Pixelplacement 1998 Bob Berkebile (also the developer of iTween) do not use it for any commercial work - I included this file to help you mess around and test iTween only.
	
	public Texture2D cameraTexture;
	bool faded;
	
	void Start(){
		iTween.CameraFadeAdd(cameraTexture,200);
	}
	
	void OnGUI(){
		if(!faded){
			if(GUI.Button(new Rect(75,151,100,50),"Fade Up!")){
				iTween.CameraFadeTo(1,2);
				iTween.AudioTo(gameObject,0,0,2);
				faded=true;
			}
		}else{
			if(GUI.Button(new Rect(75,151,100,50),"Fade Down!")){
				iTween.CameraFadeTo(0,2);
				iTween.AudioTo(gameObject,1,1,2);
				faded=false;
			}	
		}
	}
}


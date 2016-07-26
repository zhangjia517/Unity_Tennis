//The song in this project is copyright Pixelplacement 1998 Bob Berkebile (also the developer of iTween) do not use it for any commercial work - I included this file to help you mess around and test iTween only.

var cameraTexture : Texture2D;
private var faded=false;

function Start(){
	iTween.CameraFadeAdd(cameraTexture,200);
}

function OnGUI(){
	if(!faded){
		if(GUI.Button(Rect(75,151,100,50),"Fade Up!")){
			iTween.CameraFadeTo(1,2);
			iTween.AudioTo(gameObject,0,0,2);
			faded=true;
		}
	}else{
		if(GUI.Button(Rect(75,151,100,50),"Fade Down!")){
			iTween.CameraFadeTo(0,2);
			iTween.AudioTo(gameObject,1,1,2);
			faded=false;
		}	
	}
}
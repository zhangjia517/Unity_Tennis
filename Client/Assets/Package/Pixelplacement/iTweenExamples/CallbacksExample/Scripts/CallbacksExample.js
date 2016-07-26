var style : GUIStyle;
var statusText : GUIText;
private var buttonActivated : boolean;

function Start(){
	tween();
}

function OnGUI () {
	if(buttonActivated){
		if(GUI.Button (Rect (67,178,113,32), "",style)){
			reset();
			tween();
		}
	}
}

function reset(){
	transform.position=Vector3(0,0,0);
	transform.rotation=Quaternion.identity;
	statusText.text="";
	buttonActivated=false;
}

function tween(){
	iTween.MoveBy(gameObject,{"y":2,"time":2,"easetype":"easeinoutexpo","onstart":"segmentStarted","onstartparams":"Rise started...","onupdate":"segmentUpdated","onupdateparams":"move","oncomplete":"segmentComplete","oncompleteparams":"Rise stopped."});
	iTween.RotateBy(gameObject,{"z":.25,"time":1,"easetype":"easeinoutback","delay":2.5,"onstart":"segmentStarted","onstartparams":"Rotate started...","onupdate":"segmentUpdated","onupdateparams":"rotate","oncomplete":"segmentComplete","oncompleteparams":"Rotate stopped."});
	iTween.MoveTo(gameObject,{"y":0,"time":.9,"easetype":"easeInExpo","delay":4,"onstart":"segmentStarted","onstartparams":"Fall started...","onupdate":"segmentUpdated","onupdateparams":"move","oncomplete":"segmentComplete","oncompleteparams":"Fall stopped."});
	
	//Notice that since we ae putting shake on the camera we need to tell the callbacks which target contains the method they need to call:
	iTween.ShakePosition(GetComponent.<Camera>().main.gameObject,{"y":.5,"time":.8,"delay":4.95,"onstart":"segmentStarted","onstartparams":"Shake started...","onstarttarget":gameObject,"onupdate":"segmentUpdated","onupdateparams":"shake","onupdatetarget":gameObject,"oncomplete":"allComplete","oncompletetarget":gameObject});
}

function segmentStarted(textToDisplay : String){
	statusText.text+=textToDisplay + "\n";
}

function segmentUpdated(method : String){
	switch(method){
		case "move":
		Debug.Log("Height at: " + transform.position.y);
		break;
		
		case "rotate":
		Debug.Log("Rotation at: " + transform.eulerAngles.z);
		break;
		
		case "shake":
		Debug.Log("Shake at: " + GetComponent.<Camera>().main.transform.position.y);
		break;
	}
}

function segmentComplete(textToDisplay : String){
	statusText.text+=textToDisplay + "\n";
}

function allComplete(){
	buttonActivated=true;	
	statusText.text += "All done animating!";
}
var path : Transform[];
var style : GUIStyle;
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

function OnDrawGizmos(){
	iTween.DrawPath(path);
}

function tween(){
	iTween.MoveTo(gameObject,{"path":path,"time":7,"orienttopath":true,"looktime":.6,"easetype":"easeInOutSine","oncomplete":"complete"});	
}

function reset(){
	buttonActivated=false;
	transform.position=Vector3(0,0,0);
	transform.eulerAngles=Vector3(0,0,0);
}

function complete(){
	buttonActivated=true;
}
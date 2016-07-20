private var hasFocus : boolean;

public var target : Transform;

function FixedUpdate ()
{	
	var pos : Vector3  = target.position;
	pos.z=-14;
	pos.y=target.position.y+2;
	iTween.MoveUpdate(gameObject,pos,.8);
}

function OnGUI(){
	if(!hasFocus){
		if(GUI.Button(new Rect(75,70,100,50),"Start!")){
			hasFocus=true;
		}
	}
}
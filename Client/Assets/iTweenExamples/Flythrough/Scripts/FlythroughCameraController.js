public var movePath : Transform[];
public var lookPath : Transform[];
public var lookTarget : Transform;
public var percentage : float;

private var redPosition : float = .16;
private var bluePosition : float = .53;
private var greenPosition : float = 1;

//gui styling
public var font : Font;
private var style : GUIStyle = new GUIStyle();

function Start(){
	style.font=font;
}
	
function OnGUI(){
	percentage=GUI.VerticalSlider(new Rect(Screen.width-20,20,15,Screen.height-40),percentage,1,0);
	iTween.PutOnPath(gameObject,movePath,percentage);
	iTween.PutOnPath(lookTarget,lookPath,percentage);
	transform.LookAt(iTween.PointOnPath(lookPath,percentage));
	//
	if(GUI.Button(new Rect(5,Screen.height-25,50,20),"Red")){
		SlideTo(redPosition);
	}
	if(GUI.Button(new Rect(60,Screen.height-25,50,20),"Blue")){
		SlideTo(bluePosition);
	}
	if(GUI.Button(new Rect(115,Screen.height-25,50,20),"Green")){
		SlideTo(greenPosition);
	}
}

function OnDrawGizmos(){
	iTween.DrawPath(movePath,Color.magenta);
	iTween.DrawPath(lookPath,Color.cyan);
	Gizmos.color=Color.black;
	Gizmos.DrawLine(transform.position,lookTarget.position);
}

function SlideTo(position : float){
	iTween.Stop(gameObject);
	iTween.ValueTo(gameObject,iTween.Hash("from",percentage,"to",position,"time",2,"easetype",iTween.EaseType.easeInOutCubic,"onupdate","SlidePercentage"));	
}

function SlidePercentage(p : float){
	percentage=p;
}

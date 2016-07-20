var depressColor : Color;
private var startColor : Color;
private var depressAmount : float = .3;
private var travelTime : float =.2;
private var startY : float;
private var destinationY : float;
private var go : GameObject;
private var id : int;

function Awake(){
	go=gameObject;
	startY = gameObject.transform.position.y;
	destinationY = startY - depressAmount;
	startColor=GetComponent.<Renderer>().material.color;
}

function OnMouseDown () {
	if(!BoardControl.wait){
		depress();
		gameObject.SendMessageUpwards ("sequenceCheck", id);
	}
}

function depress(){
	iTween.Stop(go);
	GetComponent.<Renderer>().material.color = depressColor;
	iTween.ColorTo(go,{"r":startColor.r,"g":startColor.g,"b":startColor.b,"time":travelTime*2,"delay":travelTime});
	iTween.MoveTo(go, {"y":destinationY,"transition":"easeOutCubic","time":travelTime});
	iTween.MoveTo(go, {"y":startY,"transition":"easeInCubic","time":travelTime,"delay":travelTime});
}

function setId(id : int){
	this.id=id;
}
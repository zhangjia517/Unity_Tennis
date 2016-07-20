private var currentColor : Color;
private var currentPosition : Vector3;
private var gameBoard : GameBoardJS;
private var isActive : boolean;

function Start(){
	currentColor=GetComponent.<Renderer>().material.color;
	currentPosition=transform.position;
}

function SetGameboard(gameBoard : GameBoardJS){
	this.gameBoard=gameBoard;
}

function Deactivate(){
	isActive=false;
	iTween.ColorTo(gameObject,currentColor,.4);
}

function Activate(){
	isActive=true;
	GetComponent.<Renderer>().material.color=Color.red;
	SendMessageUpwards("SetTarget",gameObject);	
	iTween.MoveTo(gameObject,currentPosition,.4);
}

function OnMouseEnter(){
	if(!isActive){
		if(!gameBoard.ballSet){
			GetComponent.<Renderer>().material.color=Color.yellow;
		}else{
			GetComponent.<Renderer>().material.color=Color.green;
		}
		transform.position=new Vector3(currentPosition.x,.5,currentPosition.z);
	}
}

function OnMouseExit(){
	if(!isActive){
		iTween.ColorTo(gameObject,currentColor,.4);
		iTween.MoveTo(gameObject,currentPosition,.4);
	}
}

function OnMouseDown(){
	if(gameBoard.ballSet){
		Activate();
	}
}
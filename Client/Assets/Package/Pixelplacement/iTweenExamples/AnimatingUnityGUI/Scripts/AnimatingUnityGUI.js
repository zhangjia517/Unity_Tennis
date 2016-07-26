var buttonState : boolean  = false;	
var button : Rect  = new Rect(75,20,100,55); //holds actual button rect coordinates
var initialPosition : Rect = new Rect(75,20,100,55); //holds starting rect coordinates
var activePosition : Rect = new Rect(75,130,100,55); //holds ending rect coordinates

function OnGUI(){
	if(GUI.Button(button,"Click Me!")){
		
		if(buttonState){
			iTween.ValueTo(gameObject,iTween.Hash("from",button,"to",initialPosition,"onupdate","MoveButton","easetype","easeinoutback"));	
		}else{
			iTween.ValueTo(gameObject,iTween.Hash("from",button,"to",activePosition,"onupdate","MoveButton","easetype","easeinoutback"));
		}
		buttonState = !buttonState;
	}
}

function MoveButton(newCoordinates : Rect){
	button=newCoordinates;
}
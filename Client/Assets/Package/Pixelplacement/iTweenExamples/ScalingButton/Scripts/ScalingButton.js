private var buttonStatus : boolean;
private var currentButton : Rect;
var buttonNormalSize : Vector2 = new Vector2(100,50);
var buttonHoverSize : Vector2 = new Vector2(200,70);
private var buttonPosition : Vector2 = new Vector2(250/2,211/2);

function Start(){
	//set starting button rect:
	currentButton.x=buttonPosition.x-(buttonNormalSize.x/2);
	currentButton.y=buttonPosition.y-(buttonNormalSize.y/2);
	currentButton.width=buttonNormalSize.x;
	currentButton.height=buttonNormalSize.y;
}

function OnGUI(){
	//the actual button:
	GUI.Button(currentButton,"Click Me!");
	
	//on mouse over:
	if(OnMouseOver(currentButton) && !buttonStatus){
		iTween.Stop(gameObject,"value");
		buttonStatus=true;
		iTween.ValueTo(gameObject,iTween.Hash("from",CurrentButtonSize(),"to",buttonHoverSize,"easetype",iTween.EaseType.easeOutBack,"onupdate","ScaleButton","time",.2));
	}
	
	//on mouse out:
	if (!OnMouseOver(currentButton) && buttonStatus) {
		iTween.Stop(gameObject,"value");
		buttonStatus=false;
		iTween.ValueTo(gameObject,iTween.Hash("from",CurrentButtonSize(),"to",buttonNormalSize,"easetype",iTween.EaseType.easeOutExpo,"onupdate","ScaleButton","time",.4));
	}
}

//grabs current rect of button:
function CurrentButtonSize():Vector2{
	return new Vector2(currentButton.width,currentButton.height);	
}

//checks if the mouse is over the button:
function OnMouseOver(buttonRect : Rect):boolean{
	if(buttonRect.Contains(Event.current.mousePosition)){
		return true;
	}else{
		return false;
	}		
}
		
//applies the values from iTween:
function ScaleButton(size : Vector2){
	currentButton.width=size.x;
	currentButton.height=size.y;
	currentButton.x=buttonPosition.x - (currentButton.width/2);
	currentButton.y=buttonPosition.y - (currentButton.height/2);
}
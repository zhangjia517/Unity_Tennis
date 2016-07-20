var img:Texture2D;
var prevButton:Texture2D;
var nextButton:Texture2D;

private var blankStyle : GUIStyle = new GUIStyle(); //an "empty" style to avoid any of Unity's default padding, margin and background defaults
private var container:Rect = new Rect(0,0,250,211);
private var content:Rect = new Rect(0,0,1250,211);
private var target:float=0;
private var currentSelection;

function OnGUI () {
	//scroll panel:
	GUI.BeginGroup(container);
	GUI.Label(content,img,blankStyle);
	GUI.EndGroup();
		
	//next button:
	if(GUI.Button(new Rect(180,140,70,71),nextButton,blankStyle) && target > -content.width+container.width){
		target-=container.width;
		EstablishSlide();
	}
	
	//prev button:
	if(GUI.Button(new Rect(0,140,70,71),prevButton,blankStyle) && target < 0){
		target+=container.width;
		EstablishSlide();
	}
	
	//select button:
	if(GUI.Button(new Rect(0,0,250,211),"",blankStyle)){
		Selected();
	}
}
	
function EstablishSlide(){
	currentSelection=Mathf.Abs(target)/container.width + 1;
	iTween.Stop(gameObject,"value");
	iTween.ValueTo(gameObject,iTween.Hash("time",.8,"from",content.x,"to",target,"easetype",iTween.EaseType.easeInOutExpo,"onupdate","ApplySlide"));
}

function ApplySlide(position:float){
	content.x=position;
}

function Selected(){
	print("Item: " + currentSelection + " was selected!");
}
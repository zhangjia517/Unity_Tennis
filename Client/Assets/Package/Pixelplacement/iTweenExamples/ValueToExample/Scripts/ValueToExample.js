var score : int = 0;
var bonus : int = 15;
var initialColor : Color;
var initialScale : Vector3;
var scoreDisplay : GUIText;

function Awake(){
	initialColor = 	GetComponent.<Renderer>().material.color;
	initialScale = Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
}

function OnMouseDown(){
	//iTween will ignore additional calls on a gameObject that have all of the same properties so we need to interrupt current iTweens:
	//Remember: iTween follows the "Doesn't Destroy Duplicates" approach.
	iTween.Stop(gameObject);
	
	//increment the score:
	iTween.ValueTo(gameObject,{"from":score,"to":score+bonus,"time":.6,"onUpdate":"UpdateScoreDisplay"});
	score+=bonus;
}

function OnMouseUp(){
	//reset:
	GetComponent.<Renderer>().material.color=initialColor;
	transform.localScale=initialScale;
	
	//visual feedback:
	iTween.ColorFrom(gameObject,new Color(1,1,.1),.3);
	iTween.ScaleFrom(gameObject,Vector3(1.5,initialScale.y,1.5),.5);
}

function UpdateScoreDisplay(newScore:int){
	scoreDisplay.text = "High Score: " + newScore.ToString();
}
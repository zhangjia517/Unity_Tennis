public static var wait : boolean = true;
public var levelText : GUIText;

public var choiceSound : AudioClip;
public var countSound : AudioClip;
public var failSound : AudioClip;
public var successSound : AudioClip;
public var demoSound : AudioClip;

private var sequenceArray : Array = new Array();
private var boxArray : Array = new Array();
private var level : int;
private var sequenceAttempt : int;
private var delayTime : float = .5;
private var gamePlaying : boolean = true;

var style : GUIStyle;

function Awake(){
	var childId : int;
	for (var child : Transform in transform) {
		boxArray.Push(child.gameObject);
		child.SendMessage("setId",childId);
		childId++;
	}
	countDown();
}

function OnGUI () {
	if(!gamePlaying){
		if(GUI.Button (Rect (67,178,113,32), "",style)){
			gamePlaying=true;
			countDown();
		}
	}
}

function countDown(){
	GetComponent.<AudioSource>().pitch=.8;
	GetComponent.<AudioSource>().PlayOneShot(countSound);
	levelText.material.color=Color.red;
	levelText.text="GET READY";
	yield WaitForSeconds(2);
	
	GetComponent.<AudioSource>().pitch=1;
	GetComponent.<AudioSource>().PlayOneShot(countSound);
	levelText.material.color=Color.yellow;
	levelText.text="GET SET";
	yield WaitForSeconds(2);
	
	levelText.material.color=Color.white;	
	startGame();
}

function startGame(){
	level=0;
	sequenceArray=new Array();	
	addChallenge();
}

function addChallenge(){
	level++;
	sequenceAttempt=0;
	levelText.text="LEVEL:" + (level+100).ToString().Substring(1,2);
	addSequence();
	playSequence();		
	wait=true;
}

function addSequence() {
	for(var i:int=0; i<level; i++){
		sequenceArray.Push(Random.Range(0,boxArray.length-1));
	}
}

function playSequence(){
	for(var i:int=0;i<level;i++){
		var boxId : int = sequenceArray[i];
		boxArray[boxId].SendMessage("depress");
		GetComponent.<AudioSource>().pitch=Random.Range(.7,1);
		GetComponent.<AudioSource>().PlayOneShot(demoSound);
		yield WaitForSeconds(delayTime);
	}
	wait=false;
}

function sequenceCheck(attempt:int){
	if(sequenceArray[sequenceAttempt]==attempt){
		GetComponent.<AudioSource>().pitch=Random.Range(.7,1);
		GetComponent.<AudioSource>().PlayOneShot(choiceSound);
		sequenceAttempt++;
	}else{
		gameOver();
	}
	
	if(sequenceAttempt==level){
		success();
	}
}

function success(){
	wait=true;
	yield WaitForSeconds(.4);
	GetComponent.<AudioSource>().pitch=Random.Range(.7,1);
	GetComponent.<AudioSource>().PlayOneShot(successSound);
	flash();
	yield WaitForSeconds(1.2);
	addChallenge();
}

function flash(){
	for(var i:int;i<boxArray.length;i++){
		iTween.ColorTo(boxArray[i],{"r":3,"g":3,"b":3,"time":.3});
		iTween.ColorTo(boxArray[i],{"r":.202,"g":.528,"b":.877,"delay":.5,"time":.3});
	}	
}

function gameOver(){
	GetComponent.<AudioSource>().pitch=.7;
	GetComponent.<AudioSource>().PlayOneShot(failSound);
	gamePlaying=false;
	wait=true;
	levelText.material.color=Color.red;
	levelText.text="GAME OVER";
	iTween.ShakePosition(gameObject,{"y":-.2,"time":.8});
	for(var i:int;i<boxArray.length;i++){
		iTween.ColorTo(boxArray[i],{"r":1,"time":2});
	}
	yield WaitForSeconds(2);
	flash();
}
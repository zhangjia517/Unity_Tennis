private var currentTarget : GameObject=null;
private var ball : GameObject;
public var rate : int = 10;
public var ballSet : boolean  = true;

function Start ()
{
	CreateGameBoard(9,9);
	ball = Instantiate(Resources.Load("GameBall"),Vector3(0,.5,0),Quaternion.identity);
}

function SetTarget(target:GameObject){
	if(currentTarget != null && target!=currentTarget){
		currentTarget.SendMessage("Deactivate");
	}
	currentTarget=target;
	ballSet=false;
	var travelTime : float = Vector3.Distance(ball.transform.position, target.transform.position)/rate;
	iTween.MoveBy(ball,iTween.Hash("x",target.transform.position.x-ball.transform.position.x,"easetype","easeinoutsine","time",travelTime));
	iTween.MoveBy(ball,iTween.Hash("z",target.transform.position.z-ball.transform.position.z,"time",travelTime,"delay",travelTime,"easetype","easeinoutsine","oncomplete","Reset","oncompletetarget",gameObject));
}

function Reset(){
	ballSet=true;
}
	
function CreateGameBoard(cols:uint,rows:uint){
	var block : GameObject = Resources.Load("GamePieceJS");
	
	for (var i = 0; i < cols; i++) {
		for (var j = 0; j < rows; j++) {
			var newBlock : GameObject = Instantiate(block,new Vector3(i,0,j),Quaternion.identity);
			newBlock.name="Block: " + i + "," + j;
			newBlock.SendMessage("SetGameboard",this);
			var blockColor : Color;
			if((j+i)%2 == 0){
				blockColor=Color.black;
			}else{
				blockColor=Color.white;
			}
			newBlock.GetComponent.<Renderer>().material.color=blockColor;
			newBlock.transform.parent=transform;
		}
	}
	
	transform.position=Vector3(-(cols/2),0,-(rows/2));
}
public var controlPath : Transform[];
public var character : Transform;

private var pathPosition : float=0 ;
private var hit : RaycastHit;
private var speed : float = .2;
private var rayLength : float = 5;
private var characterDirection : String;
private var floorPosition : Vector3;	
private var lookAheadAmount : float = .01;
private var ySpeed : float = 0;
private var gravity : float = .5;
private var jumpForce : float = .12;
private var jumpState : uint = 0; //0=grounded 1=jumping

function OnDrawGizmos(){
	iTween.DrawPath(controlPath,Color.blue);	
}	


function Start(){
	//plop the character pieces in the "Ignore Raycast" layer so we don't have false raycast data:	
	for (var child : Transform in character.transform) {
		child.gameObject.layer=2;
	}
	
}


function Update(){
	DetectKeys();
	FindFloorAndRotation();
	MoveCharacter();
	MoveCamera();
}


function DetectKeys(){
	//forward path movement:
	if(Input.GetKeyDown("right")){
		characterDirection="forward";	
	}
	if(Input.GetKey("right")) {
		pathPosition += Time.deltaTime * speed;
	}
	
	//reverse path movement:
	if(Input.GetKeyDown("left")){
		characterDirection="reverse";
	}
	if(Input.GetKey("left")) {
		//handle path loop around since we can't interpolate a path percentage that's negative(well duh):
		var temp : float = pathPosition - (Time.deltaTime * speed);
		if(temp<0){
			pathPosition=1;	
		}else{
			pathPosition -= (Time.deltaTime * speed);
		}
	}	
	
	//jump:
	if (Input.GetKeyDown("space") && jumpState==0) {
		ySpeed-=jumpForce;
		jumpState=1;
	}
}


function FindFloorAndRotation(){
	var pathPercent : float = pathPosition%1;
	var coordinateOnPath : Vector3 = iTween.PointOnPath(controlPath,pathPercent);
	var lookTarget : Vector3;
	
	//calculate look data if we aren't going to be looking beyond the extents of the path:
	if(pathPercent-lookAheadAmount>=0 && pathPercent+lookAheadAmount <=1){
		
		//leading or trailing point so we can have something to look at:
		if(characterDirection=="forward"){
			lookTarget = iTween.PointOnPath(controlPath,pathPercent+lookAheadAmount);
		}else{
			lookTarget = iTween.PointOnPath(controlPath,pathPercent-lookAheadAmount);
		}
		
		//look:
		character.LookAt(lookTarget);
		
		//nullify all rotations but y since we just want to look where we are going:
		var yRot : float = character.eulerAngles.y;
		character.eulerAngles=new Vector3(0,yRot,0);
	}

	if (Physics.Raycast(coordinateOnPath,-Vector3.up, hit, rayLength)){
		Debug.DrawRay(coordinateOnPath, -Vector3.up * hit.distance);
		floorPosition=hit.point;
	}
}


function MoveCharacter(){
	//add gravity:
	ySpeed += gravity * Time.deltaTime;
	
	//apply gravity:
	character.position=new Vector3(floorPosition.x,character.position.y-ySpeed,floorPosition.z);
	
	//floor checking:
	if(character.position.y<floorPosition.y){
		ySpeed=0;
		jumpState=0;
		character.position=new Vector3(floorPosition.x,floorPosition.y,floorPosition.z);
	}		
}


function MoveCamera(){
	iTween.MoveUpdate(Camera.main.gameObject,new Vector3(character.position.x,2.7,character.position.z-5),.9);	
}
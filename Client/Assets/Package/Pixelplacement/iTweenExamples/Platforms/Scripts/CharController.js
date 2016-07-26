private var grounded : boolean;
public var jumpForce : float=900;
public var moveSpeed : float=20;

function Start(){
	//setup feel:
	Physics.gravity=new Vector3(0,-60,0);
	GetComponent.<Rigidbody>().angularDrag=7;
}

function Update(){
	if(Input.GetKeyDown("right") || Input.GetKeyDown("left")){
		GetComponent.<Rigidbody>().angularVelocity=Vector3.zero;	
	}
	
	if(grounded){
		if(Input.GetKey("right")){
			GetComponent.<Rigidbody>().AddForce(new Vector3(moveSpeed*Time.deltaTime,0,0));	
		}
		if(Input.GetKey("left")){
			GetComponent.<Rigidbody>().AddForce(new Vector3(-moveSpeed*Time.deltaTime,0,0));	
		}
		if(Input.GetKeyDown("space") ){
			GetComponent.<Rigidbody>().AddForce(new Vector3(0,jumpForce,0));	
		}
	}
	
	//lock the z position for 2D:
	var tempPos :Vector3 = transform.position;
	tempPos.z=0;
	transform.position=tempPos;
}

function OnCollisionStay(collisionInfo:Collision){
	if(collisionInfo.gameObject.name == "Ground"){
		grounded=true;
	}
}

function OnCollisionEnter(collisionInfo:Collision){
	if(collisionInfo.gameObject.name == "Ground"){
		transform.parent=collisionInfo.transform;
		grounded=true;
	}
}

function OnCollisionExit(collisionInfo:Collision){
	if(collisionInfo.gameObject.name == "Ground"){
		transform.parent=null;
		grounded=false;
	}
}

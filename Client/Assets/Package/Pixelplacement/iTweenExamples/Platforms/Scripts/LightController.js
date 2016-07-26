public var target : Transform;
	
function FixedUpdate (){
	transform.position=new Vector3(target.position.x,target.position.y+2.5,target.position.z-1.6);
}
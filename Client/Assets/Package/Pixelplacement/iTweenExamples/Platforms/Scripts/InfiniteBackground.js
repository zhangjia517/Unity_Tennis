public var scrollSpeed : float;
private var cam : Transform;
private var cameraInit : Vector3;

function Start (){
	cam=Camera.main.transform;
	cameraInit=new Vector3(cam.position.x,cam.position.y,cam.position.z);
}

function FixedUpdate (){
	var difference : Vector3=cameraInit - cam.position;
	GetComponent.<Renderer>().material.mainTextureOffset = difference*scrollSpeed;
}
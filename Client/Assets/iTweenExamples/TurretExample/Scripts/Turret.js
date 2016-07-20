var bullet : Rigidbody;

function Update(){
	//rotation:
	var mousePos : Vector3 = Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.transform.position.y);
	var worldPos : Vector3 = Camera.main.ScreenToWorldPoint(mousePos);
	iTween.LookUpdate(gameObject,{"looktarget":worldPos,"time":2,"axis":"y"});
	
	//fire:
	if(Input.GetMouseButtonDown(0)){
		var clone : Rigidbody = Instantiate(bullet, Vector3(transform.position.x,1.5,transform.position.z),transform.rotation);
		clone.velocity = transform.TransformDirection (Vector3.forward * 10);
	}
}
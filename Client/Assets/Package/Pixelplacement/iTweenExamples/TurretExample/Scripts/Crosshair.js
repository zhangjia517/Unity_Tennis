function Update(){	
	var mousePos : Vector3 = Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.transform.position.y);
	var worldPos : Vector3 = Camera.main.ScreenToWorldPoint(mousePos);
	iTween.MoveUpdate(gameObject,{"position":worldPos,"time":.6});
}
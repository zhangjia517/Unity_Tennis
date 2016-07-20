var target : Transform;
var bomb : GameObject;

function Update (){
	var hit : RaycastHit = new RaycastHit();
	var cameraRay : Ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
	if (Physics.Raycast (cameraRay.origin,cameraRay.direction,hit, 100)) {
		target.position = hit.point;
	}
	
	if (Input.GetMouseButtonDown(0)) {
		var newBomb : GameObject = Instantiate(bomb);
		var newBombScript : Bomb = newBomb.GetComponent(Bomb);
		newBombScript.targetPosition = target.position;
	}
}
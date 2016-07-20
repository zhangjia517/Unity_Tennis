public var character : Transform;
public var arrow : Transform; 

function Start(){
	Cursor.visible=false;
}

function Update (){
	PlaceArrow();
	PlaceCharacter();
	if(Input.GetMouseButton(0)){
		iTween.MoveTo(gameObject,new Vector3(arrow.position.x,arrow.position.y+5,arrow.position.z),2);
	}
}

function PlaceArrow(){
	var hit : RaycastHit = new RaycastHit();
	var cameraRay : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	Debug.DrawRay (cameraRay.origin, cameraRay.direction * 100);
	if (Physics.Raycast (cameraRay.origin,cameraRay.direction,hit, 100)) {
		iTween.MoveUpdate(arrow.gameObject,hit.point,.9);
	}	
}

function PlaceCharacter(){
	var hit : RaycastHit = new RaycastHit();
	if (Physics.Raycast (transform.position,Vector3.down,hit, 10)) {
		character.position=hit.point;
	}		
}
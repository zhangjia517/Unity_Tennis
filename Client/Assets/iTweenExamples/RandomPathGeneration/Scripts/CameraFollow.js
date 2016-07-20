public var target : Transform;
private var followDistance : float = 12;
	
function Update (){
	iTween.MoveUpdate(gameObject,new Vector3(target.position.x,0,-followDistance),.8);
}

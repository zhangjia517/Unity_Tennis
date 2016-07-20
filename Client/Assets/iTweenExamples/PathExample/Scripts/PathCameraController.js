var target : Transform;

function LateUpdate () {
	iTween.LookUpdate(gameObject,target.position,2);
}
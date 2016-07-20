var path : Transform[];
var value : float;

function OnGUI () {
	value=GUI.HorizontalSlider(Rect(23,194,204,40),value,0,1);
	iTween.PutOnPath(gameObject,path,value);
	
	//You can cause the object to orient to its path by calculating a spot slightly ahead on the path for a look at target:
	transform.LookAt(iTween.PointOnPath(path,value+.05));
}

function OnDrawGizmos(){
	iTween.DrawPath(path);
}
private var pointCount : int = 6;
private var pathLength : float = 20;
private var pointDeviation : float = 3;
private var path : Vector3[];
private var rootPosition : Vector3;

function Start(){
	GenerateRandomPath();
	iTween.MoveTo(gameObject,iTween.Hash("path",path,"time",3,"easetype",iTween.EaseType.easeInOutCubic,"looptype",iTween.LoopType.pingPong));		
}

function OnDrawGizmos(){
	if(path){
		iTween.DrawPath(path);	
	}
}

function GenerateRandomPath(){
	rootPosition = transform.position;
	path = new Vector3[pointCount+2];
	var pointGap : float = pathLength/pointCount;
	path[0]=rootPosition;
	path[pointCount+1]=new Vector3(rootPosition.x+(pathLength+pointGap),rootPosition.y,rootPosition.z);
	for (var i : int = 1; i < pointCount+1; i++) {
		var randomZ : float = rootPosition.z + Random.Range(-pointDeviation,pointDeviation);
		var randomY : float = rootPosition.y + Random.Range(-pointDeviation,pointDeviation);
		var newX : float = rootPosition.x + (pointGap*i);
		path[i]=new Vector3(newX,randomY,randomZ);
	}
}
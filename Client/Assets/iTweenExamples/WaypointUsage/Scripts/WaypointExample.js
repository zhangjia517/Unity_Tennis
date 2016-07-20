public var waypoints : Transform[];
public var rate : int = 20;
private var currentWaypoint :int = 0;

function Start(){
	MoveToWaypoint();	
}

function OnDrawGizmos(){
	iTween.DrawLine(waypoints,Color.yellow);
}

function MoveToWaypoint(){			
	//Time = Distance / Rate:
	var travelTime : float = Vector3.Distance(transform.position, waypoints[currentWaypoint].position)/rate;
	
	//iTween:
	iTween.MoveTo(gameObject,iTween.Hash("position",waypoints[currentWaypoint],"time",travelTime,"easetype","linear","oncomplete","MoveToWaypoint","Looktarget",waypoints[currentWaypoint].position,"looktime",.4));
	
	//Move to next waypoint:
	currentWaypoint++;
	if(currentWaypoint>waypoints.Length-2){
		currentWaypoint=0;
	}
}








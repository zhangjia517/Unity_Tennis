using UnityEngine;
using System.Collections;

public class WaypointExample : MonoBehaviour {
	public Transform[] waypoints;
	public int rate = 20;
	private int currentWaypoint = 0;
	
	void Start(){
		MoveToWaypoint();	
	}
	
	void OnDrawGizmos(){
		iTween.DrawLine(waypoints,Color.yellow);
	}
	
	void MoveToWaypoint(){			
		//Time = Distance / Rate:
		float travelTime = Vector3.Distance(transform.position, waypoints[currentWaypoint].position)/rate;
		
		//iTween:
		iTween.MoveTo(gameObject,iTween.Hash("position",waypoints[currentWaypoint],"time",travelTime,"easetype","linear","oncomplete","MoveToWaypoint","Looktarget",waypoints[currentWaypoint].position,"looktime",.4));
		
		//Move to next waypoint:
		currentWaypoint++;
		if(currentWaypoint>waypoints.Length-2){
			currentWaypoint=0;
		}
	}
	
}








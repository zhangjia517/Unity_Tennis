using UnityEngine;
using System.Collections;

public class PathGenerator : MonoBehaviour{
	int pointCount = 6;
	float pathLength = 20;
	float pointDeviation =3f;
	Vector3[] path = null;
	Vector3 rootPosition;
	
	void Start(){
		GenerateRandomPath();
		iTween.MoveTo(gameObject,iTween.Hash("path",path,"time",3,"easetype",iTween.EaseType.easeInOutCubic,"looptype",iTween.LoopType.pingPong));		
	}
	
	void OnDrawGizmos(){
		if (path != null) {
			if(path.Length>0){
				iTween.DrawPath(path);	
			}	
		}	
	}
	
	void GenerateRandomPath(){
		rootPosition = transform.position;
		path = new Vector3[pointCount+2];
		float pointGap = pathLength/pointCount;
		path[0]=rootPosition;
		path[pointCount+1]=new Vector3(rootPosition.x+(pathLength+pointGap),rootPosition.y,rootPosition.z);
		for (int i = 1; i < pointCount+1; i++) {
			float randomZ = rootPosition.z + Random.Range(-pointDeviation,pointDeviation);
			float randomY = rootPosition.y + Random.Range(-pointDeviation,pointDeviation);
			float newX = rootPosition.x + (pointGap*i);
			path[i]=new Vector3(newX,randomY,randomZ);
		}
	}
}


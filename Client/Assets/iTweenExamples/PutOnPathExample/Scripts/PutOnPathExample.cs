using UnityEngine;
using System.Collections;

public class PutOnPathExample : MonoBehaviour{
	public Transform[] path;
	public float percentage;
	
	void OnGUI () {
		percentage=GUI.HorizontalSlider(new Rect(23,194,204,40),percentage,0,1);
		iTween.PutOnPath(gameObject,path,percentage);
		
		//You can cause the object to orient to its path by calculating a spot slightly ahead on the path for a look at target:
		transform.LookAt(iTween.PointOnPath(path,percentage+.05f));
	}
	
	void OnDrawGizmos(){
		iTween.DrawPath(path);
	}
}


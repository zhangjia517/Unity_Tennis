using UnityEngine;
using System.Collections;

public class AmbientMovement : MonoBehaviour{
	public float delay = 0f;
	
	void Start () {
	    iTween.MoveBy(gameObject,iTween.Hash("delay",delay,"y",1,"looptype","pingpong","easetype","easeInOutExpo","time",.6));
	}
}


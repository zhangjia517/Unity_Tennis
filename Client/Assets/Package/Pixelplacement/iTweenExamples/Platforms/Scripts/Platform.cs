using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
	void Start (){
		iTween.MoveAdd(gameObject,iTween.Hash("y",transform.position.y+3,"time",2,"looptype",iTween.LoopType.pingPong,"easetype",iTween.EaseType.linear,"delay",Random.Range(0,.4f)));
	}
}

public var path : Transform[];

function OnDrawGizmos(){
	iTween.DrawPath(path);	
}

function Start(){
	iTween.MoveTo(gameObject,iTween.Hash("path",path,"time",1,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.loop,"movetopath",false));
}
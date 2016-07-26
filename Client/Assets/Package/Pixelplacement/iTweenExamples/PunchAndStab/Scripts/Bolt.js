var ticker1:GameObject;
var ticker2:GameObject;
var ticker3:GameObject;
var slide:AudioClip;
var impact:AudioClip;
private var left:float = -128.4426;
private var right:float = 78.1041;

function Start(){
	Move("right");
}

function Move(direction:String){
	if(direction == "right"){
		iTween.ValueTo(gameObject,iTween.Hash("from",left,"to",right,"easetype",iTween.EaseType.easeInExpo,"time",1.4,"delay",.5,"onupdate","ApplySlide","oncomplete","ApplySlam","oncompleteparams","right"));
		iTween.Stab(gameObject,slide,1.1);
		iTween.Stab(gameObject,impact,1.85);
	}else{
		iTween.ValueTo(gameObject,iTween.Hash("from",right,"to",left,"easetype",iTween.EaseType.easeInExpo,"time",1.4,"delay",.5,"onupdate","ApplySlide","oncomplete","ApplySlam","oncompleteparams","left"));
		iTween.Stab(gameObject,slide,1.1);
		iTween.Stab(gameObject,impact,1.85);
	}
}

function ApplySlide(xpos:float){
	var newPixelInset:Rect = GetComponent.<GUITexture>().pixelInset;
	newPixelInset.x = xpos;
	GetComponent.<GUITexture>().pixelInset=newPixelInset;
}

function ApplySlam(direction:String){
	if(direction == "left"){
		Move("right");
		ticker1.SendMessage("Slam",45);
		ticker2.SendMessage("Slam",35);
		ticker3.SendMessage("Slam",25);
		iTween.ShakePosition(Camera.main.gameObject,new Vector3(.4,0,0),.4);
	}else{
		Move("left");
		ticker1.SendMessage("Slam",-25);
		ticker2.SendMessage("Slam",-35);
		ticker3.SendMessage("Slam",-45);
		iTween.ShakePosition(Camera.main.gameObject,new Vector3(-.4,0,0),.4);
	}
}
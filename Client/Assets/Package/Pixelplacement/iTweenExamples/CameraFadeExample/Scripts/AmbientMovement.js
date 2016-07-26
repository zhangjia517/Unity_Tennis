var delay : float = 0;

function Start () {
    iTween.MoveBy(gameObject,{"delay":delay,"y":1,"looptype":"pingpong","easetype":"easeInOutExpo","time":.6});
}
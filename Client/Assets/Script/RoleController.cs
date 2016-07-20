using System.Collections;
using UnityEngine;

public enum MOVE_STATE
{
    MoveUp,
    MoveBack,
    MoveLeft,
    MoveRight,
    Idle,
}

public enum PLAYER_STATE
{
    Move,
    Hit,
}

public enum PLAYER_HIT
{
    zhengshou,
    fanshou,
}

public class RoleController : MonoBehaviour
{
    public int moveSpeed = 3;
    public static RoleController thisScript;
    public GameObject m_Target = null;

    private Animation anim = null;
    private int inputCount = 0;

    private void Awake()
    {
        thisScript = this;
    }

    private void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    private void Update()
    {
        gameObject.transform.LookAt(m_Target.transform);
    }

    internal void HitBall(PLAYER_HIT hitState)
    {
        if (inputCount != 0) return;
        inputCount++;

        switch (hitState)
        {
            case PLAYER_HIT.zhengshou:
                anim.CrossFade("zhengshou");
                ChangeToMoveState(anim["zhengshou"].clip.length);
                break;

            case PLAYER_HIT.fanshou:
                anim.CrossFade("fanshou");
                ChangeToMoveState(anim["fanshou"].clip.length);

                break;

            default:
                break;
        }
        GameController.thisScript.m_Ball.SetRolePos();
    }

    private void ChangeToMoveState(float time)
    {
        StartCoroutine(WaitAndChangeToMoveState(time));
    }

    private IEnumerator WaitAndChangeToMoveState(float waitTime)
    {
        yield return new WaitForSeconds(waitTime / 3f);
        GameController.thisScript.m_Ball.Move();
        yield return new WaitForSeconds(waitTime);
        inputCount = 0;
        anim.CrossFade("daiji");
    }
}
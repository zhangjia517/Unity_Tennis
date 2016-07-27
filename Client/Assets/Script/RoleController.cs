using System.Collections;
using UnityEngine;

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
    public static RoleController thisScript;
    public Animator m_Animator = null;
    public GameObject m_Target = null;
    public PLAYER_STATE m_curPlayerState = PLAYER_STATE.Move;

    public int m_inputCount = 0;

    private void Awake()
    {
        thisScript = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
        gameObject.transform.LookAt(m_Target.transform);
    }

    internal void HitBall(PLAYER_HIT hitState)
    {
        if (m_inputCount != 0) return;
        m_inputCount++;

        switch (hitState)
        {
            case PLAYER_HIT.zhengshou:
                m_Animator.Play("zhengshou");
                break;

            case PLAYER_HIT.fanshou:
                m_Animator.Play("fanshou");
                break;

            default:
                break;
        }
    }

    public void ChangeToMoveState(float time)
    {
        StartCoroutine(WaitAndChangeToMoveState(time));
    }

    private IEnumerator WaitAndChangeToMoveState(float waitTime)
    {
        yield return new WaitForSeconds(waitTime / 3f);
        GameController.thisScript.m_Ball.SetPath(0);
        GameController.thisScript.m_Ball.Move();
    }
}
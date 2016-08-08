using UnityEngine;

public class ZhengshouBehaviour : StateMachineBehaviour
{
    private RoleController m_RoleController;
    private int leftCount = 0, rightCount = 0, frontCount = 0, backCount = 0;

    private bool m_isHit = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_RoleController = RoleController.thisScript;

        m_RoleController.m_curPlayerState = PLAYER_STATE.Hit;
        m_isHit = false;
        leftCount = 0; rightCount = 0; frontCount = 0; backCount = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime < 0.3f)
        {
            CalDroppoint();
        }

            if (stateInfo.normalizedTime > 0.25f && stateInfo.normalizedTime < 0.3f)
        {
            if (Input.GetKey(KeyCode.S))
            {
                animator.speed = 0.1f;
            }
            else
            {
                animator.speed = 1f;
            }
        }
        if (stateInfo.normalizedTime > 0.3f)
        {
            animator.speed = 1f;
        }

        if (!m_isHit)
        {
            if (stateInfo.normalizedTime > 0.35f)
            {
                Debug.Log("leftCount" + leftCount + " " +
                          "rightCount" + rightCount + " " +
                          "frontCount" + frontCount + " " +
                          "backCount" + backCount + " ");

                float rightOffset = (rightCount - leftCount) / 30f;
                
                GameController.thisScript.m_Ball.SetPath(rightOffset);
                GameController.thisScript.m_Ball.Move();
                m_isHit = true;
            }
        }
    }

    private void CalDroppoint()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftCount++;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightCount++;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            frontCount++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            backCount++;
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RoleController.thisScript.m_inputCount = 0;
        m_RoleController.m_curPlayerState = PLAYER_STATE.Move;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
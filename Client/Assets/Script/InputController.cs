using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            RoleController.thisScript.HitBall(PLAYER_HIT.zhengshou);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RoleController.thisScript.HitBall(PLAYER_HIT.fanshou);
        }
    }
}
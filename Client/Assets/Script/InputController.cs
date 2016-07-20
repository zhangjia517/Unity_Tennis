using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NowPlayedCharacter
{
    public static Temp_Character nowCharacter;
    public static CharacterInfo info;
    public static CharacterController controller;
    static float characterSpeed;
    static float jumpSpeed = 10f;
    static float characterDetectRange;
    static float characterAttackRange;
    static float characterModifyRange;

    static float gravity = 20.0F;

    static Vector3 moveDir;

    public static void SetNowCharacter(Temp_Character _character)
    {
        nowCharacter = _character;
        info = _character.info;
        controller = _character.GetComponent<CharacterController>();
    }

    public static void MoveCharacter()
    {
        if(controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = nowCharacter.transform.TransformDirection(moveDir) * characterSpeed * Time.deltaTime;
            if(Input.GetButton("Jump")){
                moveDir.y = jumpSpeed;
            }
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir);
        }
        
        
    }
}

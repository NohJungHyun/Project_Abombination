using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovements : MonoBehaviour
{
    public float basicSpeed = 20f;

    Temp_Character character;
    Rigidbody rb;

    NavMeshAgent navMeshAgent;
    Vector3 moveDirection = Vector3.zero;

    public float moveDelay;

    private void Start()
    {
        character = GetComponent<Temp_Character>();
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Moving()
    {
        if(moveDelay >= 0) return;

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        // moveDirection = transform.TransformDirection(moveDirection);
        rb.velocity = moveDirection * character.GetCharacterInfo().characterMovement * basicSpeed * Time.fixedDeltaTime;
    }

    public void MovingWithNavMesh()
    {
        if(moveDelay >= 0) return;

        Debug.Log("Moving");
        Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * character.GetCharacterInfo().characterMovement; //* Time.deltaTime
        navMeshAgent.destination = transform.position + movePos;
    }

}

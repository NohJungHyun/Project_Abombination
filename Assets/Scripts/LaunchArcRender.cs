using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArcRender : MonoBehaviour
{

    public Rigidbody ball;
    public Transform targetTransform;

    public float h = 20;
    public float gravity = Physics.gravity.y;
    public bool debugPath;

    void Start()
    {
        ball.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        if (debugPath)
        {
            DrawPath();
        }
    }

    void Launch()
    {
        Physics.gravity = Vector3.up * gravity;
        ball.useGravity = true;
        ball.velocity = CalculateLaunchVelocity().initialVelocity;
    }

    LaunchData CalculateLaunchVelocity()
    {
        float displacementY = targetTransform.position.y - ball.position.y;
        Vector3 displacementXZ = new Vector3(targetTransform.position.x - ball.position.x, 0, targetTransform.position.z - ball.position.z);

        float time = (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / time;

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
    }

    void DrawPath()
    {
        LaunchData launchData = CalculateLaunchVelocity();
        Vector3 previousDrawPoint = ball.position;

        int resolution = 30;
        for (int i = 1; i < resolution + 1; i++)
        {
            float simulationTime = i / (float)resolution * launchData.timeToTarget;
            Vector3 displacement = (launchData.initialVelocity * simulationTime) + (Vector3.up * gravity * simulationTime * simulationTime / 2f);
            Vector3 drawPoint = ball.position + displacement;

            Debug.DrawLine(previousDrawPoint, drawPoint, Color.red, 1f);
            previousDrawPoint = drawPoint;
        }
    }

    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 _initialVelocity, float _timeToTarget)
        {
            this.initialVelocity = _initialVelocity;
            this.timeToTarget = _timeToTarget;
        }
    }
}

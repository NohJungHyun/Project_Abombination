using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class MoveBorderCircle : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public List<Vector3> lineRendererPos;
    public float radius;
    public int segment;
    public float angle;
    public Transform basePos;
    public float decreaseNum;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRendererPos = new List<Vector3>();

        lineRenderer.positionCount = segment + 2;
        // basePos = null;

        StartCoroutine(SetCircleScale());
        lineRenderer.useWorldSpace = false;
        transform.position = new Vector3(0, 1f, -17.5f);

    }

    // Update is called once per frame
    void Update()
    {
        decreaseNum += Time.deltaTime;
    }

    IEnumerator SetCircleScale()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < segment + 2; i++)
            {
                print("ㅂㅂㅂㅂ");
                float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
                float z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

                lineRenderer.SetPosition(i, new Vector3(x * 0.9f, basePos.transform.position.y, z * 0.9f));

                angle += (360f / segment);

                // if(angle < 360)
                //     angle += (360f / segment);
                // else
                //     angle = 0;
            }
        }

    }
}

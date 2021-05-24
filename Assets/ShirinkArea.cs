using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirinkArea : MonoBehaviour
{
    public Vector3[] verticies;
    public int[] triangles;

    public Mesh mesh;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public float angle;
    public int segment;

    public float minRadius;
    public float maxRadius;
    public float curRadius;
    public Material surfaceMaterial;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        meshRenderer = GetComponent<MeshRenderer>();

        verticies = new Vector3[segment + 2];
        triangles = new int[segment * 3];

        StartCoroutine("CreateArea");

        curRadius = maxRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if(curRadius > minRadius)
            curRadius -= Time.deltaTime * 0.25f;
    }

    IEnumerator CreateArea()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            // int stepCount = Mathf.RoundToInt(angle) * segment;
            // float stepAngleSize = angle / stepCount;

            float width = (Mathf.PI * 2) / segment;

            for (int i = 0; i < verticies.Length; i++)
            {
                // float x = curRadius * Mathf.Sin((angle));
                // float z = curRadius * Mathf.Cos((angle));

                verticies[i] = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * curRadius;

                angle -= width;
                // angle += angle;
            }

            verticies[0] = Vector3.zero;
            for (int i = 0; i < verticies.Length; i++)
            {
                // verticies[i + 1] = transform.InverseTransformPoint(verticies[i]);

                if (i < verticies.Length - 2)
                {
                    triangles[i * 3] = 0;
                    triangles[i * 3 + 1] = i + 1;
                    triangles[i * 3 + 2] = i + 2;
                }
            }

            mesh.Clear();
            mesh.vertices = verticies;
            mesh.triangles = triangles;
            meshRenderer.material = surfaceMaterial;
            // meshRenderer.sharedMaterial = viewMaterial;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

        }

    }
}

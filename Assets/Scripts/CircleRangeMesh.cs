using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CircleRangeMesh : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    Mesh mesh;

    public int resolution = 60;
    public float radius = 5f;

    [Range(0,360)]
    public float viewAngle;
    public float edgeDstThreshold;

    public LayerMask targetMask;
    public LayerMask obstaclemask;
    public Texture tex;


    [SerializeField]
    Vector3[] vertices;

    [SerializeField]
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter.mesh = mesh;

        CreateCircleMesh();
    }

    public void CreateCircleMesh()
    {
        mesh.Clear();
        vertices = new Vector3[resolution + 2];
        triangles = new int[resolution * 3];
        
        Vector3 basePos = Vector3.zero;

        vertices[0] = basePos;
        float segmentAngle = Mathf.PI * 2f / resolution;
        float angle = 0;

        for(int i = 1; i < vertices.Length; i++)
        {            
            vertices[i] = new Vector3(Mathf.Cos(angle), 0f , Mathf.Sin(angle)) * radius + basePos;
            if(!Physics.Raycast(basePos, vertices[i] - basePos, radius, obstaclemask)){
                
            }

            angle -= segmentAngle;

            if (i < vertices.Length - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
			}
        }
        UpdateMesh();
    }

    public void UpdateMesh()
    {
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        if(tex)
            meshRenderer.material.SetTexture("???", tex);
        
    }
}

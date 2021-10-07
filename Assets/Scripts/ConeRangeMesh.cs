using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeRangeMesh : MonoBehaviour
{
    public float viewRadius;
	[Range(0,360)]
	public float viewAngle;
	public int meshResolution;
	public int edgeResolveIterations;
	public float edgeDstThreshold;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	// [HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();
	public MeshFilter viewMeshFilter;
	public MeshRenderer viewMeshRenderer;

	public Material viewMaterial;
	Mesh viewMesh;

    public void CreateMesh()
    {
        // viewMeshFilter = GetComponentInChildren<MeshFilter>();
        // viewMeshRenderer = GetComponentInChildren<MeshRenderer>();

        viewMeshFilter = GetComponent<MeshFilter>();
        viewMeshRenderer = GetComponent<MeshRenderer>();

        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;

        StartCoroutine("FindTargetsWithDelay", 1f);
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
			FindVisibleTargets();
        }
    }

	void Update()
	{
		if(viewMesh != null)
		{
			DrawFieldOfView();
		}
			
	}

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.gameObject.transform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.gameObject.transform.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                    visibleTargets.Add(target);
            }
        }
    }

	void DrawFieldOfView()
	{
		int stepCount = Mathf.RoundToInt(viewAngle) * meshResolution;
		float stepAngleSize = viewAngle / stepCount;
		// float stepAngleSize = 1 / meshResolution;
		List<Vector3> viewPoints = new List<Vector3>();

		ViewCastInfo oldViewCast = new ViewCastInfo();

		for(int i = 0; i <= stepCount; i++){
			float angle = transform.eulerAngles.y - viewAngle/2 + stepAngleSize * i;
			ViewCastInfo newViewCast = ViewCast(angle);
			bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;

			if(i > 0){
				if(oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
				{
					EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
					if(edge.pointA != Vector3.zero){
						viewPoints.Add(edge.pointA);
					}
					if(edge.pointB != Vector3.zero){
						viewPoints.Add(edge.pointB);
					}
				}
			}

			viewPoints.Add(newViewCast.point);
			oldViewCast = newViewCast;
		}

		int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
			}
        }

		viewMesh.Clear();
		viewMesh.vertices = vertices;
		viewMesh.triangles = triangles;
		viewMeshRenderer.material = viewMaterial;
		viewMeshRenderer.sharedMaterial = viewMaterial;
		viewMesh.RecalculateNormals();
		viewMesh.RecalculateBounds();
	}

	EdgeInfo FindEdge(ViewCastInfo _minViewCast, ViewCastInfo _maxViewCast){
		float minAngle = _minViewCast.angle;
		float maxAngle = _maxViewCast.angle;

		Vector3 minPoint = Vector3.zero;
		Vector3 maxPoint = Vector3.zero;

		bool edgeDstThresholdExceeded = Mathf.Abs(_minViewCast.dst - _maxViewCast.dst) > edgeDstThreshold;
			
		for(int i = 0; i < edgeResolveIterations; i++){
			float angle = (minAngle + maxAngle) * 0.5f;
			ViewCastInfo newViewCast = ViewCast(angle);

			if(newViewCast.hit == _minViewCast.hit && !edgeDstThresholdExceeded){
				minAngle = angle;
				minPoint = newViewCast.point;
			}else{
				maxAngle = angle;
				maxPoint = newViewCast.point;
			}
		}
		return new EdgeInfo(minPoint, maxPoint);
	}

	ViewCastInfo ViewCast(float globalAngle){
		Vector3 dir = DirFromAngle(globalAngle, true);
		RaycastHit hit;
		if(Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask)){
			return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
		}else{
			return new ViewCastInfo(true, transform.position + dir * viewRadius, viewRadius, globalAngle);
		}
	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

	public struct ViewCastInfo{
		public bool hit;
		public Vector3 point;
		public float dst;
		public float angle;

		public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle){
			hit = _hit;
			point = _point;
			dst = _dst;
			angle = _angle;
		}
	}

	public struct EdgeInfo{
		public Vector3 pointA;
		public Vector3 pointB;

		public EdgeInfo(Vector3 _pointA, Vector3 _pointB){
			pointA = _pointA;
			pointB = _pointB;
		}
	}

	public List<Transform> GetVisibleTargets(){
		return visibleTargets;
	}

	public void SetProperties(float _viewRadius, int _Detectangle)
	{
		viewRadius = _viewRadius;
		viewAngle = _Detectangle;
	}

	public void SetRadius(float r)
	{
		viewRadius = r;
	}
}

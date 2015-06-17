using UnityEngine;
using System.Collections;

public class ProcOctahedron : ProcBase
{

	public float m_Radius = 1.0f;
	private static readonly Vector3[] m_verts = 
		{
			new Vector3 (1, 0, 0),//0
			new Vector3 (0, 0, -1),//1
			new Vector3 (-1, 0, 0),//2
			new Vector3 (0, 0, 1),//3
			new Vector3 (0, 1, 0),//4
			new Vector3 (0, -1, 0)//5

		};

	private static readonly Vector3[] m_OctahedronVerts = 
	{
		m_verts [0], m_verts [1], m_verts [4],
		m_verts [1], m_verts [2], m_verts [4],
		m_verts [2], m_verts [3], m_verts [4],
		m_verts [3], m_verts [0], m_verts [4],
		m_verts [0], m_verts [5], m_verts [1],
		m_verts [1], m_verts [5], m_verts [2],
		m_verts [2], m_verts [5], m_verts [3],
		m_verts [3], m_verts [5], m_verts [0]
	};


	public override Mesh BuildMesh ()
	{

		MeshBuilder meshBuilder = new MeshBuilder ();

		for (int index = 0; index < m_OctahedronVerts.Length; index++) {
			meshBuilder.Vertices.Add (m_OctahedronVerts [index] * m_Radius); //0
		}

		for (int index = 0; index < m_OctahedronVerts.Length; index+=3) {
			meshBuilder.AddTriangle (index, index+1,index + 2);
		}


		return meshBuilder.CreateMesh ();
	}
}

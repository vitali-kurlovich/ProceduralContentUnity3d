using UnityEngine;
using System.Collections;

public class ProcCube : ProcBase {

	public float m_Radius = 1.0f;
	public float m_SecondRadius = 0.5f;
	
	private static readonly Vector3[] m_verts = 
	{
		new Vector3 (-1, 1, -1)*2,//0
		new Vector3 (-1, -1, -1),//1
		
		new Vector3 (1, 1, -1),//2
		new Vector3 (1, -1, -1)*2,//3
		
		
		new Vector3 (1, 1, 1)*2,//4
		new Vector3 (1, -1, 1),//5
		
		new Vector3 (-1, 1, 1),//6
		new Vector3 (-1, -1, 1)*2//7
		
	};
	
	private static readonly Vector3[] m_DodecahedronVerts = 
	{
		m_verts [1], m_verts [0], m_verts [2],
		m_verts [2], m_verts [3], m_verts [1],
		
		m_verts [3], m_verts [2], m_verts [5],
		m_verts [5], m_verts [2], m_verts [4],
		
		m_verts [5], m_verts [4], m_verts [6],
		m_verts [6], m_verts [7], m_verts [5],
		
		
		m_verts [6], m_verts [0], m_verts [1],
		m_verts [1], m_verts [7], m_verts [6],
		
		m_verts [6], m_verts [4], m_verts [2],
		m_verts [2], m_verts [0], m_verts [6],
		
		
		m_verts [1], m_verts [3], m_verts [5],
		m_verts [5], m_verts [7], m_verts [1],
		
	};
	
	public override Mesh BuildMesh ()
	{
		
		MeshBuilder meshBuilder = new MeshBuilder ();
		
		for (int index = 0; index < m_DodecahedronVerts.Length; index++) {
			meshBuilder.Vertices.Add (m_DodecahedronVerts [index] * m_Radius); //0
		}
		
		for (int index = 0; index < m_DodecahedronVerts.Length; index+=3) {
			meshBuilder.AddTriangle (index, index+1,index + 2);
		}
		
		return meshBuilder.CreateMesh ();
	}
}

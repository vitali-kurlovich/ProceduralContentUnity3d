using UnityEngine;
using System.Collections;

public class ProcTetrahedron : ProcBase {

	public float m_Radius = 1.0f;

	private readonly Vector3[] tetrahedronVerts =  
	{
		new Vector3(ProcConst.Cos_30, -ProcConst.Cos_60, -ProcConst.Sin_30 ),
		new Vector3(-ProcConst.Cos_30, -ProcConst.Cos_60, -ProcConst.Sin_30),
		new Vector3(0.0f, -ProcConst.Cos_60, 1.0f),

		new Vector3(0.0f, 1.0f, 0.0f)
	}; 


	
	public override Mesh BuildMesh()
	{

		//Create a new mesh builder:
		MeshBuilder meshBuilder = new MeshBuilder ();
	
		// triangle 1
		meshBuilder.Vertices.Add(tetrahedronVerts[0]*m_Radius); //0
		meshBuilder.Vertices.Add(tetrahedronVerts[1]*m_Radius); //1
		meshBuilder.Vertices.Add(tetrahedronVerts[2]*m_Radius);//2

		meshBuilder.AddTriangle (0, 2, 1);

		// triangle 2
		meshBuilder.Vertices.Add(tetrahedronVerts[0]*m_Radius);//3
		meshBuilder.Vertices.Add(tetrahedronVerts[1]*m_Radius);//4
		meshBuilder.Vertices.Add(tetrahedronVerts[3]*m_Radius);//5

		meshBuilder.AddTriangle (3, 4, 5);

		// triangle 3
		meshBuilder.Vertices.Add(tetrahedronVerts[1]*m_Radius);//6
		meshBuilder.Vertices.Add(tetrahedronVerts[2]*m_Radius);//7
		meshBuilder.Vertices.Add(tetrahedronVerts[3]*m_Radius);//8

		meshBuilder.AddTriangle (6, 7, 8);

		// triangle 4
		meshBuilder.Vertices.Add(tetrahedronVerts[2]*m_Radius);//9
		meshBuilder.Vertices.Add(tetrahedronVerts[0]*m_Radius);//10
		meshBuilder.Vertices.Add(tetrahedronVerts[3]*m_Radius);//11

		meshBuilder.AddTriangle (9, 10, 11);


		return meshBuilder.CreateMesh ();
	}
}

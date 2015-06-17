using UnityEngine;
using System.Collections;

public class ProcDiamond : ProcBase {

	public float m_Radius = 1.0f;

	public override Mesh BuildMesh()
	{
		//Create a new mesh builder:
		MeshBuilder meshBuilder = new MeshBuilder ();

		meshBuilder.Vertices.Add(new Vector3(0.0f, 0.0f, 0.0f));
		meshBuilder.UVs.Add(new Vector2(0.0f, 0.0f));
		meshBuilder.Normals.Add(Vector3.up);

		return meshBuilder.CreateMesh ();
	}
}

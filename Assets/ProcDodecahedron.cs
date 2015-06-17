using UnityEngine;
using System.Collections;

public class ProcDodecahedron : ProcBase {

	public float m_Radius = 1.0f;
	public float m_SecondRadius = 0.5f;

	private static readonly Vector3[] m_verts = 
	{
		new Vector3 (-1, 1, -1),//0
		new Vector3 (-1, -1, -1),//1

		new Vector3 (1, 1, -1),//2
		new Vector3 (1, -1, -1),//3


		new Vector3 (1, 1, 1),//4
		new Vector3 (1, -1, 1),//5

		new Vector3 (-1, 1, 1),//6
		new Vector3 (-1, -1, 1),//7

		new Vector3 (0, 1, -1),//8
		new Vector3 (0, -1, -1),//9

		new Vector3 (-1, 0, -1),//10
		new Vector3 (1, 0, -1),//11

		new Vector3 (1, 0, 1),//12
		new Vector3 (1, -1, 0),//13

		new Vector3 (1, 1, 0),//14

		new Vector3 (0, -1, 1),//15
		new Vector3 (0, 1, 1),//16

		new Vector3 (-1, 0, 1),//17

		new Vector3 (-1, 1, 0),//18
		new Vector3 (-1, -1, 0),//19

	};

	private static readonly Vector3[] m_DodecahedronVerts = 
	{
		m_verts [0], m_verts [8], m_verts [10],
		m_verts [10], m_verts [8], m_verts [9],
		m_verts [10], m_verts [9], m_verts [1],

		m_verts [2], m_verts [11], m_verts [8],
		m_verts [8], m_verts [11], m_verts [9],
		m_verts [9], m_verts [11], m_verts [3],


		m_verts [3], m_verts [11], m_verts [13],
		m_verts [13], m_verts [11], m_verts [12],
		m_verts [12], m_verts [5], m_verts [13],


		m_verts [2], m_verts [14], m_verts [11],
		m_verts [11], m_verts [14], m_verts [12],
		m_verts [12], m_verts [14], m_verts [4],

		m_verts [12], m_verts [4], m_verts [16],
		m_verts [16], m_verts [15], m_verts [12],
		m_verts [12], m_verts [15], m_verts [5],


		m_verts [6], m_verts [17], m_verts [16],
		m_verts [16], m_verts [17], m_verts [15],
		m_verts [15], m_verts [17], m_verts [7],

		m_verts [7], m_verts [17], m_verts [19],
		m_verts [19], m_verts [17], m_verts [10],
		m_verts [10], m_verts [1], m_verts [19],


		m_verts [6], m_verts [18], m_verts [17],
		m_verts [17], m_verts [18], m_verts [10],
		m_verts [10], m_verts [18], m_verts [0],


		m_verts [16], m_verts [4], m_verts [14],
		m_verts [14], m_verts [18], m_verts [16],
		m_verts [16], m_verts [18], m_verts [6],


		m_verts [2], m_verts [8], m_verts [14],
		m_verts [14], m_verts [8], m_verts [18],
		m_verts [18], m_verts [8], m_verts [0],


		m_verts [15], m_verts [7], m_verts [19],
		m_verts [19], m_verts [13], m_verts [15],
		m_verts [15], m_verts [13], m_verts [5],

		m_verts [1], m_verts [9], m_verts [19],
		m_verts [19], m_verts [9], m_verts [13],
		m_verts [13], m_verts [9], m_verts [3],

		/*

		m_verts [6], m_verts [0], m_verts [1],
		m_verts [1], m_verts [7], m_verts [6],

		m_verts [6], m_verts [4], m_verts [2],
		m_verts [2], m_verts [0], m_verts [6],


		m_verts [1], m_verts [3], m_verts [5],
		m_verts [5], m_verts [7], m_verts [1],
*/
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

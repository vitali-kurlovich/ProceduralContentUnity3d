using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ProcTetrahedron))]
public class ProcTetrahedronEditro : ProcBaseEditor {
	
	[MenuItem ("GameObject/Create Other/Tetrahedron")]
	static void Create(){
		GameObject gameObject = new GameObject("ProcTetrahedron");
		//gameObject.AddComponent<MeshFilter>();
		//gameObject.AddComponent<MeshRenderer>();
		ProcBase s = gameObject.AddComponent<ProcTetrahedron>();
		//MeshFilter meshFilter = gameObject.GetComponent();
		s.generateMesh();

	}


	#region Inspector GUI
	public override void OnInspectorGUI()
	{
		//Debug.Log("OnInspectorGUI");
		
		ProcTetrahedron proc = (ProcTetrahedron)target;
		
		proc.m_Radius = EditorGUILayout.Slider(proc.m_Radius, 0.1f, 12);

		this.UpdateProcGeometry ();
	}
	
	#endregion
}

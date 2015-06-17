using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ProcDodecahedron))]
public class ProcDodecahedronEditor : ProcBaseEditor {

	[MenuItem ("GameObject/Create Other/Dodecahedron")]
	static void Create(){
		GameObject gameObject = new GameObject("ProcDodecahedron");
		//gameObject.AddComponent<MeshFilter>();
		//gameObject.AddComponent<MeshRenderer>();
		ProcBase s = gameObject.AddComponent<ProcDodecahedron>();
		//MeshFilter meshFilter = gameObject.GetComponent();
		s.generateMesh();
		
	}

	#region Inspector GUI
	public override void OnInspectorGUI()
	{
		//Debug.Log("OnInspectorGUI");
		
		ProcDodecahedron proc = (ProcDodecahedron)target;
		
		proc.m_Radius = EditorGUILayout.Slider(proc.m_Radius, 0.1f, 12);
		
		this.UpdateProcGeometry ();
	}
	
	#endregion
}

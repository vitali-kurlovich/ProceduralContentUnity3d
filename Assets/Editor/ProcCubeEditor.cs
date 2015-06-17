using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ProcCube))]
public class ProcCubeEditor : ProcBaseEditor {

	[MenuItem ("GameObject/Create Other/Cube")]
	static void Create(){
		GameObject gameObject = new GameObject("ProcCube");
		//gameObject.AddComponent<MeshFilter>();
		//gameObject.AddComponent<MeshRenderer>();
		ProcBase s = gameObject.AddComponent<ProcCube>();
		//MeshFilter meshFilter = gameObject.GetComponent();
		s.generateMesh();
		
	}
	
	
	#region Inspector GUI
	public override void OnInspectorGUI()
	{
		//Debug.Log("OnInspectorGUI");
		
		ProcCube proc = (ProcCube)target;
		
		proc.m_Radius = EditorGUILayout.Slider(proc.m_Radius, 0.1f, 12);
		
		this.UpdateProcGeometry ();
	}
	
	#endregion
}

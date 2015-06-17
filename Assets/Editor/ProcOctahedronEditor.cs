using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ProcOctahedron))]
public class ProcOctahedronEditor : ProcBaseEditor {

	#region Inspector GUI
	public override void OnInspectorGUI()
	{
		//Debug.Log("OnInspectorGUI");
		
		ProcOctahedron proc = (ProcOctahedron)target;
		
		proc.m_Radius = EditorGUILayout.Slider(proc.m_Radius, 0.1f, 12);
		
		this.UpdateProcGeometry ();
	}
	
	#endregion
}

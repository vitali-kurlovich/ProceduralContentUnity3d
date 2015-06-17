using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ProcCylinder))]
public class ProcCylinderEditor : ProcBaseEditor {


	#region Inspector GUI
	public override void OnInspectorGUI()
	{
		//Debug.Log("OnInspectorGUI");

		ProcCylinder proc = (ProcCylinder)target;

		proc.m_Radius = EditorGUILayout.Slider(proc.m_Radius, 0.1f, 12);
		proc.m_Height = EditorGUILayout.Slider( proc.m_Height, 0.1f, 12);
		
		proc.m_RadialSegmentCount = EditorGUILayout.IntSlider( proc.m_RadialSegmentCount,3,32);
		proc.m_HeightSegmentCount = EditorGUILayout.IntSlider( proc.m_HeightSegmentCount,3,32);


		this.UpdateProcGeometry ();
	}

	#endregion
}

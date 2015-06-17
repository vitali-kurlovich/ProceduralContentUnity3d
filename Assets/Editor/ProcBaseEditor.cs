using UnityEngine;
using UnityEditor;

using System.Collections;

[CustomEditor(typeof(ProcBase))]
public class ProcBaseEditor : Editor {

	public void UpdateProcGeometry()
	{

		if (target == null) {
			return;
		}

		ProcBase proc = (ProcBase) target;
		proc.generateMesh ();

	}



}

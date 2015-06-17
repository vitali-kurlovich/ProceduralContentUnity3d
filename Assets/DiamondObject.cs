using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiamondObject : MonoBehaviour {

	public int width = 10;
	public float spacing = 1f;
	public float maxHeight = 3f;
	public MeshFilter terrainMesh = null;
	
	void Start()
	{
		if (terrainMesh == null)
		{
			Debug.LogError("ProceduralTerrain requires its target terrainMesh to be assigned.");
		}
		
		GenerateMesh();
	}
	
	void GenerateMesh ()
	{
		float start_time = Time.time;
		
		List<Vector3[]> verts = new List<Vector3[]>();
		List<int> tris = new List<int>();
		List<Vector2> uvs = new List<Vector2>();
		
		// Generate everything.
		for (int z = 0; z < width; z++)
		{
			verts.Add(new Vector3[width]);
			for (int x = 0; x < width; x++)
			{
				Vector3 current_point = new Vector3();
				current_point.x = (x * spacing) - (width/2f*spacing);
				current_point.z = z * spacing - (width/2f*spacing);
				// Triangular grid offset
				int offset = z % 2;
				if (offset == 1)
				{
					current_point.x -= spacing * 0.5f;
				}
				
				current_point.y = GetHeight(current_point.x, current_point.z);
				
				verts[z][x] = current_point;
				uvs.Add(new Vector2(x,z)); // TODO Add a variable to scale UVs.
				
				// TODO The edges of the grid aren't right here, but as long as we're not wrapping back and making underside faces it should be okay.
				
				// Don't generate a triangle if it would be out of bounds.
				int current_x = x + (1-offset);
				if (current_x-1 <= 0 || z <= 0 || current_x >= width)
				{
					continue;
				}
				// Generate the triangle north of you.
				tris.Add(x + z*width);
				tris.Add(current_x + (z-1)*width);
				tris.Add((current_x-1) + (z-1)*width);
				
				// Generate the triangle northwest of you.
				if (x-1 <= 0 || z <= 0)
				{
					continue;
				}
				tris.Add(x + z*width);
				tris.Add((current_x-1) + (z-1)*width);
				tris.Add((x-1) + z*width);
			}
		}
		
		// Unfold the 2d array of verticies into a 1d array.
		Vector3[] unfolded_verts = new Vector3[width*width];
		int i = 0;
		foreach (Vector3[] v in verts)
		{
			v.CopyTo(unfolded_verts, i * width);
			i++;
		}
		
		// Generate the mesh object.
		Mesh ret = new Mesh();
		ret.vertices = unfolded_verts;
		ret.triangles = tris.ToArray();
		ret.uv = uvs.ToArray();
		
		// Assign the mesh object and update it.
		ret.RecalculateBounds();
		ret.RecalculateNormals();
		terrainMesh.mesh = ret;
		
		float diff = Time.time - start_time;
		Debug.Log("ProceduralTerrain was generated in " + diff + " seconds.");
	}
	
	// Return the terrain height at the given coordinates.
	// TODO Currently it only makes a single peak of max_height at the center,
	// we should replace it with something fancy like multi-layered perlin noise sampling.
	float GetHeight(float x_coor, float z_coor)
	{
		float y_coor =
			Mathf.Min(
				0,
				maxHeight - Vector2.Distance(Vector2.zero, new Vector2(x_coor, z_coor)
			                             )
				);
		return y_coor;
	}
}

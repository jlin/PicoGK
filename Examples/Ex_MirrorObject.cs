﻿using System.Numerics;
using PicoGK;

namespace PicoGKExamples
{
	public class MirrorObject
	{
		public static void Task()
		{
			Lattice lat = new();
			lat.AddBeam(Vector3.Zero, new Vector3(50,0,0), 10, 5);

			Voxels vox = new(lat);
			Mesh mshOrg = new(vox);

            // Mesh mshNew1 is mirrored at at angle (direction 1,1,1)
			Mesh mshNew1 = mshOrg.mshCreateMirrored(Vector3.Zero, Vector3.One);

            // Mesh mshNew2 is mirrored at negative X direction
			Mesh mshNew2 = mshOrg.mshCreateMirrored(Vector3.Zero, -Vector3.UnitX);

            // Mesh mshNew3 we create using the System.Numerics.Plane class
            // and utilizing a transformation matrix
			Plane plane     = new(Vector3.UnitZ, 30f); // plane 30mm away in Z
			Matrix4x4 mat   = Matrix4x4.CreateReflection(plane);
			Mesh mshNew3    = mshOrg.mshCreateTransformed(mat);

			Library.oViewer().SetGroupMaterial(1, "AAAA", 0.5f, 0.5f);
			Library.oViewer().SetGroupMaterial(2, "FF0000AA", 0.5f, 0.5f);
			Library.oViewer().SetGroupMaterial(3, "00FF00AA", 0.5f, 0.5f);
			Library.oViewer().SetGroupMaterial(4, "0000FFAA", 0.5f, 0.5f);

			Library.oViewer().Add(mshOrg, 1);
			Library.oViewer().Add(mshNew1, 2);
			Library.oViewer().Add(mshNew2, 3);
			Library.oViewer().Add(mshNew3, 4);
		}
	}
}


	

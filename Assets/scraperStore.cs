using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class scraperStore
	{
		public scraperStore()
		{
			heightVals = new Dictionary<string,int>();
		}
		private Dictionary<string, int> heightVals;	
		public int getHeight(int x, int z)
		{
			if(heightVals.ContainsKey(x.ToString()+","+z.ToString())){
				return heightVals[x.ToString()+","+z.ToString()];
			}
			else {
				return setHeight(x, z);
			}
		}
		public int setHeight(int x, int z)
		{
			int height = Random.Range(75, 250);
			heightVals.Add(x.ToString()+","+z.ToString(), height);
			return height;
		}
		
	}
}

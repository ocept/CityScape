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
			gridsDrawn = new Dictionary<string, bool>();
		}
		private Dictionary<string, int> heightVals;	//coords and height of each tower
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
			try{
				heightVals.Add(x.ToString()+","+z.ToString(), height);
			}
			catch(System.ArgumentException){
				return heightVals[x.ToString()+","+z.ToString()];
			}
			return height;
		}
		
		private Dictionary<string, bool> gridsDrawn;
		public bool isGridDrawn(int x, int z)
		{
			if(gridsDrawn.ContainsKey(x.ToString()+","+z.ToString())){
				return true;
			}
			else return false;
		}
		public int markGridDrawn(int x, int z)
		{
			try{
				gridsDrawn.Add(x.ToString()+","+z.ToString(), true);
			}
			catch(System.ArgumentException){
				return -1;
			}
			return 1;
		}
	}
}

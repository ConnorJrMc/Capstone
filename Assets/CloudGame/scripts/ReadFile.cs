using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class ReadFile : MonoBehaviour {

	public List<string> readFile(string file)
	{
		List<string> entries = new List<string> ();
			string line;

			StreamReader theReader = new StreamReader(file,Encoding.Default);

			using (theReader)
			{
				do
				{
					line = theReader.ReadLine();

					if(line !=null)
					{
						entries.Add (line);
					}
				}
				while(line!=null);

				theReader.Close ();
			}
		
		return (entries);
	}

}

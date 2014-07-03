using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AdamPassey.Persistence.Container;

namespace  AdamPassey.Persistence
{

	public class Persister
	{

		public static void Save<T>(string filepath, T dataContainer) where T : DataContainer {
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = File.Open(PersistencePath(filepath), FileMode.OpenOrCreate);
			binaryFormatter.Serialize(fileStream, dataContainer);
			fileStream.Close();
		}

		public static T Load<T>(string filepath, T dataContainer) where T : DataContainer {
			if (File.Exists(PersistencePath(filepath))) {
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				FileStream fileStream = File.Open(PersistencePath(filepath), FileMode.Open);
				dataContainer = (T)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
			}
			return dataContainer;
		}

		private static string PersistencePath(string filepath) {
			return Application.persistentDataPath + "/" + filepath + ".dat";
		}
	}
}

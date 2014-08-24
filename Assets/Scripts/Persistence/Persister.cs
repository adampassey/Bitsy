using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AdamPassey.Persistence.Container;

namespace  AdamPassey.Persistence {

	public class Persister {

		/**
		 *	Save the Data Container at the given filename location
		 *	
		 *	@param filename The name of the file to save to
		 *		is relative to applications persistence path
		 *	@param dataContainer The Data Container to save
		 *	@return T dataContainer
		 **/
		public static void Save<T>(string filename, T dataContainer) where T : DataContainer {
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = File.Open(PersistencePath(filename), FileMode.OpenOrCreate);
			binaryFormatter.Serialize(fileStream, dataContainer);
			fileStream.Close();
		}

		/**
		 * 	Load the Data Container at the given filename location
		 * 
		 * 	@param filename The name of the file to load from
		 * 		is relative to applications persistence path
		 * 	@param dataContainer The Data Container to load data into
		 * 	@return T dataContainer
		 **/
		public static T Load<T>(string filename, T dataContainer) where T : DataContainer {
			if (File.Exists(PersistencePath(filename))) {
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				FileStream fileStream = File.Open(PersistencePath(filename), FileMode.Open);
				dataContainer = (T)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
			}
			return dataContainer;
		}

		/**
		 * 	Delete the specified file
		 * 
		 * 	@param filename The name of the file to delete
		 * 		is relative to applications persistence path
		 **/
		public static void Delete(string filename) {
			File.Delete(PersistencePath(filename));
		}

		/**
		 * 	Given a filepath, construct an absolute path within
		 * 	the applications persistent data path.
		 **/
		private static string PersistencePath(string filepath) {
			return Application.persistentDataPath + "/" + filepath + ".dat";
		}
	}
}

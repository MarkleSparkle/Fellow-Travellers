using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{


    public static void SaveLevel(int level)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+"/level.data";
        FileStream stream = new FileStream(path, FileMode.Create);//creating the file

        formatter.Serialize(stream, level);//writing to the file
        stream.Close();
    }

    public static int LoadLevel()
    {
        string path = Application.persistentDataPath + "/level.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            int level = (int) formatter.Deserialize(stream);
            stream.Close();

            return level;
        }
        else {
            Debug.LogError("Save file not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            string path2 = Application.persistentDataPath + "/level.data";
            FileStream stream = new FileStream(path2, FileMode.Create);//creating the file

            formatter.Serialize(stream, 0);//writing to the file
            stream.Close();

            return 0;
        }
    }
}

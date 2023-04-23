using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;

[CreateAssetMenu(
    fileName = "Player Progress",
    menuName = "Game kuis/Player Progress")]
public class PlayerProgres : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progressLevel;
    }

    public MainData progressData = new MainData();
    [SerializeField] string _filename = "Contoh.txt";

    public void SimpanProgress()
    {
        progressData.koin = 200;
        if (progressData.progressLevel == null)
            progressData.progressLevel = new();
        progressData.progressLevel.Add("Level Pack 1", 3);
        progressData.progressLevel.Add("Level Pack 3", 5);

        string directory = Application.dataPath + "/Temporary";
        string path = directory + "/" + _filename;

        if(!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been created : " + directory);
        }

        if(!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created : " + path);
        }

        //var konten = $"{progressData.koin}\n";
        var fileSteam = File.Open(path, FileMode.Open);
        //var formatter = new BinaryFormatter();

        fileSteam.Flush();
        //formatter.Serialize(fileSteam, progressData);

        var writer = new BinaryWriter(fileSteam);

        writer.Write(progressData.koin);
        foreach (var i in progressData.progressLevel)
        {
            writer.Write(i.Key);
            writer.Write(i.Value);
        }

        writer.Dispose();

        //foreach(var i in progressData.progressLevel)
        //{
        //konten += $"{i.Key} {i.Value}\n";
        //}

        //File.WriteAllText(path, konten);

        fileSteam.Dispose();

        Debug.Log($"{_filename} Berhasil Disimpan");

    }

    public bool MuatProgress()
    {
        string directory = Application.dataPath + "/Temporary";
        string path = directory + "/" +_filename;
        var fileSteam = File.Open(path, FileMode.OpenOrCreate);

        try
        {
            var reader = new BinaryReader(fileSteam);
            try
            {
                progressData.koin = reader.ReadInt32();
                if(progressData.progressLevel == null)
                {
                    progressData.progressLevel = new();
                }
                while (reader.PeekChar() != -1)
                {
                    var namaLevelPack = reader.ReadString();
                    var levelke = reader.ReadInt32();
                    progressData.progressLevel.Add(namaLevelPack, levelke);
                    Debug.Log($"{namaLevelPack}:{levelke}");
                }    

                reader.Dispose();
            }
            catch (System.Exception e)
            {
                Debug.Log($"ERROR: Terjadi kesalah saat memuat progress binari.\n{e.Message}");
                reader.Dispose();
                fileSteam.Dispose();

                return false;
            }
            //var formatter = new BinaryFormatter();

            //progressData = (MainData)formatter.Deserialize(fileSteam);

            fileSteam.Dispose();

            Debug.Log($"{progressData.koin}; {progressData.progressLevel.Count}");

            return true;
        }
        catch (System.Exception e) 
        {

            Debug.Log($"ERROR: Terjadi kesalah saat memuat progress\n{e.Message}");
            fileSteam.Dispose();
            return false;
        }



    }
}

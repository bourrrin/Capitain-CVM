using System.Collections.Generic;
using UnityEngine; 
/// <summary>
/// Offre un moteur de lecture/écriture du JSON
/// pour l'objet <code>PlayerData</code>
/// </summary>
public static class PlayerDataJson
{
    /// <summary>
    /// Sérialise un objet de type PlayerData au format JSON
    /// </summary>
    /// <param name="data">Paramètre à sérialiser</param>
    /// <returns>La chaîne contenant le format JSON</returns>
    [System.Serializable]
    class PlayerDataToJson
    {
        public int vie;
        public int energie;
        public int score;
        public int currentMaxLevel;
        public float volumeGeneral;
        public float volMusique;
        public float volEffet;
        public string[] chestOpenList;
        public string[] collectableList;

        public PlayerDataToJson(int vie, int energie, int score, float volGeneral, float volMusique, float volEffet, string[] chestList, string[] collectableList, int currentMaxLevel)
        {
            this.vie = vie;
            this.energie = energie;
            this.score = score;
            this.currentMaxLevel = currentMaxLevel;
            this.volEffet = volEffet;
            this.volumeGeneral = volGeneral;
            this.volMusique = volMusique;
            this.chestOpenList = chestList;
            this.collectableList = collectableList;
        }
    }
    public static string WriteJson(PlayerData data)
    {
        PlayerDataToJson pdtj = new PlayerDataToJson(data.Vie, data.Energie, data.Score, data.VolumeGeneral, data.VolumeMusique, data.VolumeEffet, data.ListeCoffreOuvert, data.ListeCollectable, data.CurrentMaxLevel);
        Debug.Log(JsonUtility.ToJson(pdtj));
        return JsonUtility.ToJson(pdtj);

        
    }

    /// <summary>
    /// Récupère un objet PlayerData depuis un format JSON
    /// </summary>
    /// <param name="json">Format JSON à traiter</param>
    /// <returns>L'objet converti</returns>
    /// <exception cref="JSONFormatExpcetion">La chaîne n'est pas
    /// au format JSON</exception>
    /// <exception cref="System.ArgumentException">La chaîne fournit
    /// ne peut pas contenir un format JSON</exception>
    public static PlayerData ReadJson(string json)
    {
        PlayerDataToJson pdtj = JsonUtility.FromJson<PlayerDataToJson>(json);

        //transform la data de chest de array a list
        List<string> chests = new List<string>();
        for (int i = 0; i < pdtj.chestOpenList.Length; i++)
        {
            chests.Add(pdtj.chestOpenList[i]);
        }


        //transform la data des collectables de array a list
        List<string> collectables = new List<string>();
        for (int i = 0; i < pdtj.collectableList.Length; i++)
        {
            collectables.Add(pdtj.collectableList[i]);
        }

        return new PlayerData(pdtj.vie, pdtj.energie, pdtj.score, pdtj.volumeGeneral, pdtj.volMusique, pdtj.volEffet, ChestList: chests, CollectableList: collectables, CurrentMaxLevel: pdtj.currentMaxLevel);

    }
}

public class JSONFormatExpcetion : System.Exception
{
    public JSONFormatExpcetion()
        : base("La chaîne n'est pas un format reconnu") { }
}

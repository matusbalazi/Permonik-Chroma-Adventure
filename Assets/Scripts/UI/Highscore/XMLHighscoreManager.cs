using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLHighscoreManager : MonoBehaviour
{
    private Leaderboard leaderboard;
    private readonly string HighScoresXMLFilePath = "/Highscores/highscores.xml";
    private readonly string HighScoresXMLFolderPath = "/Highscores/";
    private readonly int MaxStoredScores = 5;
    public List<int> Highscores { get; } = new();

    void Awake()
    {
        if (!Directory.Exists(Application.persistentDataPath + HighScoresXMLFolderPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath + HighScoresXMLFolderPath);
        }
        LoadScores();
    }

    public void AddScore(int score)
    {
        Highscores.Add(score);
        Highscores.Sort((int x, int y) => y.CompareTo(x));
        if (Highscores.Count > MaxStoredScores)
        {
            Highscores.RemoveAt(MaxStoredScores);
        }
    }

    public void SaveScores()
    {
        leaderboard = new() { };
        leaderboard.Entries.AddRange(Highscores);
        XmlSerializer serializer = new(typeof(Leaderboard));
        FileStream stream = new(Application.persistentDataPath + HighScoresXMLFilePath, FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
    }

    private void LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + HighScoresXMLFilePath))
        {
            XmlSerializer serializer = new(typeof(Leaderboard));
            FileStream stream = new(Application.persistentDataPath + HighScoresXMLFilePath, FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
            Highscores.AddRange(leaderboard.Entries);
        }
    }

    [System.Serializable]
    public class Leaderboard
    {
        public List<int> Entries { get; } = new();
    }
}
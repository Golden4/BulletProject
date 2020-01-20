using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelData : ScriptableObject
{

    static LevelData Ins;

    public static LevelData Get
    {
        get
        {
            if (Ins == null)
                Ins = Resources.Load<LevelData>("Data/LevelsData");

            return Ins;
        }
    }

    [SerializeField]
    List<LevelInfo> levels;

    public LevelInfo GetLevel(int levelNum)
    {      

        return levels[levelNum];
    }

    public int Count
    {
        get
        {
           return levels.Count;
        }
    }


    [System.Serializable]
    public class LevelInfo
    {
        public GameObject levelPf;
    }


}

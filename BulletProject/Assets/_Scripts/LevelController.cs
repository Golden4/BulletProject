using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelController : MonoBehaviour
{

    public int curLevel;

    public Transform levelHolder;
    
    private void Start()
    {
        LoadLevel(curLevel);
    }
    
    void LoadLevel(int levelNum)
    {
       GameObject levelGO = Instantiate(LevelData.Get.GetLevel(levelNum).levelPf);
       levelGO.transform.SetParent(levelHolder,false);
       levelGO.AddComponent<TilemapController>();


    }
}

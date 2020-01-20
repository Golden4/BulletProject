using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class GameAssets : ScriptableObject
{
    static GameAssets Ins;

    public static GameAssets Get
    {
        get
        {
            if (Ins == null)
                Ins = Resources.Load<GameAssets>("Data/GameAssets");

            return Ins;
        }
    }

    public enum Characters
    {
        Cowboy
    }

    [SerializeField]
    List<CharacterBase> characters;

    public CharacterBase GetCharacter(Characters character)
    {
        return characters.Find((x) => { return x.characterName == character; });
    }

    public CharacterBase SpawnCharacter(Characters character, Vector2 position, Quaternion rotation, bool isPlayer = false, Transform parent = null, bool worldPosition = false)
    {
        CharacterBase cb = Instantiate<CharacterBase>(GetCharacter(character), position, rotation);
        if (isPlayer)
            cb.InitAsPlayer();
        else cb.InitAsEnemy();

        cb.transform.SetParent(parent, worldPosition);
        return cb;
    }

}

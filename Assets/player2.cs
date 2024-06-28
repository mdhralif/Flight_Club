using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    public CharacterDatabase CharacterDB;//public SpriteRenderer artworkSprite;
    public GameObject characterObject;
    public int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectedOption = staticClass.player2selected;
        updateCH(selectedOption);
        Instantiate(characterObject);
    }
    void updateCH(int selectedOption)
    {
        Character character = CharacterDB.GetCharacter(selectedOption);
        this.characterObject = character.characterObject;
    }
}

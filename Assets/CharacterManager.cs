using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase CharacterDB;
    public SpriteRenderer artworkSprite;
    [SerializeField]
    public TextMeshProUGUI characterName;
    public int selectedOption;
    

    void Start()
    {
        staticClass.player1selected = 0;
        selectedOption = staticClass.player1selected;
        updateCH(selectedOption);

    }
    public void next()
    {
        selectedOption++;
        if (selectedOption >= CharacterDB.characterCount)
        {
            selectedOption = 0;
        }
        updateCH(selectedOption);
        save();
    }
    public void prev()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = CharacterDB.characterCount - 1;
        }
        updateCH(selectedOption);
        save();

    }
    void updateCH(int selectedOption)
    {
        Character character = CharacterDB.GetCharacter(selectedOption);
        characterName.text = character.characterName;
        artworkSprite.sprite = character.characterSprite;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void save()
    {
        //PlayerPrefs.SetInt("selectedOption", selectedOption);
        staticClass.player1selected = selectedOption;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    public SelectionDatabase selectionDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateSelection(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= selectionDB.SelectionCount)
        {
            selectedOption = 0;
        }

        UpdateSelection(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if(selectedOption < 0)
        {
            selectedOption = selectionDB.SelectionCount - 1;
        }

        UpdateSelection(selectedOption);
        Save();
    }

    private void UpdateSelection(int selectedOption)
    {
        Selection selection = selectionDB.GetSelection(selectedOption);
        artworkSprite.sprite = selection.selectionSprite;
        nameText.text = selection.selectionName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}




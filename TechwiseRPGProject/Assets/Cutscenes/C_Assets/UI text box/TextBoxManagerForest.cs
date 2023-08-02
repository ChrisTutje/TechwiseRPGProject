using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextBoxManagerForest : MonoBehaviour
{
    public GameObject textBox;

    public TextMeshProUGUI theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public Character player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Character>();
        if(textFile != null){
            textLines = (textFile.text.Split("\n"));
        }

        if(endAtLine == 0){
            endAtLine = textLines.Length - 1;
        }
    }

    void Update()
    {
        theText.text = textLines[currentLine] + "\n" + textLines[currentLine +1] + "\n" + textLines[currentLine+2];


        if(Input.GetKeyDown(KeyCode.Return)){
            currentLine += 3;
        }

        if(currentLine > endAtLine){
            //textBox.SetActive(false);
            SceneManager.LoadScene("OpeningCutscene");
        }

    }
}

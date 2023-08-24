using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueWindow : MonoBehaviour


{
    [SerializeField] private DialogueScene scene;
    [SerializeField] private Image portrait;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI message;

    private Animator animator; 
    private string dialogueOpenParameter = "dialogueOpen";
    private int currentSceneDialogueIndex = 0;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
     private void Update() {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            currentSceneDialogueIndex++;
            if(currentSceneDialogueIndex<scene.Dialogues.Count)
            {
            DisplayDialogue(scene.Dialogues[currentSceneDialogueIndex]);
            }
            else{
                Close();
            }
        }
    }

    public void Open(DialogueScene sceneToPlay)
    {
        scene = sceneToPlay;
        currentSceneDialogueIndex = 0;
        animator.SetBool(dialogueOpenParameter, true);
        DisplayDialogue(scene.Dialogues[currentSceneDialogueIndex]); 
    }
    

    private void DisplayDialogue(Dialogue dialogue)
    {
        portrait.sprite = dialogue.Sprite;
        name.text = dialogue.Name;
        message.text = dialogue.Message;
    }
    private void Close()
    {
        animator.SetBool(dialogueOpenParameter, false);
    }
}

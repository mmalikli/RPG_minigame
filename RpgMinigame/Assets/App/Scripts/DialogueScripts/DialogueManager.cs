using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
  #region Dialogue Manager Singleton
  public static DialogueManager instance;

  private void Awake() {
    if(instance == null) {
      instance = this;
    } else {
      Debug.LogWarning("Fix this"+ gameObject.name);
    }
  }
  #endregion

  [HideInInspector] public bool isPlayerInDialogue;

  [SerializeField] private GameObject dialogueBox;
  [SerializeField] private Text characterName;
  [SerializeField] private Text characterSpeech;
  [SerializeField] private Image characterPortrait;

  [SerializeField] private float delay = 0.001f;
  [SerializeField] private float punctuationDelay = 0.025f;

  private readonly List<char> punctuationCharacters = new List<char>{
    '.',',','!','?'
  };
  private DialogueType currentDialogueType;
  private bool isCurrentlyTyping;
  private bool buffer;
  private string completeText;

  private DialogueBase currentDialogue;

  #region Coroutines
  Coroutine typingTextCoroutine;
  Coroutine bufferTimeCoroutine;

  #endregion


  private Queue<DialogueBase.CharacterLine> dialogueLinesQueue = new Queue<DialogueBase.CharacterLine>();

  ///<summary>
  ///This method is used to load dialogues to the queue
  ///</summary>

  private void LateUpdate() {
    if(Input.GetKeyDown(KeyCode.I)) {
      if(isPlayerInDialogue) {
        DequeueDialogue();
      }
    }
  }

  public void EnqueueDialogue(DialogueBase db) {
    if (isPlayerInDialogue) return;
    
    buffer = true;
    isPlayerInDialogue = true;
    dialogueLinesQueue.Clear();
    StartCoroutine(BufferTimer());

    //Dialogue Start
    dialogueBox.SetActive(true);

    currentDialogue = db;
    currentDialogueType = db.dialogueType;//Basic, Options, Quest;

    switch (currentDialogueType)
    {
      case DialogueType.BASIC:
        foreach (DialogueBase.CharacterLine characterLine in db.characterLines) {
          dialogueLinesQueue.Enqueue(characterLine);
        }
        break;
      case DialogueType.OPTION:
        break;
    }
    DequeueDialogue();
  }

  private void DequeueDialogue() {
    if (isCurrentlyTyping == true) {
      if (buffer == true) return;
      CompleteText();
      StopAllCoroutines();
      //StopCoroutine(typingTextCoroutine);

      isCurrentlyTyping = false;
      return;
    }
    if(dialogueLinesQueue.Count == 0) {
      isPlayerInDialogue = false;
      EndOfDialogue();
      return;
    }

    DialogueBase.CharacterLine characterLine = dialogueLinesQueue.Dequeue();

    completeText = characterLine.text;

    characterName.text = characterLine.character.characterName;
    characterPortrait.sprite = characterLine.character.characterPortrait;
    //characterSpeech.text = characterLine.text;

    characterSpeech.text = "";

    StartCoroutine(TypeText(characterLine));
  }

  private IEnumerator TypeText(DialogueBase.CharacterLine dequeuedCharacterLine) {
    isCurrentlyTyping = true;
    foreach (char c in dequeuedCharacterLine.text.ToCharArray())
    {
      yield return new WaitForSeconds(delay);
      characterSpeech.text += c;
      AudioManger.instance.PlayClip(dequeuedCharacterLine.character.characterVoice);

      if (AddPunctuationDelay(c)) {
        yield return new WaitForSeconds(punctuationDelay);
      }
    }
    isCurrentlyTyping = false;
  }
  private IEnumerator BufferTimer() {
    yield return new WaitForSeconds(0.1f);
    buffer = false;
  }
  private bool AddPunctuationDelay(char c) {
    if (punctuationCharacters.Contains(c)) {
      return true;
    } else {
      return false;
    }
  }
  private void CompleteText() {
    characterSpeech.text = completeText;
  }

  private void EndOfDialogue() {
    dialogueBox.SetActive(false);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicBox.EventManagement;


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

  #region  Event Listeners
  private void OnEnable() {
    EventManager.Instance.AddListener<NextDialogueExistsEvent>(NextDialogueExistsEventHandler);
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<NextDialogueExistsEvent>(NextDialogueExistsEventHandler);
  }
  #endregion
  //Common Parameters
  [HideInInspector] public bool isPlayerInDialogue;
  
  //Options Dialogue Parameters
  [SerializeField] private GameObject dialogueOptionsUI;

  //Basic Dialogue Parameters
  [SerializeField] private GameObject dialogueBox;
  [SerializeField] GameObject[] optionButtons;
  [SerializeField] private Text questionText;
  public bool isPlayerInDialogueOption;
  private int optionsAmount;
  

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
    if (isPlayerInDialogue || isPlayerInDialogueOption) return;
    
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
        BasicDialogueParser(currentDialogue);
        break;
      case DialogueType.OPTION:
        BasicDialogueParser(currentDialogue);
        // inDialogue inOptionDialogue
        OptionsDialogueParser(currentDialogue);
        break;
    }
    DequeueDialogue();
  }

  private void BasicDialogueParser(DialogueBase dialogueBase) {
    DialogueBase basicDialogue = dialogueBase;
    foreach (DialogueBase.CharacterLine characterLine in basicDialogue.characterLines) {
      dialogueLinesQueue.Enqueue(characterLine);
    }
  }
  private void OptionsDialogueParser(DialogueBase dialogueBase) {
    //OpenOptionsDialogue();

    isPlayerInDialogueOption = true;
    DialogueOptions dialogueWithOptions = dialogueBase as DialogueOptions;

    questionText.text = dialogueWithOptions.questionText;
    optionsAmount = dialogueWithOptions.options.Length;

    optionButtons[0].GetComponent<Button>().Select();
    //Clearing previous options if they are still active
    for(int i = 0; i < optionButtons.Length; i++) {
        optionButtons[i].SetActive(false);
      }
    for (int i = 0; i < optionsAmount; i++)
    {
      optionButtons[i].SetActive(true);
      optionButtons[i].GetComponentInChildren<Text>().text = dialogueWithOptions.options[i].buttonName;

      if(dialogueWithOptions.options[i].nextDialogue != null) {
        optionButtons[i].GetComponent<OptionButton>().NextDialogue = dialogueWithOptions.options[i].nextDialogue;
      }
    }
   // isPlayerInDialogueOption = false;
  }
  private void OpenOptionsDialogue() {
    Debug.Log("!!!");
    dialogueOptionsUI.SetActive(true);
  }
  private void CloseOptionsDialogue() {
    isPlayerInDialogueOption = false;
    dialogueOptionsUI.SetActive(false);
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
    characterLine.ChangeEmotion();
    characterPortrait.sprite = characterLine.character.CharacterPortrait;
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
    yield return new WaitForSeconds(0.2f);
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
    OptionUIHandler();
  }
  private void OptionUIHandler() {
    if (isPlayerInDialogueOption == true) {
      dialogueOptionsUI.SetActive(true);
      //OpenOptionsDialogue();
    } else {
      isPlayerInDialogue = false;
    }
  }

  #region Event Handlers
  private void NextDialogueExistsEventHandler(NextDialogueExistsEvent eventDetails) {
    CloseOptionsDialogue();
    EnqueueDialogue(eventDetails.nextDialogue);
  }
  #endregion
}
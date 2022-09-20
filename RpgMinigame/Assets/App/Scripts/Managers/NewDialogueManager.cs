using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using UnityEngine.UI;

public class NewDialogueManager : MonoBehaviour
{
  #region Dialogue Manager Singleton
  public static NewDialogueManager instance;

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
  #region Event Handlers
  private void NextDialogueExistsEventHandler(NextDialogueExistsEvent eventDetails) {
    //CloseOptionsDialogue();
    //Debug.Log("text loaded");
    //EnqueueDialogue(eventDetails.nextDialogue);
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

  [SerializeField] private DialogueBase currentDialogue;

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
        //DequeueDialogue();
      }
    }
  }

}

using DynamicBox.EventManagement;

public class OnSFXChangeEvent : GameEvent
{
  public float  SFXValue;

  public OnSFXChangeEvent(float _sfxValue){
    SFXValue = _sfxValue; 
  }
}

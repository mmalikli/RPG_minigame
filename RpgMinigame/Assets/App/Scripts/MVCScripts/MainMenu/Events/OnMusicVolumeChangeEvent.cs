using DynamicBox.EventManagement;

public class OnMusicVolumeChangeEvent : GameEvent
{
  public float MusicValue;

  public OnMusicVolumeChangeEvent(float _musicValue){
    MusicValue  = _musicValue;
  }
}

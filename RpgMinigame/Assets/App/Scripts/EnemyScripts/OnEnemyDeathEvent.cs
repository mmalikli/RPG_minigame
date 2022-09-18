using DynamicBox.EventManagement;

public class OnEnemyDeathEvent : GameEvent
{
  public EnemyProfile enemyProfile;

  public OnEnemyDeathEvent(EnemyProfile _enemyProfile) {
    enemyProfile = _enemyProfile;
  }
}

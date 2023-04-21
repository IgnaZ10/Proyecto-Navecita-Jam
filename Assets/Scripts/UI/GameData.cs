using UnityEngine;

[CreateAssetMenu(fileName ="GameData", menuName ="Custom/Game Data")]
public class GameData : ScriptableObject
{
    public float volumeMaster;
    public float volumeMusic;
    public float volumeEffects;

    public float highScore;
}

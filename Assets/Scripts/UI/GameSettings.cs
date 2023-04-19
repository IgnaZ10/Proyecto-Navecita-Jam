using UnityEngine;

[CreateAssetMenu(fileName ="GameSettings", menuName ="Custom/Game Settings")]
public class GameSettings : ScriptableObject
{
    public float volumeMaster;
    public float volumeMusic;
    public float volumeEffects;
}

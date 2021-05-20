using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class playerStats : ScriptableObject
{
    public GameObject player;
    [Range(1,5)]
    public int health = 3;

}

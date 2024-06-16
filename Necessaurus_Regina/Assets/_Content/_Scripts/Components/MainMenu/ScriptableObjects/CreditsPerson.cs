using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Credits Person", menuName = "Scriptables/Menu/CreditsPerson")]
public class CreditsPerson : ScriptableObject
{
    public string FullName;
    public string Nickname;
    public string Role;
    public Sprite CountryFlag;
    public string ItchLink;
}

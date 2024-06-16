using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditPersonEntry : MonoBehaviour
{
    public GameObject ItchInfo;
    public TextMeshProUGUI FullName;
    public Button ItchLink;
    public TextMeshProUGUI Role;
    public Image CountryFlag;
    // Country flags sourced from: https://www.flaticon.com/packs/countrys-flags
    
    private CreditsPerson person;
    
    public void OpenItchLink()
    {
        Application.OpenURL(person.ItchLink);
    }

    public void Initialize(CreditsPerson creditsPerson)
    {
        person = creditsPerson;
        
        FullName.text = creditsPerson.FullName;
        Role.text = creditsPerson.Role;
        
        if (!string.IsNullOrEmpty(creditsPerson.Nickname) && !string.IsNullOrEmpty(creditsPerson.ItchLink))
        {
            ItchInfo.SetActive(true);
            ItchLink.onClick.AddListener(OpenItchLink);
            TextMeshProUGUI buttonText = ItchLink.GetComponentInChildren<TextMeshProUGUI>();
        }
        else
        {
            ItchInfo.SetActive(false);
        }
        
        if (creditsPerson.CountryFlag != null)
        {
            CountryFlag.sprite = creditsPerson.CountryFlag;
        }
    }
}

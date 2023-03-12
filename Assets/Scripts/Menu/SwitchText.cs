using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchText : MonoBehaviour
{
    TMPro.TMP_Text text;

    private void Start() {
        text = GetComponentInChildren<TMPro.TMP_Text>();
    }

    public void ToEnglish() {
        text.text = $"This game was created by Vratislav Medricky and Matej Verner in 2023 during an event named Stribrnicky GameJam. \r\nThis event is hosted by SPS Resslova - Stribrniky and it focuses on students across all semesters.\r\n\r\nThis Game was created in 48 hours.\r\nMany brain cells died that day, but many new connections were established.\r\nCheers!";
    }

    public void ToCzech() {
        text.text = $"Tato hra byla vytvo�ena Vratislavem Med�ick�m a Mat�jem Vernerem v roce 2023 b�hem St��brnick�ho GameJamu. \r\nTuto ud�lost po��d� SP� Resslova - St��brn�ky a zam��uje se na ��ky nap��� v�emi ro�n�ky.\r\n\r\nHra byla vytvo�ena za 48 hodin.\r\nTen den um�elo mnoho mozkov�ch bun�k, ale byla nav�z�na spousta nov�ch spojen�.\r\nCheers!";

    }
}

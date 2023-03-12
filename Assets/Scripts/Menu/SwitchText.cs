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
        text.text = $"Tato hra byla vytvoøena Vratislavem Medøickým a Matìjem Vernerem v roce 2023 bìhem Støíbrnického GameJamu. \r\nTuto událost poøádá SPŠ Resslova - Støíbrníky a zamìøuje se na žáky napøíè všemi roèníky.\r\n\r\nHra byla vytvoøena za 48 hodin.\r\nTen den umøelo mnoho mozkových bunìk, ale byla navázána spousta nových spojení.\r\nCheers!";

    }
}

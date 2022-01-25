using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsActivateLogic : MonoBehaviour
{
    [SerializeField] private Card currentCard;

    public Card CurrentCard => currentCard;

    [SerializeField] private Card[] cards;

    void Start()
    {
        GetAllCards();
    }

    public void GetAllCards()
    {
        cards = new Card[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            cards[i] = GetComponentsInChildren<Card>()[i];
    }

    public void ActivateRandomCard()
    {
        DeactivateAllCard();
        currentCard = cards[Random.Range(0, cards.Length)];
        currentCard.Activate();
    }
    
    public void DeactivateAllCard()
    {
        foreach (Card card in cards)
            card.Deactivate();
    }
}

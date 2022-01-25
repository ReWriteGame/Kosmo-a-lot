using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameRule : MonoBehaviour
{
    [SerializeField] private Card activeGameCard;
    [SerializeField] private List<Card> cards;
    [SerializeField] private CardsActivateLogic cardsGame;

    public UnityEvent cardsMatchEvent;
    public UnityEvent cardsNotMatchEvent;
    public UnityEvent cardsIsOverEvent;
    void Start()
    {
        GetAllCards();
    }

    public void GetAllCards()
    {
        foreach(Card child in GetComponentsInChildren<Card>())
            cards.Add(child);
    }

    public void FindActiveCard()
    {
        foreach (Card card in cards)
        {
            if (card.IsActive)
            {
                activeGameCard = card;
                break;
            }
        }
    }
    public void CompareCards()
    {
        if (activeGameCard.ID == cardsGame.CurrentCard.ID)
        {
            cards.Remove(activeGameCard);
            activeGameCard.gameObject.GetComponent<Destroyable>().Destroy(.3f);
            cardsMatchEvent?.Invoke();
        }
        else
        {
            cardsNotMatchEvent?.Invoke();
        }
    }

    public void CheckCardIsOver()
    {
        if(cards.Count <= 0)cardsIsOverEvent?.Invoke();
    }
}

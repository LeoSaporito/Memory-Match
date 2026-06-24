using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GameManager : MonoBehaviour
{
    GameObject[] cardLayout = new GameObject[12];

    public GameObject cards;

    public Sprite oneBlue, twoGreen, coin, train, joker, stopSign;

    List<Sprite> shuffledFaces;

    public GameObject firstFlippedCard;
    public GameObject secondFlippedCard;

    Coroutine cardCheckCoroutine;

    bool isFinished;

    UIManager uiManagerScript;

    void Start()
    {
        uiManagerScript = FindFirstObjectByType<UIManager>();
        isFinished = false;        
        shuffledFaces = new List<Sprite>()
        { 
            oneBlue, oneBlue,
            twoGreen, twoGreen,
            coin, coin,
            train, train,
            joker, joker,
            stopSign, stopSign,
        };

        Shuffle(shuffledFaces);

        cardLayout = new GameObject[]
        {
            Create(shuffledFaces[0], 0, 0), Create(shuffledFaces[1], 1, 0), Create(shuffledFaces[2], 2, 0), Create(shuffledFaces[3], 3, 0),
            Create(shuffledFaces[4], 0, 1), Create(shuffledFaces[5], 1, 1), Create(shuffledFaces[6], 2, 1), Create(shuffledFaces[7], 3, 1),
            Create(shuffledFaces[8], 0, 2), Create(shuffledFaces[9], 1, 2), Create(shuffledFaces[10], 2, 2), Create(shuffledFaces[11], 3, 2),
        };
    }

    GameObject Create(Sprite face, int x, int y)
    {
        GameObject obj = Instantiate(cards, new Vector2(x, y), Quaternion.identity);
        Cards c = obj.GetComponent<Cards>();
        c.SetXPosition(x);
        c.SetYPosition(y);
        c.SetFace(face);
        c.Activate();
        return obj;
    }
    public void OnClick(InputValue value)
    {
        if (!FindFirstObjectByType<UIManager>().GetIsStarted()) {  return; }

        if (value.isPressed)
        {            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if(cardCheckCoroutine != null) { return; }

            if (hit.collider != null)
            {
                Cards clickedCard = hit.collider.GetComponent<Cards>();

                if (clickedCard.isRevealed) { return; }
                else { clickedCard.Reveal(); }

                GameObject clickedCardGameObject = hit.collider.gameObject;
                if (firstFlippedCard == null)
                {
                    firstFlippedCard = clickedCardGameObject;
                }
                else if (secondFlippedCard == null && cardCheckCoroutine == null)
                {
                    secondFlippedCard = clickedCardGameObject;
                    cardCheckCoroutine = StartCoroutine(FlippedCardCheckCoroutine());
                }
            }
        }
    }
    IEnumerator FlippedCardCheckCoroutine()
    {
        yield return new WaitForSeconds(1f);

        FlippedCardCheck();
    }
    void FlippedCardCheck()
    {
        Sprite firstCardSprite = firstFlippedCard.GetComponent<SpriteRenderer>().sprite;
        Sprite secondCardSprite = secondFlippedCard.GetComponent<SpriteRenderer>().sprite;

        Cards cOne = firstFlippedCard.GetComponent<Cards>();
        Cards cTwo = secondFlippedCard.GetComponent<Cards>();

        if (firstCardSprite == secondCardSprite)
        {
            uiManagerScript.matchedPairs++;

            Destroy(firstFlippedCard);
            Destroy(secondFlippedCard);
        }
        else if (firstCardSprite != secondCardSprite)
        {
            cOne.Hide();
            cTwo.Hide();
        }

        firstFlippedCard = null;
        secondFlippedCard = null;
        cardCheckCoroutine = null;
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);

            Sprite temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }        
    }    
}

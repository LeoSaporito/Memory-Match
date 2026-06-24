using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] float xSpacing;
    [SerializeField] float ySpacing;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;

    public Sprite oneBlue, twoGreen, coin, train, joker, stopSign, back;

    float xPosition;
    float yPosition;

    int[] numbers = new int[12];

    public void Activate()
    {
        AdjustPosition();

        GetComponent<SpriteRenderer>().sprite = back;
    }

    public void SetXPosition(int x)
    {
        xPosition = x;
    }
    public void SetYPosition(int y)
    {
        yPosition = y;
    }

    void AdjustPosition()
    {
        float x = xPosition;
        float y = yPosition;

        x *= xSpacing;
        y *= ySpacing;

        x += xOffset;
        y += yOffset;

        this.transform.position = new Vector2(x, y);
    }

    void CardFaces()
    {
        List<int> availableNumbers = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            availableNumbers.Add(i);
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            int randomNumber = Random.Range(0, availableNumbers.Count);

            numbers[i] = availableNumbers[randomNumber];

            availableNumbers.RemoveAt(randomNumber);
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            switch (numbers[i])
            {
                case 0: case 1: 
                this.GetComponent<SpriteRenderer>().sprite = oneBlue;
                break;

                case 2: case 3:
                this.GetComponent<SpriteRenderer>().sprite = twoGreen;
                break;

                case 4:case 5:
                this.GetComponent<SpriteRenderer>().sprite = coin;
                break;

                case 6: case 7:
                this.GetComponent<SpriteRenderer>().sprite = train;
                break;

                case 8: case 9:
                this.GetComponent<SpriteRenderer>().sprite = joker;
                break;

                case 10:
                case 11:
                this.GetComponent<SpriteRenderer>().sprite = stopSign;
                break;
            }
        }
    }
}

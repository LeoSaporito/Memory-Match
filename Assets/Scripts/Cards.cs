using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] float xSpacing;
    [SerializeField] float ySpacing;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;

    public Sprite back;

    Sprite face;
    
    SpriteRenderer sr;
    float xPosition;
    float yPosition;

    public bool isRevealed;

    int[] numbers = new int[12];

    private void Awake()
    {
        this.isRevealed = false;
        sr = GetComponent<SpriteRenderer>();        
    }
    public void Activate()
    {
        AdjustPosition();
        Hide();
    }

    public void SetFace(Sprite newFace)
    {
        face = newFace;
    }

    public void Reveal()
    {
        sr.sprite = face;
        this.isRevealed = true;
    }

    public void Hide()
    {
        sr.sprite = back;
        this.isRevealed = false;
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
}

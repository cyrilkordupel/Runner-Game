using UnityEngine;

[System.Serializable]
public enum VerticalSide { Up, Mid, Down }

public class VerticalSides : MonoBehaviour
{
    [Header("Set up")]
    public float yPosition;
    public float yValue;
    public float speedToMove;

    [Header("Data")]
    float smoothY;
    bool swipeUp;
    bool swipeDown;

    Vector3 position;

    public static VerticalSide verticalSide = VerticalSide.Mid;

    CharacterController playerCharacterController;

    void Start()
    {
        verticalSide = VerticalSide.Mid;
        playerCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // swipeUp = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow);
        // swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        // if (swipeUp)
        // {
        //     if (verticalSide == VerticalSide.Mid)
        //     {
        //         yPosition = yValue;
        //         verticalSide = VerticalSide.Up;
        //     }
        //     if (verticalSide == VerticalSide.Down)
        //     {
        //         yPosition = 0;
        //         verticalSide = VerticalSide.Mid;
        //     }
        // }

        // if (swipeDown)
        // {
        //     if (verticalSide == VerticalSide.Mid)
        //     {
        //         yPosition = -yValue;
        //         verticalSide = VerticalSide.Down;
        //     }
        //     else if (verticalSide == VerticalSide.Up)
        //     {
        //         yPosition = 0;
        //         verticalSide = VerticalSide.Mid;
        //     }
        // }

        smoothY = Mathf.Lerp(smoothY, yPosition, Time.deltaTime * speedToMove);

        playerCharacterController.Move(((smoothY - transform.position.y) * Vector3.up));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Down") && verticalSide == VerticalSide.Mid)
        {
            yPosition = -yValue;
            verticalSide = VerticalSide.Down;
        }
        if (other.CompareTag("Up") && verticalSide == VerticalSide.Down)
        {
            yPosition = 0;
            verticalSide = VerticalSide.Mid;
        }
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Board mBoard;

    void Start()
    {
        mBoard.Create();
    }
}

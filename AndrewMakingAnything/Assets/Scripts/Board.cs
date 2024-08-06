using UnityEngine;
using UnityEngine.UI;

public enum CellState
{
    Friendly,
    Enemy,
    Free,
    OutOfBounds,
}

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;
    public Color cellColorWhite;
    public Color cellColorBlack;

    [HideInInspector]
    public Cell[,] mAllCells = new Cell[8, 8];

    public void Create()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GameObject newCell = Instantiate(mCellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 50);

                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x, y].Setup(new Vector2Int(x, y), this);

                bool isEven = (x + y) % 2 == 0;
                mAllCells[x, y].GetComponent<Image>().color = isEven
                    ? cellColorWhite
                    : cellColorBlack;
            }
        }
    }

    public CellState ValidateCell(int targetX, int targetY, BasePiece checkingPiece)
    {
        if (targetX < 0 || targetX > 7)
            return CellState.OutOfBounds;

        if (targetY < 0 || targetY > 7)
            return CellState.OutOfBounds;

        Cell targetCell = mAllCells[targetX, targetY];

        if (targetCell.mCurrentPiece == null)
            return CellState.Free;

        if (targetCell.mCurrentPiece.mColor == checkingPiece.mColor)
            return CellState.Friendly;

        return CellState.Enemy;
    }
}

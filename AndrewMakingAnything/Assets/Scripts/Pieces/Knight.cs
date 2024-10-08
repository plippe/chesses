using UnityEngine;
using UnityEngine.UI;

public class Knight : BasePiece
{
    override public void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Knight");
    }

    private void CreateCellPath(int flipper)
    {
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        MatchesState(currentX + 2, currentY + 1 * flipper);
        MatchesState(currentX + 1, currentY + 2 * flipper);
        MatchesState(currentX - 1, currentY + 2 * flipper);
        MatchesState(currentX - 2, currentY + 1 * flipper);
    }

    protected override void CheckPathing()
    {
        CreateCellPath(1);
        CreateCellPath(-1);
    }

    private void MatchesState(int targetX, int targetY)
    {
        CellState cellState = mCurrentCell.mBoard.ValidateCell(targetX, targetY, this);

        switch (cellState)
        {
            case CellState.Free:
            case CellState.Enemy:
                mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
                break;
        }
    }
}

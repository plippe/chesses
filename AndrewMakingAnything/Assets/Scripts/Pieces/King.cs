using UnityEngine;
using UnityEngine.UI;

public class King : BasePiece
{
    private Rook mLeftRook = null;
    private Rook mRightRook = null;

    override public void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        mMovement = new Vector3Int(1, 1, 1);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_King");
    }

    override public void Kill()
    {
        base.Kill();

        mPieceManager.mIsKingAlive = false;
    }

    protected override void CheckPathing()
    {
        base.CheckPathing();

        mRightRook = GetRook(1, 3);
        mLeftRook = GetRook(-1, 4);
    }

    public override void Move()
    {
        base.Move();

        if (CanCastle(mLeftRook))
            mLeftRook.Castle();

        if (CanCastle(mRightRook))
            mRightRook.Castle();
    }

    private bool CanCastle(Rook rook)
    {
        if (rook == null)
            return false;

        if (rook.mCastleTriggerCell != mCurrentCell)
            return false;

        return true;
    }

    private Rook GetRook(int direction, int count)
    {
        if (!mIsFirstMove)
            return null;

        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        for (int i = 1; i < count; i++)
        {
            int offsetX = currentX + i * direction;
            CellState cellState = mCurrentCell.mBoard.ValidateCell(offsetX, currentY, this);

            if (cellState != CellState.Free)
                return null;
        }

        Cell rookCell = mCurrentCell.mBoard.mAllCells[currentX + count * direction, currentY];
        Rook rook = rookCell.mCurrentPiece as Rook;

        if (rook == null)
            return null;

        if (!rook.mIsFirstMove)
            return null;

        if (rook.mColor != mColor)
            return null;

        mHighlightedCells.Add(rook.mCastleTriggerCell);
        return rook;
    }
}

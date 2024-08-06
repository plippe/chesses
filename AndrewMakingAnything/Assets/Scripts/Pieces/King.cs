using UnityEngine;
using UnityEngine.UI;

public class King : BasePiece
{
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
}

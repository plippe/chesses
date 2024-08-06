using UnityEngine;
using UnityEngine.UI;

public class Knight : BasePiece
{
    override public void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Knight");
    }
}

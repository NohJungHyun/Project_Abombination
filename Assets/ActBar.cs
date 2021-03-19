using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActBar : MonoBehaviour
{
    public Image actBar;
    public BattleController battleController;
    public List<Sprite> actSprites = new List<Sprite>(30);
    public List<Image> actImages = new List<Image>(30);
    public Image baseImage;
    public Sprite baseSprite;

    public void SetActImages()
    {
        actBar = this.GetComponentInChildren<Image>();

        for (int i = 0; i < battleController.characterList.Count; i++)
        {
            actSprites.Add(battleController.characterList[i].characterInfo.characterImage);
            GameObject buttonObj = new GameObject();
            buttonObj.AddComponent<Button>();
            // actImages[i].enabled = true;
            buttonObj.transform.SetParent(actBar.rectTransform);
            // actImages[i].
        }
        baseImage.enabled = false;
    }

    public void GetBattleController(BattleController _battleController)
    {
        battleController = _battleController;
    }

    public void RemoveActImage(Image _img)
    {
        if (actImages.Equals(_img))
        {
            actImages.Remove(_img);
        }
    }
}

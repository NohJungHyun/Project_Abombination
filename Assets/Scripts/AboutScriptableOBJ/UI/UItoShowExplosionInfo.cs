using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItoShowExplosionInfo : MonoBehaviour, ICloseUI
{
    // CharacterBattleAction characterBattleAction;
    public GameObject showExplosionCondition;
    public UItoShowBombInfo uitoShowBomb;

    public Text exploName;
    public Text exploDesc;
    public Text exploCount;

    public Sprite baseButtonSprite;

    public List<Button> exploSetupButton = new List<Button>();

    public bool isUIOn;

    // Start is called before the first frame update
    void Start()
    {
        // characterBattleAction = GameObject.FindObjectOfType<CharacterBattleAction>();
        uitoShowBomb = GameObject.FindObjectOfType<UItoShowBombInfo>();
        exploSetupButton.AddRange(GetComponentsInChildren<Button>());
        showExplosionCondition.gameObject.SetActive(false);

        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.image.sprite = baseButtonSprite;
            b.GetComponentInChildren<Text>().text = " ";
            exploSetupButton.Add(b);
        }
    }

    public void ExhibitExploButtons()
    {
        showExplosionCondition.gameObject.SetActive(true);

        Temp_Character temp_char = BattleController.instance.nowPlayCharacter;

        for (int e = 0; e < temp_char.canSetExplosions.Count; e++)
        {
            int explosLisnter = e;

            exploSetupButton[explosLisnter].image.sprite = temp_char.canSetExplosions[explosLisnter].exploImage;
            exploSetupButton[explosLisnter].onClick.RemoveAllListeners();
            exploSetupButton[explosLisnter].onClick.AddListener(() => AddExplosion.DoExplosionSetUp(temp_char.canSetExplosions[explosLisnter], uitoShowBomb));
        }
    }
    
    public bool CloseActiveUI()
    {
        return true;
    }
}

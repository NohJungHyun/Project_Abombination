using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItoShowExplosionInfo : MonoBehaviour
{
    CharacterBattleAction characterBattleAction;
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
        //characterBattleAction = GameObject.Find("BattleController").GetComponent<CharacterBattleAction>();
        characterBattleAction = GameObject.FindObjectOfType<CharacterBattleAction>();
        uitoShowBomb = GameObject.FindObjectOfType<UItoShowBombInfo>();
        exploSetupButton.AddRange(GetComponentsInChildren<Button>());

        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.image.sprite = baseButtonSprite;
            b.GetComponentInChildren<Text>().text = " ";
            exploSetupButton.Add(b);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (uitoShowBomb.showBombContidition.activeInHierarchy)
        {
            Temp_Character temp_char = characterBattleAction.battleController.nowPlayCharacter;

            if (temp_char)
            {
                for (int e = 0; e < temp_char.canSetExplosions.Count; e++)
                {
                    int explosLisnter = e;
                    exploSetupButton[explosLisnter].image.sprite = temp_char.canSetExplosions[explosLisnter].exploImage;
                    // exploSetupButton[e].image.sprite = temp_char.canSetExplosions[e].exploImage;
                    exploSetupButton[explosLisnter].onClick.AddListener(() => characterBattleAction.DoExplosionSetUp(temp_char.canSetExplosions[explosLisnter]));
                }
            }
            showExplosionCondition.SetActive(true);
        }
        else
            showExplosionCondition.SetActive(false);
    }

    public void ExhibitexploCondition()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickBarUI : MonoBehaviour
{
    public List<Button> quickButtons = new List<Button>(6);
    // public List<ThingsInGame> usables = new List<ThingsInGame>(6);
    // public BombModifier bombModifier;
    bool isCanSetBombs;
    [SerializeField] bool isCanChange;

    public Temp_Character nowCharacter;
    public Sprite basicSprite;

    public void SetNowCharacter(Temp_Character _Character)
    {
        nowCharacter = _Character;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ResetButtons();

            if (BattleController.instance.GetCharacterAction().GetType().Equals(typeof(ModifyAbombination)))
            {
                Debug.Log("우효 wwww");
                isCanSetBombs = !isCanSetBombs;

                if (isCanSetBombs)
                    SetBombsToButtons(nowCharacter.GetCanSetBombs());
                else
                    SetExplosionsToButtons(nowCharacter.GetCanSetExplosions());
            }
            else
            {
                isCanChange = !isCanChange;

                if (isCanChange)
                    SetItemToButtons(nowCharacter.GetPreparedItems());
                else
                    SetSkillToButtons(nowCharacter.GetPreparedSkills());

            }
        }

    }

    public void SetToButton(List<IUsable> _usable)
    {

    }

    public void SetBombsToButtons(List<Bomb> _bombs)
    {
        int i = 0;
        for (int b = 0; b < _bombs.Count; b++)
        {
            i = b;

            if(_bombs[b] == null) 
                quickButtons[b].image.sprite = basicSprite;
            else
                quickButtons[b].image.sprite = _bombs[b].GetSprite();

            quickButtons[b].onClick.AddListener(() => _bombs[i].Use());
        }
    }

    public void SetExplosionsToButtons(List<Explosion> _explosions)
    {
        int i = 0;
        for (int b = 0; b < _explosions.Count; b++)
        {
            i = b;

            if(_explosions[b] == null) 
                quickButtons[b].image.sprite = basicSprite;
            else
                quickButtons[b].image.sprite = _explosions[b].GetSprite();

            quickButtons[b].onClick.AddListener(() => _explosions[i].Use());
        }
    }

    public void SetSkillToButtons(List<ActiveSkill> _skills)
    {
        int i = 0;

        for (int b = 0; b < _skills.Count; b++)
        {
            i = b;

            if(_skills[b] == null) 
                quickButtons[b].image.sprite = basicSprite;
            else
                quickButtons[b].image.sprite = _skills[b].GetSprite();

            Debug.Log(_skills[b].Activation.GetInvocationList().Length);
            quickButtons[b].onClick.AddListener(() => StartCoroutine(_skills[i].Activation?.Invoke()));
        }
    }

    public void SetItemToButtons(List<ActiveItem> _items)
    {
        int i = 0;
        for (int b = 0; b < _items.Count; b++)
        {
            i = b;

            if(_items[b] == null) 
                quickButtons[b].image.sprite = basicSprite;
            else
                quickButtons[b].image.sprite = _items[b].GetSprite();

            quickButtons[b].onClick.AddListener(() => StartCoroutine(_items[i].Activation?.Invoke()));
        }
    }

    public void ResetButtons()
    {
        for (int btn = 0; btn < quickButtons.Count; btn++)
        {
            quickButtons[btn].onClick.RemoveAllListeners();
            quickButtons[btn].image.sprite = basicSprite;
        }
    }

    public List<Button> GetQuickButtons()
    {
        return quickButtons;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLimitArea : MonoBehaviour
{
    public static MoveLimitArea instance;

    [SerializeField] float radius;

    public GameObject moveLimitBorder;

    [SerializeField] Material forceShieldMaterial;

    public Color shrinkingColor;
    public Color limitedColor;

    [SerializeField] float shrinkingSpeed;

    public float minSize, maxSize;

    public Temp_Character modifiedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        forceShieldMaterial = moveLimitBorder.GetComponent<Material>();
        moveLimitBorder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetInitialSize(BattleController.instance.GetNowPlayCharacter());
        }

        if (modifiedCharacter && new Vector3(minSize, 0, minSize).magnitude < new Vector3(transform.localScale.x, 0, transform.localScale.z).magnitude) // minSize < transform.localScale.magnitude
        {
            Shrink(modifiedCharacter);
            transform.position = modifiedCharacter.transform.position;
            Debug.Log("출항!");
        }

        if (modifiedCharacter && modifiedCharacter.GetCharacterInfo().characterMovement < Vector3.Distance(modifiedCharacter.GetBasicPos(), modifiedCharacter.GetCharacterPos()))
        {
            print("영역 밖입니다!!!: " + Vector3.Distance(modifiedCharacter.GetBasicPos(), modifiedCharacter.GetCharacterPos()));
        }
    }

    public void SetInitialSize(Temp_Character _Character)
    {
        moveLimitBorder.SetActive(true);
        modifiedCharacter = _Character;
        maxSize = modifiedCharacter.GetCharacterInfo().characterMovement * 5f;
        minSize = modifiedCharacter.GetCharacterInfo().characterMovement * 2f;

        transform.localScale = Vector3.one * maxSize;
    }

    public void Shrink(Temp_Character _Character)
    {
        Vector3 modifiedSize = transform.localScale;
        modifiedSize.x -= Time.deltaTime;
        modifiedSize.y -= Time.deltaTime;
        modifiedSize.z -= Time.deltaTime;

        transform.localScale = modifiedSize;
    }

    public float CalculateBorderScale(float movement)
    {
        return movement * 2f;
    }
}

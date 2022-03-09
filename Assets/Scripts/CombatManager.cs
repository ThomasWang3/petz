using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author(s): Thomas Wang, Logan Mikulski, Daniel J. Garcia
public class CombatManager : MonoBehaviour {
    // Multiplayer Check
    [SerializeField] private bool multiplayer;
    [SerializeField] private bool p1Turn = true;

    // Pet object information
    [SerializeField] private Pet currPet;
    [SerializeField] private List<Pet> currPets;
    [SerializeField] private int petIndex;

    // Human object information
    [SerializeField] private Human currHuman;
    [SerializeField] private List<Human> currHumans;
    [SerializeField] private int humanIndex;

    // Pet object information
    [SerializeField] private Item currItem;
    [SerializeField] private List<Item> currItems;
    [SerializeField] private int itemIndex;

    // Controls
    // P1 Pet Controls (w - previous, s - next)
    [SerializeField] private KeyCode p1PrevKey;
    [SerializeField] private KeyCode p1NextKey;

    // P1 Item Controls (a - previous,  - next, e - use item)
    [SerializeField] private KeyCode prevItemKey;
    [SerializeField] private KeyCode nextItemKey;
    [SerializeField] private KeyCode useItemKey;

    // P1 Attack Controls (space - attack)
    [SerializeField] private KeyCode p1AttackKey;

    // P2 Human Controls (up - previous, down - next)
    [SerializeField] private KeyCode p2PrevKey;
    [SerializeField] private KeyCode p2NextKey;

    // P2 Attack Controls (rightshift - attack)
    [SerializeField] private KeyCode p2AttackKey;

    // Turn Text
    [SerializeField] private Text turnText;

    // Victory Checks
    [SerializeField] private bool petWin;
    [SerializeField] private bool humanWin;

    // Delay Attacks
    [SerializeField] private bool isAttacking;
    [SerializeField] private float aiDelay;
    [SerializeField] private float playerDelay;

    // AI Checks
    //I'll store the number of humans in the list. As each one enters the danger state, the number will decrease, and characters will switch.
    //When it hits zero, humanDanger will be true. Once this occurs, gameplay will proceed as normal.
    //[SerializeField] private bool humanDanger = false;
    [SerializeField] private int safeHumans;
    [SerializeField] private bool skipTurn = false;
    private int player1Switches = 0;
    private int aiSwitches = 0;
    private int humanSwitches = 0;
    //I will use this to implement the switch limit and reset it in certain areas

    // UI
    [SerializeField] private PauseUI pauseUI;
    [SerializeField] private InfoUI infoUI;
    [SerializeField] private ItemUI itemUI;

    // Author(s): Thomas Wang
    // Start is called before the first frame update
    void Start() {
        //need to fill pets array and humans array with all pets and humans in current fight
        currPet = currPets[petIndex];
        safeHumans = currHumans.Count;
        for (int i = 0; i < currPets.Count; i++) {
            if (currPets[i] != currPet) {
                currPets[i].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.6f);
            }
        }
        currHuman = currHumans[humanIndex];
        for (int i = 0; i < currHumans.Count; i++) {
            if (currHumans[i] != currHuman) {
                currHumans[i].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.6f);
            }
        }
        if (!multiplayer) {
            currItem = currItems[itemIndex];
            itemUI.SetPotionUI(currItem);
            for (int i = 0; i < currItems.Count; i++)
            {
                if (currItems[i] != currItem) {
                    currItems[i].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.6f);
                }
            }
        }
    }

    // Author(s): Thomas Wang, Ashley Sun
    // Update is called once per frame
    void Update() {
        if (!pauseUI.IsPaused() && !isAttacking) {
            if (!multiplayer) {
                // The scene is singleplayer
                if (p1Turn) {
                    if (Input.GetKeyDown(p1PrevKey)) {
                        PreviousPet();
                    } else if (Input.GetKeyDown(p1NextKey)) {
                        NextPet();
                    } else if (Input.GetKeyDown(prevItemKey)) {
                        PreviousItem();
                        itemUI.SetPotionUI(currItem);
                    } else if (Input.GetKeyDown(nextItemKey)) {
                        NextItem();
                        itemUI.SetPotionUI(currItem);
                    } else if (Input.GetKeyDown(useItemKey) && currItem != null) {
                        //pass the item the combat manager so the item's actions can be carried out
                        currItem.UseItem(this);
                        infoUI.newPotionText(currPet, currItem);
                        RemoveItem();
                        itemUI.SetPotionUI(currItem);
                        // since a player can use an item and attack, we don't call humanAttack() afterwards
                        //humanAttack();
                    } else if (Input.GetKeyDown(p1AttackKey)) {
                        //Debug.Log("space button pressed");
                        StartCoroutine(PetAttack());
                        p1Turn = false;
                    }
                } else {
                    HumanSafety();
                    StartCoroutine(HumanAttack());
                    p1Turn = true;

                }
            } else {
                // The scene is multiplayer
                // Player 1's turn
                if (p1Turn) {
                    if (Input.GetKeyDown(p1PrevKey)) {
                        PreviousPet();
                    } else
                    if (Input.GetKeyDown(p1NextKey)) {
                        NextPet();
                    } else
                    if (Input.GetKeyDown(p1AttackKey)) {
                        StartCoroutine(PetAttack());
                        p1Turn = false;
                    }
                } else {
                    // Player 2's turn
                    if (Input.GetKeyDown(p2PrevKey)) {
                        PreviousHuman();
                    } else
                    if (Input.GetKeyDown(p2NextKey)) {
                        NextHuman();
                    } else
                    if (Input.GetKeyDown(p2AttackKey)) {
                        StartCoroutine(HumanAttack());
                        p1Turn = true;
                    }
                }
            }
        }
        
    }

    public Pet getCurrPet()
    {
        return currPet;
    }

    public List<Pet> getCurrPets()
    {
        return currPets;
    }

    public Human getCurrHuman()
    {
        return currHuman;
    }

    public List<Human> getCurrHumans()
    {
        return currHumans;
    }

    public bool getPetWin()
    {
        return petWin;
    }

    public bool getHumanWin()
    {
        return humanWin;
    }

    public void setSkipTurn(bool val)
    {
        skipTurn = true;
    }

    // Author(s): Thomas Wang, Daniel J. Garcia
    // goes to previous Pet if p1PrevKey ("w") is pressed
    void PreviousPet() {
        //Debug.Log("previous function");
        if (petIndex > 0 && player1Switches < 2) {
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            petIndex--;
            player1Switches++;
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }
    
    // Author(s): Thomas Wang, Daniel J. Garcia
    // goes to next Pet if p1NextKey ("s") is pressed
    void NextPet() {
        //Debug.Log("next function");
        if (petIndex < (currPets.Count - 1) && player1Switches < 2) {
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            petIndex++;
            player1Switches++;
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }

    // Author(s): Ashley Sun, Daniel J. Garcia
    // goes to previous uman if p2PrevKey ("up") is pressed
    void PreviousHuman() {
        //Debug.Log("previous function");
        if (humanIndex > 0 && humanSwitches < 2) {
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            humanIndex--;
            humanSwitches++;
            currHuman = currHumans[humanIndex];
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }
    
    // Author(s): Ashley Sun, Daniel J. Garcia
    void NextHuman() {
        //Debug.Log("next function");
        if (humanIndex < (currHumans.Count - 1) && humanSwitches < 2) {
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            humanIndex++;
            humanSwitches++;
            currHuman = currHumans[humanIndex];
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
        // goes to next Human if p2PrevKey ("down") is pressed
    }

    // Author(s): Logan Mikulski
    // goes to next Item if prevItemKey ("a") is pressed
    void PreviousItem() {
        if (itemIndex > 0) {
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            itemIndex--;
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            currItem = currItems[itemIndex];
        }
    }

    // Author(s): Logan Mikulski
    // goes to next Item if nextItemKey ("d") is pressed
    void NextItem() {
        if (itemIndex < (currItems.Count - 1)) {
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            itemIndex++;
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            currItem = currItems[itemIndex];
        }
    }

    // Author: Thomas Wang, Ashley Sun
    // facilitates attack and updates the text, also implements a delay to make combat not so instantaneous
    private IEnumerator PetAttack() {
        //Debug.Log(currPet.type + " is attacking " + currHuman.type);
        isAttacking = true;
        //currPet.AttackEnemy(currHuman);
        infoUI.newAttackText(currPet, currHuman, currPet.AttackEnemy(currHuman));
        player1Switches = 0;
        if (currHuman.getIsDead()) {
            RemoveHuman();
        }
        if (currHumans.Count == 0) {
            petWin = true;
            pauseUI.Win();
        }
        yield return new WaitForSeconds(playerDelay);
        if (!skipTurn) {
            if (!multiplayer) {
                turnText.text = "Enemy's Turn";
            } else {
                turnText.text = "Player 2's Turn";
            }
            turnText.alignment = TextAnchor.MiddleRight;
        }
        
        isAttacking = false;
    }

    // Author: Thomas Wang, Ashley Sun
    // facilitates attack and updates the text, also implements a delay to make combat not so instantaneous
    private IEnumerator HumanAttack() {
        isAttacking = true;
        //Debug.Log(currHuman.type + " is attacking " + currPet.type);
        if (!multiplayer) {
            yield return new WaitForSeconds(aiDelay);
        }
        if (skipTurn == false) {
            //currHuman.AttackEnemy(currPet);
            infoUI.newAttackText(currHuman, currPet, currHuman.AttackEnemy(currPet));
            if (currPet.getIsDead()) {
                RemovePet();
            }
            if (currPets.Count == 0) {
                humanWin = true;
                pauseUI.Win();
            }
            yield return new WaitForSeconds(playerDelay);
            turnText.text = "Player 1's Turn";
            turnText.alignment = TextAnchor.MiddleLeft;
        } else {
            skipTurn = false;
        }

        isAttacking = false;
    }

    // Author(s): Daniel J. Garcia
    //Ensures that the current human isn't in the danger state, and if all humans are in danger, no effect is taken.
    private void HumanSafety()
    {
        if (safeHumans > 0 && (currHuman.isInCaution() == true))
        {
            if (currHuman.isInDanger() == true || currHuman.getIsMatchedWell() == false)
            {
                safeHumans -= 1;
                while (currHuman.isInCaution() && safeHumans > 0)
                {

                    //switches the human character
                    if (humanIndex == currHumans.Count)
                    {
                        currHumans[humanIndex].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.6f);
                        humanIndex = 0;
                        currHuman = currHumans[humanIndex];
                        currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
                    }
                    else
                    {
                        currHumans[humanIndex].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.6f);
                        humanIndex += 1;
                        currHuman = currHumans[humanIndex];
                        currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
                    }
                }
            }

        }
    }


    // Author(s): Thomas Wang
    // used to remove a pet from the list when the pet dies, allowing the right pet to be selected afterwards
    private void RemovePet() {
        infoUI.newFaintText(currPet);
        // only one pet remaining
        if (currPets.Count == 1) {
            currPet.gameObject.SetActive(false);
            currPets.Remove(currPet);
            currPet = null;

        } else {
            currPet.gameObject.SetActive(false);
            currPets.Remove(currPet);
            // more than one pet remaining, need to check if we are removing the last pet of the list, then decrement the index before reassigning the new pet
            if (petIndex == currPets.Count) {
                petIndex--;
            }
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }

    // Author(s): Thomas Wang
    // used to remove a human from the list when the human dies, allowing the right human to be selected afterwards
    private void RemoveHuman() {
        infoUI.newFaintText(currHuman);
        // only one pet remaining
        if (currHumans.Count == 1) {
            currHuman.gameObject.SetActive(false);
            currHumans.Remove(currHuman);
            currHuman = null;
        } else {
            currHuman.gameObject.SetActive(false);
            currHumans.Remove(currHuman);
            // more than one pet remaining, need to check if we are removing the last pet of the list, then decrement the index before reassigning the new pet
            if (humanIndex == currHumans.Count) {
                humanIndex--;
            }
            currHuman = currHumans[humanIndex];
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);

        }
    }

    // Author(s): Thomas Wang
    private void RemoveItem()
    {

        // only one item remaining
        if (currItems.Count == 1)
        {
            currItem.gameObject.SetActive(false);
            currItems.Remove(currItem);
            currItem = null;
        }
        else
        {
            currItem.gameObject.SetActive(false);
            currItems.Remove(currItem);
            // more than one pet remaining, need to check if we are removing the last pet of the list, then decrement the index before reassigning the new pet
            if (itemIndex == currItems.Count)
            {
                itemIndex--;
            }
            currItem = currItems[itemIndex];
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }
}

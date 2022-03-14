using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author(s): Thomas Wang, Logan Mikulski, Daniel J. Garcia
public class CombatManager : MonoBehaviour {
    // Multiplayer Check
    [SerializeField] private bool multiplayer;
    [SerializeField] private bool p1Turn = true;
    [SerializeField] private LevelManager lm;
    // Level Manager


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
    // I'll store the number of humans in the list. As each one enters the danger state, the number will decrease, and characters will switch.
    // When it hits zero, humanDanger will be true. Once this occurs, gameplay will proceed as normal.
    [SerializeField] private int safeHumans;
    [SerializeField] private bool skipTurn = false;
    private int player1Switches = 0;
    private int humanSwitches = 0;
    //I will use this to implement the switch limit and reset it in certain areas

    // UI
    [SerializeField] private HumanUI humanUI;
    [SerializeField] private PetUI petUI;
    [SerializeField] private VictoryUI victoryUI;
    [SerializeField] private PauseUI pauseUI;
    [SerializeField] private InfoUI infoUI;
    [SerializeField] private ItemUI itemUI;
    [SerializeField] private KeyUI keyUI;

    // Author(s): Thomas Wang
    // Start is called before the first frame update
    void Start() {
        //need to fill pets array and humans array with all pets and humans in current fight
        currPet = currPets[petIndex];
        keyUI.UpdateP1KeysPosition(currPet);
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
        } else {
            keyUI.UpdateP2KeysPosition(currHuman);
            keyUI.TurnOffP2Keys();
        }
        petUI.UpdateText(currPet);
        humanUI.UpdateText(currHuman);
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
    public Item getCurrItem() {
        return currItem;
    }

    public List<Item> getCurrItems() {
        return currItems;
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

    public bool getIsPaused() {
        return pauseUI.IsPaused();
    }

    public bool getisAttacking() {
        return isAttacking;
    }
    
    public bool getP1Turn() {
        return p1Turn;
    }



    // Author(s): Thomas Wang
    // goes to previous Pet if p1PrevKey ("w") is pressed
    public void PreviousPet() {
        if (petIndex > 0 && player1Switches < 2) {
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            petIndex--;
            player1Switches++;
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            if (player1Switches == 2) {
                keyUI.TurnOffP1Keys();
            } else {
                keyUI.TurnOnP1Keys();
            }
        }
        petUI.UpdateText(currPet);
        keyUI.UpdateP1KeysPosition(currPet);
    }

    // Author(s): Thomas Wang
    // goes to next Pet if p1NextKey ("s") is pressed
    public void NextPet() {
        if (petIndex < (currPets.Count - 1) && player1Switches < 2) {
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            petIndex++;
            player1Switches++;
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            if (player1Switches == 2) {
                keyUI.TurnOffP1Keys();
            } else {
                keyUI.TurnOnP1Keys();
            }
        }

        petUI.UpdateText(currPet);
        keyUI.UpdateP1KeysPosition(currPet);
    }

    // Author(s): Thomas Wang, Daniel J. Garcia
    // goes to previous Human if p2PrevKey ("up") is pressed
    public void PreviousHuman() {
        if (humanIndex > 0 && humanSwitches < 2) {
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            humanIndex--;
            humanSwitches++;
            currHuman = currHumans[humanIndex];
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            if (!multiplayer) {
                if (humanSwitches == 2) {
                    keyUI.TurnOffP2Keys();
                } else {
                    keyUI.TurnOnP2Keys();
                }
            }
        }
        humanUI.UpdateText(currHuman);
        keyUI.UpdateP2KeysPosition(currHuman);
    }

    // Author(s): Thomas Wang, Daniel J. Garcia
    public void NextHuman() {
        if (humanIndex < (currHumans.Count - 1) && humanSwitches < 2) {
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            humanIndex++;
            humanSwitches++;
            currHuman = currHumans[humanIndex];
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            if (!multiplayer) {
                if (humanSwitches == 2) {
                    keyUI.TurnOffP2Keys();
                } else {
                    keyUI.TurnOnP2Keys();
                }
            }
        }
        // goes to next Human if p2PrevKey ("down") is pressed
        humanUI.UpdateText(currHuman);
        keyUI.UpdateP2KeysPosition(currHuman);
    }

    // Author(s): Thomas Wang
    // goes to next Item if prevItemKey ("a") is pressed
    public void PreviousItem() {
        if (itemIndex > 0) {
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            itemIndex--;
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            currItem = currItems[itemIndex];
        }
        itemUI.SetPotionUI(currItem);
    }

    // Author(s)(s): Thomas Wang
    // goes to next Item if nextItemKey ("d") is pressed
    public void NextItem() {
        if (itemIndex < (currItems.Count - 1)) {
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            itemIndex++;
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            currItem = currItems[itemIndex];
        }
        itemUI.SetPotionUI(currItem);
    }

    // Author(s): Thomas Wang
    // facilitates attack and updates the text, also implements a delay to make combat not so instantaneous
    public IEnumerator PetAttack() {
        keyUI.TurnOffP1Keys();
        isAttacking = true;
        infoUI.newAttackText(currPet, currHuman, currPet.AttackEnemy(currHuman));
        humanUI.UpdateText(currHuman);
        player1Switches = 0;
        if (currHuman.getIsDead()) {
            RemoveHuman();
        }
        if (currHumans.Count == 0) {
            petWin = true;
            victoryUI.PetVictory();
            if (!multiplayer) {
                StartCoroutine(ReturnToOverworld());
            } else {
                StartCoroutine(ReturnToMainMenu());
            }
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
        if (multiplayer) {
            keyUI.TurnOnP2Keys();
        }
        p1Turn = false;

    }

    // Author(s): Thomas Wang
    // facilitates attack and updates the text, also implements a delay to make combat not so instantaneous
    public IEnumerator HumanAttack() {
        keyUI.TurnOffP2Keys();
        isAttacking = true;
        if (!multiplayer) {
            yield return new WaitForSeconds(aiDelay);
        }
        if (skipTurn == false) {
            infoUI.newAttackText(currHuman, currPet, currHuman.AttackEnemy(currPet));
            petUI.UpdateText(currPet);
            humanSwitches = 0;
            if (currPet.getIsDead()) {
                RemovePet();
            }
            if (currPets.Count == 0) {
                humanWin = true;
                victoryUI.HumanVictory();
                StartCoroutine(ReturnToMainMenu());
            }
            yield return new WaitForSeconds(playerDelay);
            turnText.text = "Player 1's Turn";
            turnText.alignment = TextAnchor.MiddleLeft;
        } else {
            skipTurn = false;
        }

        isAttacking = false;
        keyUI.TurnOnP1Keys();
        p1Turn = true;

    }

    // Author(s): Thomas Wang
    public IEnumerator AIAttack() {
        isAttacking = true;
        yield return new WaitForSeconds(aiDelay);
        if (skipTurn == false) {
            infoUI.newAttackText(currHuman, currPet, currHuman.AttackEnemy(currPet));
            petUI.UpdateText(currPet);
            humanSwitches = 0;
            if (currPet.getIsDead()) {
                RemovePet();
            }
            if (currPets.Count == 0) {
                humanWin = true;
                victoryUI.HumanVictory();
                StartCoroutine(ReturnToMainMenu());
            }
            yield return new WaitForSeconds(aiDelay);
            turnText.text = "Player 1's Turn";
            turnText.alignment = TextAnchor.MiddleLeft;
        } else {
            skipTurn = false;
        }

        isAttacking = false;
        keyUI.TurnOnP1Keys();
        p1Turn = true;

    }

    // Author(s): Thomas Wang
    public void UseItem() {
        currItem.UseItem(this);
        infoUI.newPotionText(currPet, currItem);
        RemoveItem();
        if (currItem != null) {
            itemUI.SetPotionUI(currItem);
        } else {
            itemUI.EmptyPotionUI();
        }
        petUI.UpdateText(currPet);

    }

    // Author(s): Daniel J. Garcia
    void AISwitch()
    {
        if (humanIndex == (currHumans.Count-1))
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
        humanUI.UpdateText(currHuman);
    }

    // Author(s): Daniel J. Garcia
    //Ensures that the current human isn't in the danger state, and if all humans are in danger, no effect is taken.
    public void HumanSafety()
    {
        if (safeHumans > 0 && (currHuman.isInCaution() == true))
        {
            //checks for caution/danger state. If ai is in caution but the matchup is ideal, they remain. Otherwise, they switch characters
            if (currHuman.isInDanger() == true || currHuman.getMatchState() !=2)
            {
                safeHumans -= 1;
                while (currHuman.isInCaution() && safeHumans > 0)
                {
                    //switches the human character
                    AISwitch();
                }
            }

        }
    }

    public void humanSwitchStrategy()
    {
        if (currHuman.getMatchState() != 2)
        {
            AISwitch();
        }
        if (currHuman.getMatchState() == 1)
        {
            AISwitch();
        }
    }


    // Author(s): Thomas Wang
    // used to remove a pet from the list when the pet dies, allowing the right pet to be selected afterwards
    void RemovePet() {
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
    void RemoveHuman() {
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
    void RemoveItem()
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

    private IEnumerator ReturnToOverworld() {
        yield return new WaitForSeconds(1.0f);
        lm.ReturnToOverworld();
    }
    private IEnumerator ReturnToMainMenu() {
        yield return new WaitForSeconds(1.0f);
        lm.LoadMainMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang, Logan Mikulski, Daniel J. Garcia
public class CombatManager : MonoBehaviour {
    [SerializeField] private Pet currPet;
    [SerializeField] private List<Pet> currPets;
    [SerializeField] private int petIndex;

    [SerializeField] private Human currHuman;
    [SerializeField] private List<Human> currHumans;
    [SerializeField] private int humanIndex;

    [SerializeField] private Item currItem;
    [SerializeField] private List<Item> currItems;
    [SerializeField] private int itemIndex;

    [SerializeField] private string nextKey = "s";
    [SerializeField] private string prevKey = "w";
    [SerializeField] private string nextItemKey = "d";
    [SerializeField] private string prevItemKey = "a";
    [SerializeField] private string useItemKey = "e";
    [SerializeField] private string attackKey = "space";

    [SerializeField] private bool petWin = false;
    [SerializeField] private bool humanWin = false;
    //I'll store the number of humans in the list. As each one enters the danger state, the number will decrease, and characters will switch.
    //When it hits zero, humanDanger will be true. Once this occurs, gameplay will proceed as normal.
    //[SerializeField] private bool humanDanger = false;
    [SerializeField] private int safeHumans;
    [SerializeField] private bool skipTurn = false;

    [SerializeField] private PauseUI pauseUI;

    // Author(s): Thomas Wang
    // Start is called before the first frame update
    void Start() {
        //need to fill pets array and humans array with all pets and humans in current fight
        currPet = currPets[petIndex];
        currHuman = currHumans[humanIndex];
        currItem = currItems[itemIndex];
        safeHumans = currHumans.Count;
        for (int i = 0; i < currPets.Count; i++) {
            if (currPets[i] != currPet) {
                currPets[i].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.6f);
            }
        }
        for (int i = 0; i < currHumans.Count; i++) {
            if (currHumans[i] != currHuman) {
                currHumans[i].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.6f);
            }
        }
        for (int i = 0; i < currItems.Count; i++)
        {
            if (currItems[i] != currItem) {
                currItems[i].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.6f);
            }
        }
    }

    // Author(s): Thomas Wang
    // Update is called once per frame
    void Update() {
        if (!pauseUI.IsPaused()) {
            if (Input.GetKeyDown(prevKey)) {
                Previous();
            } else 
            if (Input.GetKeyDown(nextKey)) {
                Next();
            } else
            if (Input.GetKeyDown(prevItemKey)) {
                PreviousItem();
            } else
            if (Input.GetKeyDown(nextItemKey)) {
                NextItem();
            } else
            if (Input.GetKeyDown(useItemKey) && currItem != null) {
                //pass the item the combat manager so the item's actions can be carried out
                currItem.UseItem(this);
                removeItem();
                // since a player can use an item and attack, we don't call humanAttack() afterwards
                //humanAttack();
            } else
            if (Input.GetKeyDown(attackKey)) {
                //Debug.Log("space button pressed");
                petAttack();
                humanSafety();
                humanAttack();
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

    // Author(s): Thomas Wang
    // goes to next pet if nextKey ("a") is pressed
    void Next() {
        //Debug.Log("next function");
        if (petIndex < (currPets.Count - 1)) {
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            petIndex++;
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }

    // Author(s): Thomas Wang
    //goes to previous pet if prevKey ("d") is pressed
    void Previous() {
        //Debug.Log("previous function");
        if (petIndex > 0) {
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            petIndex--;
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }



    // Author(s): Logan Mikulski
    void NextItem() {
        if (itemIndex < (currItems.Count - 1))
        {
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            itemIndex++;
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            currItem = currItems[itemIndex];
        }
    }

    // Author(s): Logan Mikulski
    void PreviousItem() {
        if (itemIndex > 0) {
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            itemIndex--;
            currItems[itemIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
            currItem = currItems[itemIndex];
        }
    }

    // facilitates attack (currently pet goes first, then human)
    // in the future, maybe implement speed stat and/or item usage 
    public void petAttack() {
        //Debug.Log(currPet.type + " is attacking " + currHuman.type);
        currPet.AttackEnemy(currHuman);
        if (currHuman.getIsDead()) {
            removeHuman();
        }
        if (currHumans.Count == 0) {
            petWin = true;
            pauseUI.Win();
            return;
        }

        
    }

    public void humanAttack() {
        //Debug.Log(currHuman.type + " is attacking " + currPet.type);
        if (skipTurn == false) {
            currHuman.AttackEnemy(currPet);
            if (currPet.getIsDead()) {
                removePet();
            }
            if (currPets.Count == 0) {
                humanWin = true;
                pauseUI.Win();
                return;
            }
        } else {
            skipTurn = false;
        }
    }

    // Author(s): Daniel J. Garcia
    //Ensures that the current human isn't in the danger state, and if all humans are in danger, no effect is taken.
    private void humanSafety()
    {
        if (safeHumans > 0 && (currHuman.isInDanger() == true))
        {
            safeHumans -= 1;

            while (currHuman.isInDanger() && safeHumans > 0)
            {
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


    // Author(s): Thomas Wang
    // used to remove a pet from the list when the pet dies, allowing the right pet to be selected afterwards
    private void removePet() {
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
    private void removeHuman() {
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
    private void removeItem()
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

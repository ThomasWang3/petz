using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author(s): Ashley Sun
public class MultiplayerCombatManager : MonoBehaviour {
    [SerializeField] private Pet currPet;
    [SerializeField] private List<Pet> currPets;
    [SerializeField] private int petIndex;

    [SerializeField] private Human currHuman;
    [SerializeField] private List<Human> currHumans;
    [SerializeField] private int humanIndex;

    [SerializeField] private string nextKey = "s";
    [SerializeField] private string prevKey = "w";
    [SerializeField] private string attackKey = "space";

    [SerializeField] private bool petWin = false;
    [SerializeField] private bool humanWin = false;
    [SerializeField] private bool skipTurn = false;
    [SerializeField] private bool p1Turn = true;

    [SerializeField] private Text playerText;

    [SerializeField] private PauseUI pauseUI;

    // Start is called before the first frame update
    void Start() {
        //need to fill pets array and humans array with all pets and humans in current fight
        currPet = currPets[petIndex];
        currHuman = currHumans[humanIndex];
        // currItem = currItems[itemIndex];
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
    }

    // Update is called once per frame
    void Update() {
        if (!pauseUI.IsPaused()) {
            if (p1Turn){
                if (Input.GetKeyDown(prevKey)) {
                    PreviousPet();
                } else 
                if (Input.GetKeyDown(nextKey)) {
                    NextPet();
                } else
                if (Input.GetKeyDown(attackKey)) {
                    petAttack();
                    p1Turn = false;
                    playerText.text = "Player 2's Turn";
                    playerText.alignment = TextAnchor.MiddleRight;
                }
            }
            else {
                if (Input.GetKeyDown(KeyCode.UpArrow)) {
                    PreviousHuman();
                } else 
                if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    NextHuman();
                } else
                if (Input.GetKeyDown(KeyCode.RightShift)) {
                    humanAttack();
                    p1Turn = true;
                    playerText.text = "Player 1's Turn";
                    playerText.alignment = TextAnchor.MiddleLeft;
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

    // goes to next pet if nextKey ("a") is pressed
    void NextPet() {
        //Debug.Log("next function");
        if (petIndex < (currPets.Count - 1)) {
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            petIndex++;
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }

    //goes to previous pet if prevKey ("d") is pressed
    void PreviousPet() {
        //Debug.Log("previous function");
        if (petIndex > 0) {
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            petIndex--;
            currPet = currPets[petIndex];
            currPets[petIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }

    // goes to next pet if nextKey ("a") is pressed
    void NextHuman() {
        //Debug.Log("next function");
        if (humanIndex < (currHumans.Count - 1)) {
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            humanIndex++;
            currHuman = currHumans[humanIndex];
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }

    //goes to previous pet if prevKey ("d") is pressed
    void PreviousHuman() {
        //Debug.Log("previous function");
        if (humanIndex > 0) {
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.6f);
            humanIndex--;
            currHuman = currHumans[humanIndex];
            currHumans[humanIndex].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.6f);
        }
    }


    // facilitates attack (currently pet goes first, then human)
    // in the future, maybe implement speed stat and/or item usage 
    public void petAttack() {
        // tentatively (both attack at the same time), player first
        // maybe implement animation between these in order to facilitate "turn order"
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
}

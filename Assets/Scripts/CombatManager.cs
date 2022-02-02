using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {
    [SerializeField] private Pet currPet;
    [SerializeField] private List<Pet> currPets;
    [SerializeField] private int petIndex;
    [SerializeField] private Human currHuman;
    [SerializeField] private List<Human> currHumans;
    [SerializeField] private int humanIndex;
    [SerializeField] private string nextKey = "d";
    [SerializeField] private string prevKey = "a";
    [SerializeField] private bool petWin = false;
    [SerializeField] private bool humanWin = false;

    // Start is called before the first frame update
    void Start() {
        //need to fill pets array and humans array with all pets and humans in current fight
        //petIndexMax = currPets.Count;
        //humanIndexMax = currHumans.Count;
        currPet = currPets[petIndex];
        currHuman = currHumans[petIndex];
        for (int i = 0; i < currPets.Count; i++) {
            //currPets[i].transform.position = new Vector3(50 , Screen.height / 2, 0);
            if (currPets[i] != currPet) {
                currPets[i].gameObject.SetActive(false);
            } else {
                currPets[i].gameObject.SetActive(true);
            }
        }
        for (int i = 0; i < currHumans.Count; i++) {
            //currHumans[i].transform.position = new Vector3(FindObjectOfType<Camera>().transform.position.x - 50, Screen.height / 2 / 2, 0);
            if (currHumans[i] != currHuman) {
                currHumans[i].gameObject.SetActive(false);
            } else {
                currHumans[i].gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(prevKey)) {
            //Debug.Log("A key pressed");
            previous();
        }
        if (Input.GetKeyDown(nextKey)) {
            //Debug.Log("D key pressed");
            next();
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

    //goes to next pet if nextKey is pressed
    void next() {
        //Debug.Log("next function");
        if (petIndex < (currPets.Count - 1)) {
            petIndex++;
            currPet.gameObject.SetActive(false);
            currPet = currPets[petIndex];
        } else {
            //do nothing
        }
    }

    //goes to previous pet if prevKey is pressed
    void previous() {
        //Debug.Log("previous function");
        if (petIndex > 0) {
            petIndex--;
            currPet.gameObject.SetActive(false);
            currPet = currPets[petIndex];
        } else {
            //do nothing
        }
    }

    //attacks and accommodates for type matchups 
    public void attack() {
        // tentatively (both attack at the same time), player first
        // maybe implement animation between these in order to facilitate "turn order"
        //Debug.Log(currPet.type + " is attacking " + currHuman.type);
        currPet.AttackEnemy(currHuman);
        if (currHuman.getIsDead()) {
            removeHuman();
        }
        if (currHumans.Count == 0) {
            petWin = true;
            return;
        }

        //Debug.Log(currHuman.type + " is attacking " + currPet.type);
        currHuman.AttackEnemy(currPet);
        if (currPet.getIsDead()) {
            removePet();
        }
        if(currPets.Count == 0) {
            humanWin = true;
            return;
        }
    }


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
        }
    }
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
        }
    }
}

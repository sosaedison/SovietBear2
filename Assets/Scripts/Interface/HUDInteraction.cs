using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HUDInteraction : MonoBehaviour {
	
	Health playerHealth;
	public GameObject Player;
	public GameObject HealthUI;
	public GameObject LevelPerkMenu;
    public GameObject pauseMenu;
    public GameObject gameOver;
	public Text HUDAmmo;
	public Slider XP;
	LevelManager levelManager;
	public int canLevel = 0;
	public List<GameObject> HeartPieces;
	int LastHeartPlaced = 0;
	public GameObject[] Quarters = new GameObject[4];
	public GameObject PreviousQuarter;
	RectTransform PreviousRect;
	GameObject NewQuarter;
	//Vector3[] DisplacementVectors = {new Vector3(0f,15f,0f), new Vector3(23f,0f,0f), new Vector3(0f,-15f,0f), new Vector3(15f,0f,0f)};
	Vector2[] DisplacementVectors = {new Vector2(0f,15f), new Vector2(23f,0f), new Vector2(0f,-15f), new Vector2(15f,0f)};
	Vector3 PlaceHere;
	int maxHP = 0;
	public GameObject Outlineprefab;
	public GameObject PreviousOutline;
	GameObject NewOutline;
	Vector2 OutlineDisplacement = new Vector2 (38f,0f);
	int MaxExp = 60;
	int currentExp;
	int BearLvl = 1;
	public GameObject LevelReminder;
	// From TL counter clockwise

	// Use this for initialization
	void OnEnable () 
	{
        levelManager = FindObjectOfType<LevelManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = Player.GetComponent<Health>();
		for(int i=0; i<playerHealth.max; i++)
		{
			PreviousRect = PreviousQuarter.GetComponent<RectTransform>();
			int index = (LastHeartPlaced + 1) % 4;
			NewQuarter = (GameObject) Instantiate(Quarters[index], PreviousRect.anchoredPosition + DisplacementVectors[index], Quaternion.identity);
			NewQuarter.transform.SetParent(HealthUI.transform, false);
			HeartPieces.Add(NewQuarter);
			PreviousQuarter = NewQuarter;
			LastHeartPlaced++;
		}
	}

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
	// Update is called once per frame
	void Update () 
	{
		//Heart Display
		if (playerHealth.current > LastHeartPlaced)
		{
			for(int i=0; i<(playerHealth.current); i++)
			{
				int index = (LastHeartPlaced + 1) % 4;
				NewQuarter = (GameObject) Instantiate(Quarters[index], PreviousRect.anchoredPosition + DisplacementVectors[index], Quaternion.identity);
				NewQuarter.transform.SetParent(HealthUI.transform, false);
				HeartPieces.Add(NewQuarter);
				PreviousQuarter = NewQuarter;
				LastHeartPlaced++;
			}
		}
		if (playerHealth.current < LastHeartPlaced)
		{
			Destroy(PreviousQuarter);
			HeartPieces.Remove(HeartPieces.Last());
			LastHeartPlaced--;
			PreviousQuarter = HeartPieces.Last();
		}
		if (playerHealth.max > maxHP)
		{
			NewOutline = (GameObject) Instantiate(Outlineprefab, PreviousOutline.GetComponent<RectTransform>().anchoredPosition + OutlineDisplacement, Quaternion.identity);
			NewOutline.transform.SetParent(HealthUI.transform, false);
			NewOutline.transform.SetAsFirstSibling();
			PreviousOutline = NewOutline;
			maxHP += 4;
		}

		// Ammo Display
		Weapon currentWeapon = Player.GetComponent<Management>().weapons[Player.GetComponent<Management>().WeaponSlot].GetComponent<Weapon>();
		//HUDAmmo.text = currentWeapon.ammo.ToString()+"/"+currentWeapon.maxAmmo.ToString();
		if (currentWeapon.transform.name == "ActualSword")
		{
			HUDAmmo.text = "N/A";
		}
		else if (currentWeapon.transform.name !="ActualSword")
		{
			HUDAmmo.text = currentWeapon.ammo.ToString()+"/"+currentWeapon.maxAmmo.ToString();
		}
		//XP Display
		currentExp = levelManager.currentExp;
		XP.maxValue = MaxExp;
		XP.value = currentExp;
		if (currentExp >= MaxExp)
		{
			levelManager.currentExp = currentExp-MaxExp;
			BearLvl++;
			MaxExp = BearLvl*60;
			canLevel++;
		}
		if (canLevel > 0 && Input.GetButtonDown("PerkScreen"))
		{
            levelManager.Pause();
            LevelPerkMenu.SetActive(!LevelPerkMenu.activeInHierarchy);
		}
		if (canLevel > 0)
		{
			LevelReminder.SetActive(true);
		}
		else if (canLevel <= 0)
		{
			LevelReminder.SetActive(false);
		}

        if (Input.GetButtonDown("Pause"))
        {
            pauseMenu.SetActive(LevelManager.isPaused());
        }
	}
	// TL to BL is x,y-15. BL to BR is (x+15,y). BR to TR (is x,y+15). TR to TL is (x+23,y)
}

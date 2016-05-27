using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AddPerk : MonoBehaviour {

	public GameObject Player;
	public Canvas HUD;
	Health PlayerHealth;
	GameObject PerkMenu;
	[SerializeField] GameObject[] buttons;
	int selectedButton = -1;
	// Use this for initialization
	void Start () 
	{
		PlayerHealth = Player.GetComponent<Health>();
		PerkMenu = gameObject;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			selectedButton += 1;
			if (selectedButton >= buttons.Length)
			{
				selectedButton = 0;
			}
			EventSystem.current.SetSelectedGameObject(buttons[selectedButton]);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			selectedButton -= 1;
			if (selectedButton < 0)
			{
				selectedButton = buttons.Length - 1;
			}
			EventSystem.current.SetSelectedGameObject(buttons[selectedButton]);
		}
	}
	public void AddHP ()
	{
		PlayerHealth.max += 4;
		HUD.GetComponent<HUDInteraction>().canLevel--;
		PerkMenu.active = false;
	}
	public void AddAmmo ()
	{
		foreach (Weapon shootyMcBangBang in Player.GetComponentsInChildren<Weapon>())
		{
			shootyMcBangBang.maxAmmo += 10;
			HUD.GetComponent<HUDInteraction>().canLevel--;
			PerkMenu.active = false;
		}
	}
}

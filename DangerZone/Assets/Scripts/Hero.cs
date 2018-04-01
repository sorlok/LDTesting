using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
	public GameObject HeroCube;
	public GameObject HeroShield;

	//Movement Tech
	private float heroMoveAmt = 0.2f;

	//Shield Attack
	private float shieldAttackSpeed = .2f; 
	private float shieldAttackReach = 5;
	private int shieldAttacking = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Move 
		int moveAmt = 0;
		if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))) {
			moveAmt -= 1;
		}
		if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) {
			moveAmt += 1;
		}
		if (moveAmt != 0) {
			Move (moveAmt);
		}

		//Shield
		if (Input.GetKey (KeyCode.J) && shieldAttacking == 0) {
			ShieldAttack ();
		}
		if (shieldAttacking != 0) {
			HandleShieldAttack();
		}
	}

	// dir = (-1, 0, 1) for left/none/right
	void Move (int dir) {
		HeroCube.transform.localPosition += new Vector3 (dir * heroMoveAmt, 0, 0);
	}

	void ShieldAttack () {
		shieldAttacking = 1;
	}

	void HandleShieldAttack () {
		//HeroShield
		if (shieldAttacking == 1) {
			//Move
			HeroShield.transform.localPosition += new Vector3 (shieldAttackSpeed, 0, 0);
			//Check
			if (HeroShield.transform.localPosition.x >= shieldAttackReach) {
				shieldAttacking *= -1;
			}
		} 
		else if (shieldAttacking == -1) {
			//Move
			HeroShield.transform.localPosition -= new Vector3(shieldAttackSpeed, 0, 0);
			//Check
			if (HeroShield.transform.localPosition.x <= (HeroCube.transform.localPosition.x + 1)) {
				shieldAttacking = 0;
				//Snap
				HeroShield.transform.localPosition = new Vector3 (1, 0, 0);
			}
		}

	}
}

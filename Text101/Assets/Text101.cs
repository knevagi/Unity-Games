using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text101 : MonoBehaviour {
	public Text text;
	private enum textcontrolller {cell,lock_0,bed,lock_1,mirror,free}
	private textcontrolller mystates;
	// Use this for initialization
	void Start () {
		mystates = textcontrolller.cell;
		
	}
	
	// Update is called once per frame
	void Update () {
		print (mystates);
		if (mystates == textcontrolller.cell) {
			cell_func ();
		} else if (mystates == textcontrolller.bed) {
			bed_func ();
		} else if (mystates == textcontrolller.lock_0) {
			lock_0_func ();
		} else if (mystates == textcontrolller.lock_1) {
			lock_1_func ();
		} else if (mystates == textcontrolller.mirror) {
			mirror_func ();
		} else if (mystates == textcontrolller.free) {
			free_func ();
		}
	}
	void cell_func(){
		text.text="You are in a cell. There is a bed,a mirror and the prison door\n" +
		"Press B to look under the bed;Press L to look at the lock;Press M" +
		" to look at the mirror";
		if (Input.GetKeyDown(KeyCode.B)) {
			mystates = textcontrolller.bed;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			mystates = textcontrolller.lock_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			mystates = textcontrolller.mirror;
		}
	}
	void bed_func(){
		text.text="Under the bed there are a few marbles and pieces some debris. Nothing can help me"+
				" Press R to return to your cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			mystates = textcontrolller.cell;
		}
	}
	void lock_0_func(){
		text.text="The lock is a keypad lock which will open with a password. There might"+
				" be some markings on the frequently pressed keys. If only i could see the keypad."+
				"\nPress R to return to the cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			mystates = textcontrolller.cell;
		}
	}
	void mirror_func(){
		text.text="Its a small handheld mirror that is attached to the wall.Now it would be possible to look at the keypad\n"+
				" Press T to take the mirror and go to the lock";
		if (Input.GetKeyDown(KeyCode.T)) {
			mystates = textcontrolller.lock_1;
		} 
	}
	void lock_1_func(){
		text.text="You place the mirror in such a way you can see the frequently typed keys"+
				"\nPress F to type the password";
		if (Input.GetKeyDown(KeyCode.F)) {
			mystates = textcontrolller.free;
		} 
	}
	void free_func(){
		text.text="You are free. Congratulations!!\nPress R to restart the game\nPress Q to quit";
		if (Input.GetKeyDown(KeyCode.R)) {
			mystates = textcontrolller.cell;
		}
		else if(Input.GetKeyDown(KeyCode.Q)){
			Application.Quit();
		}
	}






}

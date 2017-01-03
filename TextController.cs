using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text text;
	private enum States {
		house_0, house_1, house_2, house_3, sword, village_0, village_1, village_2, village_3, village_4, village_5, warning_0, warning_1,
		forest_0, forest_1, forest_2, forest_3, forest_4, forest_climb, forest_fight, tree_cave_0, tree_cave_1, master_sword, forest_done,
		mountain_0, 
		desert_0, 
		game_over_0, game_over_1	
	}
	private States myState;
	
	// Use this for initialization
	
	bool has_sword = false;
	bool has_mSword = false;
	bool has_mShield = false;
	
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		print 	(myState);
		print 	(has_sword);
		print 	(has_mSword);
		print 	(has_mShield);
		if 		(myState == States.house_0)			{house_0();}
		else if (myState == States.sword)			{sword();}
		else if (myState == States.house_1)			{house_1();}
		else if (myState == States.house_2)			{house_2();}
		else if (myState == States.house_3)			{house_3();}
		else if (myState == States.village_0) 		{village_0();}
		else if (myState == States.village_1) 		{village_1();}
		else if (myState == States.village_2) 		{village_2();}
		else if (myState == States.village_3) 		{village_3();}
		else if (myState == States.village_4) 		{village_4();}
		//else if (myState == States.village_5) 	{village_5();}
		
		else if (myState == States.forest_0) 		{forest_0();}
		else if (myState == States.forest_1) 		{forest_1();}
		else if (myState == States.forest_2) 		{forest_2();}
		else if (myState == States.forest_3) 		{forest_3();}
		else if (myState == States.forest_4) 		{forest_4();}
		else if (myState == States.forest_climb) 	{forest_climb();}
		else if (myState == States.forest_fight) 	{forest_fight();}
		else if (myState == States.tree_cave_0)		{tree_cave_0();}
		else if (myState == States.tree_cave_1)		{tree_cave_1();}
		else if (myState == States.forest_done) 	{forest_done();}
		
		//else if (myState == States.mountain_0)	{mountain_0();}
		//else if (myState == States.desert_0)		{desert_0();}
		else if (myState == States.game_over_0)		{game_over_0();}
		else if (myState == States.game_over_0)		{game_over_1();}
	}
	
	void StartGame () {
		myState = States.house_0;
		has_sword = false;
		has_mSword = false;
		has_mShield = false;
	}
	
	//// Village States //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	void house_0 () {
		text.text = "You wake after a restless night. Ever since the princesses kidnapping you havent " + 
					"been sleeping very well. From outside you hear the Town Crier yelling that the King " +
					"has proclaimed that any who aid in the rescue of the princess shall be rewarded." +
					"Mustering up all the courage that you possess, you decide that you would be the one to " +
					"save the princess.\n\n" +
					"The room you are in is simple, your [S]word and shield lay together in one corner and " +
					"a [D]oor leads to the village.";
		if 		(Input.GetKeyDown(KeyCode.S)) 							{myState = States.sword;}
		else if (Input.GetKeyDown(KeyCode.D)) 							{myState = States.village_0;}
	} 
	
	void house_1 () {
		text.text = "With your trusty sword and shield in hand, you are ready to set out to rescue the " +
					"Princess. Your only obstacle now? The [D]oor leading out into the village.";
		if		(Input.GetKeyDown(KeyCode.D)) 							{myState = States.village_0;}
	}
	
	void house_2 () {
		text.text = "Your house is exactly as you left it. Everything is in order, with your [S]word and shield " +
					"hanging above the fireplace. The [D]oor leading into the village being the only entance to the building.";
		if 		(Input.GetKeyDown(KeyCode.S))							{myState = States.sword;}
		else if (Input.GetKeyDown(KeyCode.D))							{myState = States.village_0;}
	}
	
	void house_3 () {
		text.text = "Your house is exactly as you left it. The [D]oor leading into the village being the only entance to the building.";
		if		(Input.GetKeyDown(KeyCode.D))							{myState = States.village_0;}
	}
	
	void sword () {
		text.text = "The sword and shield have been handed down in your family for generations. Your father " +
					"gave them to you as his father did before him. They aren't anything special, the sword is " +
					"simple and made out of Steel while the shield is made of wood with a leather strap." +
					"You could [T]ake it with you on your adventure to save the princess. Or just [L]eave it there.";
		if 		(Input.GetKeyDown(KeyCode.T)) 							{has_sword = true; myState = States.house_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 							{myState = States.house_0;}
	}
	
	void village_0 () {
		text.text = "The village you live in is quite small. There are a couple of houses, a shop, and three roads" +
					"leading out. The road north leads to a [F]orest, the road west leads to the [M]ountains, and " +
					"the road south leads to the [D]esert. The villain could have taken the Princess to any of these places. " + 
					"Or, you could head back into your [H]ouse.";
		if 		(Input.GetKeyDown(KeyCode.F) && has_sword == false) 	{myState = States.village_1;}
		else if (Input.GetKeyDown(KeyCode.F) && has_mSword == true)		{myState = States.forest_done;}
		else if (Input.GetKeyDown(KeyCode.F) && has_sword == true)		{myState = States.forest_0;}
		else if (Input.GetKeyDown(KeyCode.M) && has_mShield == false)	{myState = States.village_2;}
		else if (Input.GetKeyDown(KeyCode.M) && has_mShield == true)	{myState = States.mountain_0;}
		else if (Input.GetKeyDown(KeyCode.D) && has_mSword == false)	{myState = States.village_3;}
		else if (Input.GetKeyDown(KeyCode.D) && has_mSword == true)		{myState = States.desert_0;}
		else if (Input.GetKeyDown(KeyCode.H) && has_sword == false)		{myState = States.house_2;}
		else if (Input.GetKeyDown(KeyCode.H) && has_sword == true)		{myState = States.house_3;}
	}
	
	void village_1 () {
		text.text = "As you make your way to the forest, you are quickly stopped by the village elder, 'I hope you aren't " +
					"thinking of going into the forest unarmed. There are all manner of nasty creatures in that forest." + 
					"You'd best take something to defend yourself with!' You should return [H]ome to get your sword and shield.";
		if 		(Input.GetKeyDown(KeyCode.H))							{myState = States.house_2;}
	}
	
	void village_2 () {
		text.text = "You approach the base of the mountain, on the side of the road you notice a sign. 'WARNING! Dragon ahead " +
					"Wooden equipment not advised!' Lookng at your shield you decide that it is best that you head back to the " + 
					"[V]illage until you are better equipped.";
		if 		(Input.GetKeyDown(KeyCode.V))							{myState = States.village_0;}
	}
	
	void village_3 () {
		text.text = "As you approach the southern gate leading to the desert, you are stopped by a one of the towns gaurd. 'Whao! " +
					"Where do you think you're going?' He asks, looking you over. 'You are not nearly equipped well enough to be able " + 
					"to face the monesters of the desert. Why, I've heard that there are monsters made of stone! Something such as a simple " +
					"sword would stand no chance of cutting down. How about you come back when you have a better weapon.' With that, he " + 
					"points you back to the [V]illage.";
		if 		(Input.GetKeyDown(KeyCode.V))							{myState = States.village_0;}
	}
	
	void village_4 () {
		text.text = "You walk back into town a little worse for wear. Looking around, nothing has changed. And why should it? You were " +
					"gone for less than a day. You rest up in your house and then strike back out on your quest to be the one to save the " +
					"princess. The road north leads to a [F]orest, the road west leads to the [M]ountains, and the road south leads to " +
					"the [D]esert. The villain could have taken the Princess to any of these places. Or, you could head back into your [H]ouse.";
		if 		(Input.GetKeyDown(KeyCode.F) && has_sword == false) 	{myState = States.village_1;}
		else if (Input.GetKeyDown(KeyCode.F) && has_mSword == true)		{myState = States.forest_done;}
		else if (Input.GetKeyDown(KeyCode.F) && has_sword == true)		{myState = States.forest_0;}
		else if (Input.GetKeyDown(KeyCode.M) && has_mSword == false)	{myState = States.village_2;}
		else if (Input.GetKeyDown(KeyCode.M) && has_mSword == true)		{myState = States.mountain_0;}
		else if (Input.GetKeyDown(KeyCode.D) && has_mShield == false)	{myState = States.village_3;}
		else if (Input.GetKeyDown(KeyCode.D) && has_mShield == true)	{myState = States.desert_0;}
		else if (Input.GetKeyDown(KeyCode.H) && has_sword == false)		{myState = States.house_2;}
		else if (Input.GetKeyDown(KeyCode.H) && has_sword == true)		{myState = States.house_3;}
	}
	
	//// Forest Level States //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	void forest_0 () {
		text.text = "The sounds of the forest are almost calming. Birds chirp in the distance and you can occasionally catch a glimpse of some " +
					"of the local wildlife. You come to a fork in the road. Down the [L]eft path, you hear the rush of water crashing onto rocks. Down " + 
					"the [R]ight path, you notice that the woods become darker and much more forboding. There is no turning back now, you swallow hard " +
					"and must pick a path.";
		if 		(Input.GetKeyDown(KeyCode.L))							{myState = States.forest_1;}
		else if (Input.GetKeyDown(KeyCode.R))							{myState = States.forest_2;}
	}
	
	void forest_1 () {
		text.text = "As you approach the source of the noise, a waterfall comes into view. The path leads directly to its base where a series of rocks and " +
					"roots jutting our from the cliff face. It seems easy enough to [C]limb, or you could return to the [F]ork and take your chances down the " + 
					"path.";
		if 		(Input.GetKeyDown(KeyCode.C))							{myState = States.forest_climb;}
		else if (Input.GetKeyDown(KeyCode.F))							{myState = States.forest_0;}
	}
	
	void forest_2 () {
		text.text = "As the forest becomes thicker and thicker, less light is able to penetrate through the tree branches. The forest becomes very dark after " +
					"a while and you notice that the sounds of the forest have stopped all together. Suddenly, there is a rush of movement and a large creaure on " +
					"four legs comes bursting out of the brush. It has a large, bear-like body and a head that looks more like an owl. It stands up on to its " +
					"hind legs and comes crashing down at you. You could [D]odge out of the way, or attempt to [B]lock the creatures massive clawed feet with your " +
					"shield, but you must act quickly!";
		if 		(Input.GetKeyDown(KeyCode.D))							{myState = States.forest_fight;}
		else if (Input.GetKeyDown(KeyCode.B))							{myState = States.game_over_1;}	
	}
	
	void forest_3 () {
		text.text = "The root is slippery, but you managed to carefully climb up the rest of the waterfall without incident. Pushing forward, deeper into the forest, " +
					"you notice that all sound has stopped. Birds are no longer chirping, squirrels aren't running about. There is almost a serene calm all around. " +
					"You come to a clearing, wild flowers grow all around and in the middle of the clearing stands a tall, anienct looking tree. You take comfort in the " +
					"shade of the tree. At the base of the tree you notice a hole in the ground. The whole isn't very wide, but it looks very deep. Your curiosity gets " +
					"the best of you and you feel compelled to [I]nvestigate the hole in the ground.";
		if 		(Input.GetKeyDown(KeyCode.I))							{myState = States.tree_cave_0;}
	}
	
	void forest_4 () {
		text.text = "This time, as the beast comes crashing down on you, you brace yourself and shove your sword upwards, impaling the massive creature through the chest " +
					". With a guttaral moan, the creature collapses at your feet. Victorious, you clean yourself off as best you can and move deeper into the forest. " +
					"Eventually the forest begins to clear up and light finds its way to the forest floor once again. You come to a clearing, wild flowers grow all around " +
					"and in the middle of the clearing stands a tall, anienct looking tree. You take comfort in the shade of the tree. At the base of the tree you notice a " +
					"hole in the ground. The whole isn't very wide, but it looks very deep. Your curiosity gets the best of you and you feel compelled to [I]nvestigate the " +
					"hole in the ground.";
		if 		(Input.GetKeyDown(KeyCode.I))							{myState = States.tree_cave_0;}
	}
	
	void forest_climb () {
		text.text = "The climb is perilous, but you seem to have a grip on things. After a few minutes, however, the muscles in your hands begin to burn and ache. " +
					"You reach up again and firmly grab hold of a root when you notice to possible foot holds. You could climb up onto a [M]ossy covered rock, which " +
					"would offer you a quicker ascent. Or you could climb up onto a [R]oot that is slick from all the water, but the path looks to be longer.";
		if 		(Input.GetKeyDown(KeyCode.M))							{myState = States.game_over_0;}
		else if (Input.GetKeyDown(KeyCode.R))							{myState = States.forest_3;}
	}
	
	void forest_fight () {
		text.text = "Realizing that this creature could easily overpower you through size alone, you nimbly dodge out of the way and quickly go to work with your sword." +
					"You slash and stab at the beast, it reels back in pain and quickly back pedals to escape the onslaught. It sets its feet once more and rears up, " +
					"Having seen this trick once before you know how to defeat it this time. You could [R]un to back from where you came or you could [F]inish it.";
		if 		(Input.GetKeyDown(KeyCode.R))							{myState = States.forest_0;}
		else if (Input.GetKeyDown(KeyCode.F))							{myState = States.forest_4;}
	}
	
	void tree_cave_0 () {
		text.text = "You reach an arm into the hole and feel a vast amount of space underneath this tree. You push further and further in until you are buried all the " +
					"way up to your shoulder. There is suddenly a loud rumbling noise as the ground beneath you begins to shake. You feel yourself plunge, the ground " +
					"swallowing you whole. There is nothing, only darkness and the sound of your own heart beating heavily. You stumble around in the darkness for a moment, " +
					"barely able to keep your bearings, when a light comes into view. As you approach the light you see that it is shining down onto an object stuck in the " +
					"ground. You approach it and realize that a sword is stuck in the ground. The sword seems to be of the finest craftmanship that you have ever seen. " +
					"You [P]ull the sword from the ground and hold it up to the light.";
		if 		(Input.GetKeyDown(KeyCode.P))							{has_mSword = true; myState = States.tree_cave_1;}
	}
	
	void tree_cave_1 () {
		text.text = "The weight of the sword is properly distributed and the edge is surprisingly sharp. Happy with your luck, you decide that this new sword will help you in your " +
					"quest to save the princess. Securing your new weapon to your belt, you continue your search of the cave underneath the tree. It takes you quite a while, but you " +
					"eventually find an exit. As you exit you hear a familiar rush of water and notice the waterfall from before not too far from where you now stand. Looking at the " +
					"sky, you notice that the sun has started to set. You find the path and make your way back to the [V]illage.";
		if 		(Input.GetKeyDown(KeyCode.V))							{myState = States.village_4;}
	}
	
	void forest_done () {
		text.text = "You enter the forest and nothing seems to have changed. You hear the sound of birds chirping and water rushing. You figure that the princess probably isn't being " +
					"held here in the forest, so you decide to return to the [V]illage.";
		if 		(Input.GetKeyDown(KeyCode.V))							{myState = States.village_4;}
	}
	//// Mountain Level States //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	//// Desert Level States //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	//// Game Over States //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	void game_over_0 () {
		text.text = "You place your foot onto the moss covered rock and feel confident in your choice. Placeing all of your weight onto the rock you quickly realize " +
					"your mistake as your leg quickly shoots out from under you. The moss preventing you from getting a good foothold on the rock. You black out immediately " +
					"upon impact with the ground below. You wake up sometime later, back in your room, your sword and shield returned to their place above the fireplace.\n\n" +
					"[P]lay again";
		if 		(Input.GetKeyDown(KeyCode.P))							{StartGame();}
	}
	
	void game_over_1 () {
		text.text = "The creatures massive claws dig into your shield, and the weight of the creature bears down on you, pinning you in place between it and the ground. " +
					"The beak comes in from the side of your shield, you scream out in terror in what seems to be the last few moments of your life before you black out. " +
					"You wake up sometime later, back in your room, your sword and shield returned to their place above the fireplace.\n\n" +
					"[P]lay again";
		if 		(Input.GetKeyDown(KeyCode.P))							{StartGame();}
	}
}

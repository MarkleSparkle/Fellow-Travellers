# Design Ideas

## Potential Names (order of like-ness)
- Fellow Travellers
- Terrific Traffic
- Road Rage
- Traffic Simulator

## Basic premise
Change traffic lights through a (basic-complex) systems of traffic that allows all the cars to go through the system before the time runs out. Or allows a certain count of cars to go through the system with no crashes. 

## Game Functionality 
2D, top-down view traffic control game
Delay to lights? (Green...yellow...red)

- A small delay to allow the close vehicles to pass through on the yellow, yet quickly allow other cars to go
- Cars come onto the screen at "random" (based on difficulty or preset levels)?
- Swipe the direction of traffic to switch the traffic lights and allow the cars to pass through
- Cars get small bars that show up (like health bars) above their vehicles that increases as they wait. Once the red bar is full, it stays full and makes room for numbers to appear above the car. The numbers will pop up faster for the heaviest cars than the lighter ones but will starts small and make its way to a max value of 100 (after the max it hit, the vehicle only gives max values). This function reminds me of Wii Sports Resort wakeboarding where the points cap out, but crawl from 0 at the start
- The cars start out with a patience bar, the smaller cars patience bar decreases slower but when the "patience runs out" you start getting points

- Once a vehicle's "patience runs out" the game will display a speech bubble animation above their vehicle that has a few "#&@?$!" characters in it and play a cartoon-y mumbling sound to portray a frustrated person. At this point, the user should be able to easily identify that this specific car is angry, even if they weren't paying attention to the vehicle (the point is to get their attention).
- Menu with character bios that expands when you unlock a new character.

## Menu Functionality
When users want to chose a level to play, a ScrollView sort of layout allows users to scroll through different cities where levels are collected. Levels are traversed city-by-city in a linear, candy crush sort of way.Level deviantsOne-Way StreetsDifferent weather (snow increases stopping distance and overall anger)Speeds of the cars could be differentLevels could have roads intersecting with different speeds
- The faster the speed, the greater the point loss if they have to stop

The size (weight) of the vehicle determines
	* Stopping distance
	* Anger level/time stopped

- For example, small cars and motorcycles don't generate as many anger points as much and they have small stopping distances, but trucks and semis have large stopping distances and get more angry


## Special Characters
Special characters appear at random responding to different thresholds of spawning rates. Some of the special characters have special ways of interacting with the scene, the player, or other characters.

### Super Common
Super common vehicles appear very often and come in many different colors to silmulate _traffic_.

- Fellow Traveler - The most basic common car.
- The Van - (no description
- The Mom Van - (no description)
- The Hippy Van - (no description)
- The Truck - Another basic vehicle that appears very often in the game.

## Common
- Emergency vehicles - (a collection of them that act the same - police (the fastest of the emergency vehicles and have the least stopping distance], fire [always come in fleets of up to 3 or 4 - they are the slowest and worst stopping distance of the emergency vehicles), EMS [is between the police and fire truck in terms of stats) Give 3x+ the anger of a normal vehicle - they move faster but give fair warning before they enter the scene

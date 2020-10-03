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

## Tools
- Tools are unlockable, therefore not available right at the start of the (for purchase based on in-game points, or unlockable after certain levels)

- Timer - Add a timer to any light so that the light will change after a certain amount of time (or if it is manually changed before the timer reaches 0)
- Advanced Timer - You can have timers for each road (one side can be set to 15 seconds and one side could be set to 30 seconds) in the instances that one road is busier than the other (highway meets road)
- Pairing - Pair two or more lights together so that when gets changed (by a timer or manual adjustment) the other changes. This could be used when two lights are on the same street (then all the cars on that one street go through without stopping twice).
- Sensor - A sensor can be placed on a certain direction of a traffic light in. Cars stopped at the light with a sensor will trigger the lights to switch. This tool is costly as it removes a light from the user's focus.

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

## Uncommon
- Bus driver - Terrible stopping distance, but the cars stopped beside it will exponentially increase in anger over time (this could also be a music driver that blasts annoying music (rap, screamo, country) instead of the bus driver because that doesn't make as much sense to everyone
- Pedestrians - Pedestrians don't gain anger points if you make them wait, but once you let then cross, you will not be able to change the lights once they are crossing (parallel green light & walking sign). Pedestrians only in certain levels? (Once the group is impatient they just start crossing and forces all other traffic to stop and wait. The traffic that is forced to wait for illegally crossing pedestrians will incur 2x the anger points as long as they wait for [a pretty long time]).
- Speeder - characters that will be more angry (greater point loss) than the average driver if they have to stop, but you GAIN a bonus if you press a small camera button (WHILE they are in the intersection) - no bonus if you don't catch them
- Drag race - speeder and cops _(this need more fleshing out)_

## Rare
- Tom Cruise - on a motorbike and doesn't stop for anyone
- Twilight Dweller/European Tourist - drives on the wrong side of the road, but doesn't actually crash - meant to confuse the heck out of the user
- Limo - a super long vehicle.... like suuuuper long - they vary in how long they are so the user will never know how long it will be, but it usually is as long as an entire level - the limo is the same weight as the max (a semi or something), but a limo never gets angry (the people in the limo don't care).
- Duck Crossing - A mama and her ducklings are in desperate need to get to the greener grass. Cars must stop for the ducks, but cars effected by it will not be mad but rather will get out and take photos until they have crossed. This may give opportunities for users to capitalize on letting other cars through the intersection ahead.
- Stray dog (could also be hasenpfeffer) - stray dogs walk along the sidewalks and, similar to Duck Crossings, people in adjacent lanes will get out and feed it. Again, cars affected by this will not be angry, but it may cause havoc in other ways. 

## Super Rare
- Tractors - super rare, but they take up two lanes and go super slow to make sure they are spotted (in even more rare occurrences, sheep follow the tractor). [not sure how it will affect the game or other player that tail the tractor]
- Tanks - like a tractor takes up two lanes and goes super slow. BUT, make a tank wait too long and it will run over what's in front of it making a game over.

## Potential Characters
- Shopping Cart Convoy - takes up all lanes and force all cars to stop going through the traffic lights.
- Derailed Train - (no description)
- Zeno - (no description)
- Mongol Horde - (no description)
- Hot Air Balloon - The hot air balloon arrives and falls into the middle of the intersection which stops all traffic (or just traffic in certain lanes) before it is either cleaned up by the company in trucks, or it takes off again. 
- Hearse - Drives really slowly with a flashing light and forces all vehicles to stop on either side of the road.

## Effects
These effects appear on some levels and add a layer of difficulty to them, but also opportunity for the player to reduce points, catch speeders or have more time to make choices and react.

- Construction Zone - The speed limit on all roads is reduced and there are more speeders. If you catch a speeder you reep 2x the benefits
- Rush Hour - Everyone is slow, but everyone gets angrier much faster
- Bad weather - increases everyone's stopping distance.

## Lightning rounds
The lightning rounds appear once every 5 levels (assuming a story, path based game). The level is one star only, pass or fail. The transformers are struck by lightning and YOU need to direct the ID10T drivers for a certain amount of time before the traffic cop gets there to direct traffic.
- Stop cars and make them go faster to not let them collide
- Count down timer

## Scenes
- Day time
- Sunrise
- Sunset (headlights)
- Dark (headlights)
- Lightning Rounds (Night time, rain and occasional lightning)

## Traffic Light Configurations
These need more fleshing out in the future.

- Basic 2 lane 2 road
- 2 lane 2 road with right turn (merge) lanes
- 2 lane 1 road diverging
- Diverging diamond interchange
- other configurations of these with lanes missing, extra lanes added, just to mess with the user and make it more interesting
- Right lane might have a light something like the light on the bridge of Shawnessy Blvd


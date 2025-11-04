# the spire

this is a puzzle tower game
your goal is to climb the tower
doors can be unlocked by solving puzzles, using keys, or any number of strange ways to open a door

Game modes:
Speedrun: reach a tower checkpoint as fast as possible

Blitz: reach the highest checkpoint given a certain amount of time

Casual: explore the tower


Tower mechanics:
Doors
elevators



Door opening ideas:
unlocked
keyed door
multi keyed door
passcode door
bound door (close one to open another)
directional doors


Walls:
strength 1-10
walls can be broken with equivalent or higher level breaking power tools
higher level difference = faster breaking

wooden, stone, concrete walls

Blocks:

crate = contains preset items in it
(the spire is always the same spire)


Items:
Every player can pack discovered items at start of run

Items have weight and volume
weight = slows players down
volume = takes up space, inventory volume based instead of item number based

axe = can break wood walls quickly
pickaxe = can break wood and stone walls
drill = can break all walls slowly

grappling hook - allows players to climb on walls

Loot:
Coins - the default currency of the game, earned in all runs
Gems - the premium currency of the game, earned on pb runs, leaderboard positions, luck rolls
Upgrade Token - for high level upgrades

Cards: 
cards start undiscovered, they boost player stats in some way
once a card is discovered, it will be spawned into the deck with 0 stars. 
a zero star card has no effect, each additional star increases effect up to five stars.
cards can be upgraded with coins.
a sixth star can be gained by using an upgrade token and gems

Name: What the effect does
Effect: 0s, 1s, 2s, 3s, 4s, 5s, 6s

--COMMON CARDS-- (7) 
Mainly affects player stats

Name TBD: Increases running power
Effect: +0%, +10%, +20%, +30%, +40%, +50%, +75%  

Hurdler: Increases jump power
Effect: +0%, +5%, +10%, +15%, +20%, +25%, +35%  

Name TBD: Increases mining speed
Effect: +0%, +10%, +20%, +30%, +40%, +50%, +75%  

Brass Knuckles: Increases player fists base damage level
Effect: +0%, +100%, +150%, +200%, +250%, +300%, +400%

Panzer: Increases maximum health
Effect: +0%, +10%, +20%, +30%, +40%, +50%, +75%  



--RARE CARDS-- (4) 
Mainly affects higher level stats


Strength Training: Reduces effect of item weight on jump/run power
Effect: +0%, -5%, -10%, -15%, -20%, -25%, -35%  

Name TBD: Increases energy/health regeneration rate
Effect: +0%, +5%, +10%, +15%, +20%, +25%, +35%  




--LEGENDARY CARDS-- (3)
Directly simplifies gameplay

False Start: Decreases the final run time 
Effect: -0s, -0.5s, -1s, -1.5s, -2s, -2.5s, -4s

Compound Interest: Increases earnings of all currencies
Effect: +0%, +2%, +4%, +6%, +8%, +10%, +15%

Saving Grace: When about to die, chance for brief period of immortality. 
Effect: +0%, +5%, +10%, +15%, +20%, +25%, +35%  


--GAME FORMAT--
Casual: climb the tower with no time constraints
Rapid: 7 minutes, climb as high as possible
Blitz: 3 minutes, climb as high as possible, checkpoints net +30s time
Bullet: 1 minute, climb as high as possible, checkpoints net +10s time
Time Trial: reach a checkpoint as fast as possible

Player gets one respawn to the previous checkpoint in all modes except time trial unless disabled by badges


Badges:
badges increase the difficulty (and by association, coin payout) of a run.

--Leap badges - for all players seeking modified gameplay--



--Challenge badges - for seasoned players looking for an additional challenge--

Hardcore Mode
-No respawns
-No regeneration
-Increased enemy count
Multiplier: 2x

Nightmare Mode
-Checkpoints have no effect
-Significantly increased enemy count
-
Multiplier: 3x





---THE TOWER ITSELF---

(in order from bottom to top)

lore: 

Block Town: Start location
The point where player starts, several starting points

Sector 1, Spire Mall: secure, entirely safe
Subsections: food court, tech store, department store, main atrium


Sector 2: Remote Town, minimal risks
50-125m 
Subsections: Town hall, bridge, 
Risks: power failure, earthquake


Sector 3: Data Center
125-250m
Subsections: Server room, board room, security, cooling/power
Risks: power failure(high), detection, heat stroke

Sector 4: Warehouse
250-500m
Subsections: conveyors, shelves, robots, exit
Risks: fatigue(high), heat stroke, detection

Sector 5: Abandoned Offices
500-700m
Subsections: snack bar, elevator shaft, cubicles, board room
Risks: detection


Sector 6: Power Plant
700-900m
Subsections: the core, control room, mechanical room, 
10

Sector 7: The Laboratory
900-1200m
Subsections: makerspace, chemical lab, 
11

The Spire: top of the tower, no enemy risks but extremely challenging to navigate
1200-1500m
Subsections: segments of the spire
12

All risks: 
power failure: significantly darkens the tower for the rest of the run, no electronics work
earthquake: all bridges between subsections of the same level collapse
detection: all spire doors immediately lock, requiring a high enough level keycard to access
heat stroke: slowly take damage while in effect, causes permanent fatigue if sustained
fatigue: decreases moving, jumping, and attacking power. 

Reaching the top of the spire immediately ends a run
runs are scored by the highest reached checkpoint
all runs that reach the top of the spire are recorded on a leaderboard


--UI Improvements--

Info displays 
Aesthetic: displays only most crucial info, avoids using numbers
Balanced: displays helpful info, default
Technical: display as much info as possible


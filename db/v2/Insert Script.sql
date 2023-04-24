-- Insert data into Items table
INSERT INTO quetzal.Items (name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
"Armadura",
-5,
100,
-20,
-1,
0
);

INSERT INTO quetzal.Items (name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
"Escudo",
0,
50,
0,
-0.5,
0
);

INSERT INTO quetzal.Items (name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
"Posion Roja",
20,
-75,
30,
0,
0
);

INSERT INTO quetzal.Items (name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
"Posion Verde",
-25,
0,
50,
0.5,
0
);

INSERT INTO quetzal.Items (name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
"Sword",
40,
0,
-30,
0,
0
);

-- Insert data into Dialogs table
INSERT INTO quetzal.Dialogs (text) VALUES (
"Welcome to our village, traveler!"
);

INSERT INTO quetzal.Dialogs (text) VALUES (
"Be careful out there, the monsters are dangerous!"
);

-- Insert data into NPCs table
INSERT INTO quetzal.NPCs (dialog_id, name) VALUES (
1,
"Villager"
);

INSERT INTO quetzal.NPCs (dialog_id, name) VALUES (
2,
"Guard"
);

-- Insert data into Enemies table
INSERT INTO quetzal.Enemies (health, damage, speed, name) VALUES (
500,
50,
3,
"Goblin"
);

INSERT INTO quetzal.Enemies (health, damage, speed, name) VALUES (
1000,
100,
4,
"Troll"
);

-- Insert data into Heroes table
INSERT INTO quetzal.Heroes (hero_name, health, mana, damage, defense, speed) VALUES (
"Warrior",
1000,
100,
100,
100,
5
);

INSERT INTO quetzal.Heroes (hero_name, health, mana, damage, defense, speed) VALUES (
"Mage",
600,
300,
80,
60,
4
);

-- Insert data into Players table
INSERT INTO quetzal.Players (email, user_name, runs, slot_1, slot_2, slot_3) VALUES (
"user1@example.com",
"PlayerOne",
10,
NULL,
NULL,
NULL
);

INSERT INTO quetzal.Players (email, user_name, runs, slot_1, slot_2, slot_3) VALUES (
"user2@example.com",
"PlayerTwo",
20,
NULL,
NULL,
NULL
);

-- Insert data into Sessions table
INSERT INTO quetzal.Sessions (email, damage, health, mana, speed, defense, play_time, finished) VALUES (
"user1@example.com",
100,
500,
50,
4,
100,
'02:30:00',
TRUE
);

INSERT INTO quetzal.Sessions (email, damage, health, mana, speed, defense, play_time, finished) VALUES (
"user2@example.com",
120,
400,
75,
3,
80,
'01:45:00',
FALSE
);

-- Update Players table to reference the newly created sessions
UPDATE quetzal.Players SET slot_1 = 1 WHERE email = "user1@example.com";
UPDATE quetzal.Players SET slot_1 = 2 WHERE email = "user2@example.com";
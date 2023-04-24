-- Insert data into Items table
INSERT INTO quetzal.Items (item_id, name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
1,
"Armadura",
-5,
100,
-20,
-1,
0
);

INSERT INTO quetzal.Items (item_id, name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
2,
"Escudo",
0,
50,
0,
-0.5,
0
);

INSERT INTO quetzal.Items (item_id, name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
3,
"Posion Roja",
20,
-75,
30,
0,
0
);

INSERT INTO quetzal.Items (item_id, name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
4,
"Posion Verde",
-25,
0,
50,
0.5,
0
);

INSERT INTO quetzal.Items (item_id, name, damage_change, health_change, mana_change, speed_change, times_chosen) VALUES (
5,
"Sword",
40,
0,
-30,
0,
0
);

-- Insert data into Dialogs table
INSERT INTO quetzal.Dialogs (dialog_id, text) VALUES (
1,
"Welcome to our village, traveler!"
);

INSERT INTO quetzal.Dialogs (dialog_id, text) VALUES (
2,
"Be careful out there, the monsters are dangerous!"
);

-- Insert data into NPCs table
INSERT INTO quetzal.NPCs (npc_id, dialog_id, name) VALUES (
1,
1,
"Villager"
);

INSERT INTO quetzal.NPCs (npc_id, dialog_id, name) VALUES (
2,
2,
"Guard"
);

-- Insert data into Enemies table
INSERT INTO quetzal.Enemies (enemy_id, health, damage, speed, name) VALUES (
1,
500,
50,
3,
"Goblin"
);

INSERT INTO quetzal.Enemies (enemy_id, health, damage, speed, name) VALUES (
2,
1000,
100,
4,
"Troll"
);

-- Insert data into Heroes table
INSERT INTO quetzal.Heroes (id, hero_name, health, mana, damage, defense, speed) VALUES (
1,
"Warrior",
1000,
100,
100,
100,
5
);

INSERT INTO quetzal.Heroes (id, hero_name, health, mana, damage, defense, speed) VALUES (
2,
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
INSERT INTO quetzal.Sessions (session_id, email, damage, health, mana, speed, defense, play_time, finished) VALUES (
1,
"user1@example.com",
100,
500,
50,
4,
100,
'02:30:00',
TRUE
);

INSERT INTO quetzal.Sessions (session_id, email, damage, health, mana, speed, defense, play_time, finished) VALUES (
2,
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

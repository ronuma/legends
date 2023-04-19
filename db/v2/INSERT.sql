-- Insert instances for Players table
INSERT INTO quetzal.Players (player_id, user_name, runs, slot_1, slot_2, slot_3)
VALUES (1, 'PlayerOne', 0, NULL, NULL, NULL),
       (2, 'PlayerTwo', 0, NULL, NULL, NULL);

-- Insert instances for Sessions table
INSERT INTO quetzal.Sessions (session_id, player_id, damage, health, mana, speed, defense, play_time, finished)
VALUES (1, 1, 50, 500, 150, 4, 100, NOW(), FALSE),
       (2, 1, 75, 400, 100, 5, 125, NOW(), TRUE),
       (3, 2, 60, 350, 200, 3, 80, NOW(), FALSE);

-- Update Players table slots with session_ids
UPDATE quetzal.Players SET slot_1 = 1, slot_2 = 2 WHERE player_id = 1;
UPDATE quetzal.Players SET slot_1 = 3 WHERE player_id = 2;

-- Insert instances for Items table
INSERT INTO quetzal.Items (item_id, name, damage_change, defense_change, health_change, mana_change, speed_change, times_chosen)
VALUES (1, 'IronSword', 10, 0, 0, 0, 0, 0),
       (2, 'LeatherArmor', 0, 15, 0, 0, 0, 0),
       (3, 'HealthPotion', 0, 0, 50, 0, 0, 0);

-- Insert instances for Dialogs table
INSERT INTO quetzal.Dialogs (dialog_id, text)
VALUES (1, 'Welcome, traveler!'),
       (2, 'What brings you to our town?');

-- Insert instances for NPCs table
INSERT INTO quetzal.NPCs (npc_id, dialog_id, name)
VALUES (1, 1, 'Guard'),
       (2, 2, 'Innkeeper');

-- Insert instances for Dialog_NPC table
INSERT INTO quetzal.Dialog_NPC (id, dialog_id, npc_id)
VALUES (1, 1, 1),
       (2, 2, 2);

-- Insert instances for Enemies table
INSERT INTO quetzal.Enemies (enemy_id, health, damage, speed, name)
VALUES (1, 1000, 50, 3, 'Goblin'),
       (2, 1500, 100, 2, 'Ogre');

-- Insert dummy data into sessions table
INSERT INTO quet.sessions (saved_game, id, user_name, total_time, class_name) VALUES
(1, 1, 'Player1', '01:30:00', 'Warrior'),
(2, 2, 'Player2', '02:15:00', 'Mage'),
(3, 3, 'Player3', '00:45:00', 'Rogue');

-- Insert dummy data into player_info table
INSERT INTO quet.player_info (saved_game, hp, mana, def, damage, speed, location) VALUES
(1, 800, 50, 200, 100, 4, 0),
(2, 500, 250, 100, 75, 6, 1),
(3, 600, 100, 150, 90, 7, 2);

-- Insert dummy data into player_items table
INSERT INTO quet.player_items (saved_game, item_id) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5);

-- Insert dummy data into items table
INSERT INTO quet.items (item_id, hp, mana, def, damage, speed, item_name) VALUES 
(1, 50, 0, 20, 10, 0, 'Iron Sword'),
(2, 0, 25, 0, 0, 1, 'Mana Potion'),
(3, 0, 50, 0, 20, 0, 'Magic Wand'),
(4, 30, 0, 10, 0, 1, 'Leather Boots'),
(5, 0, 0, 40, 30, -1, 'Heavy Shield');

-- Insert dummy data into player_location table
INSERT INTO quet.player_location (location, character_id) VALUES
(0, 1),
(1, 2),
(2, 3);

-- Insert dummy data into characters table
INSERT INTO quet.characters (character_id, character_type, character_name, hp, rang, damage, speed) VALUES
(1, 1, 'Goblin', 500, 5, 50, 5),
(2, 2, 'Elf Archer', 400, 15, 40, 6),
(3, 3, 'Orc Warrior', 800, 1, 80, 4);

-- Insert dummy data into dialogs table
INSERT INTO quet.dialogs (character_id, dialog_id, dialog) VALUES
(1, 1, 'You shall not pass, human!'),
(2, 2, 'I can help you if you answer my riddle.'),
(3, 3, 'Only the bravest can defeat me.');

-- Insert dummy data into users table
INSERT INTO quet.users (id, user_password, security_question) VALUES
(1, 'P@ssw0rd1!', 'What is your favorite color?'),
(2, 'M@g1cP@ss!', 'What is your mother''s maiden name?'),
(3, 'R0gu3H@ck$', 'What was the name of your first pet?');

-- Insert dummy data into users_security table
INSERT INTO quet.users_security (id, token, ip_address, latest_request, active_user, password_attempt) VALUES
(1, 'TOKEN123', 3232235521, '2023-04-13 10:00:00', 1, 0),
(2, 'TOKEN456', 3232235522, '2023-04-13 11:00:00', 1, 1),
(3, 'TOKEN789', 3232235523, '2023-04-13 12:00:00', 0, 0);

-- Insert dummy data into ip_tracker table
INSERT INTO quet.ip_tracker (ip_address, max_connections, current_connections, region) VALUES
(3232235521, 10, 5, 1),
(3232235522, 15, 7, 2),
(3232235523, 20, 10, 3);

-- Insert dummy data into users_tracker table
INSERT INTO quet.users_tracker (region, max_users, current_users) VALUES
(1, 5000, 2500),
(2, 10000, 4500),
(3, 8000, 4000);
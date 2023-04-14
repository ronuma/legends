
DROP SCHEMA IF EXISTS quet;
CREATE SCHEMA quet;
-- First we create the database
-- (NOT NEEDED AS THE DB ALREADY EXISTS) CREATE DATABASE Quetzal;
-- Now we use the database
USE quet;
-- Create the main table for game dynamics, called sessions
CREATE TABLE sessions (
	saved_game BIGINT UNSIGNED NOT NULL UNIQUE,
    id BIGINT UNSIGNED NOT NULL,
    user_name VARCHAR(10) NOT NULL UNIQUE,
    total_time TIME NOT NULL,
    class_name VARCHAR(30) NOT NULL,
    PRIMARY KEY (saved_game),
	INDEX (id)
    );
-- Create the table for the the info related to the saved session based on character chosen, called player_info
CREATE TABLE player_info (
	saved_game BIGINT UNSIGNED NOT NULL UNIQUE,
    hp SMALLINT UNSIGNED NOT NULL,
    mana SMALLINT UNSIGNED NOT NULL, 
    def TINYINT UNSIGNED NOT NULL,
    damage TINYINT UNSIGNED NOT NULL,
    speed TINYINT UNSIGNED NOT NULL,
    location TINYINT UNSIGNED NOT NULL,
    FOREIGN KEY (saved_game) REFERENCES sessions(saved_game),
    PRIMARY KEY (saved_game),
    INDEX (location),
    CONSTRAINT chk_hp_player_range CHECK (hp >= 1 AND hp <= 1000),
    CONSTRAINT chk_mana_player_range CHECK (mana >= 0 AND mana <= 300),
    CONSTRAINT chk_def_player_range CHECK (def >= 0 AND def <= 250),
    CONSTRAINT chk_damage_player_range CHECK (damage >= 0 AND damage <= 125),
    CONSTRAINT chk_speed_player_range CHECK (speed >= 1 AND speed <= 8)
	);
-- Create the table for the player items related to player_info, called player_items
CREATE TABLE player_items (
	saved_game BIGINT UNSIGNED NOT NULL, 
    item_id TINYINT UNSIGNED NOT NULL,
    FOREIGN KEY (saved_game) REFERENCES player_info(saved_game),
    PRIMARY KEY (saved_game, item_id),
    INDEX (item_id)
	);
-- Create the table for items for feeding stats to player info, called items
CREATE TABLE items (
    item_id TINYINT UNSIGNED NOT NULL UNIQUE,
    hp SMALLINT NOT NULL,
    mana SMALLINT NOT NULL, 
    def TINYINT NOT NULL,
    damage TINYINT NOT NULL,
    speed TINYINT NOT NULL,
    item_name VARCHAR(30) NOT NULL,
    FOREIGN KEY (item_id) REFERENCES player_items(item_id),
    PRIMARY KEY (item_id),
    CONSTRAINT chk_hp_item_range CHECK (hp >= -100 AND hp <= 100),
    CONSTRAINT chk_mana_item_range CHECK (mana >= -50 AND mana <= 50),
    CONSTRAINT chk_def_item_range CHECK (def >= -60 AND def <= 60),
    CONSTRAINT chk_damage_item_range CHECK (damage >= -50 AND damage <= 50),
    CONSTRAINT chk_speed_item_range CHECK (speed >= -2 AND speed <= 2)
);
-- Create a player location table for feeding stats and characters to the game related to the saved session, called player-location
CREATE TABLE player_location (
    location TINYINT UNSIGNED NOT NULL,
    character_id TINYINT UNSIGNED NOT NULL UNIQUE,
    FOREIGN KEY (location) REFERENCES player_info(location),
    PRIMARY KEY (location, character_id),
    CONSTRAINT chk_location_range CHECK (location >= 0 AND location <= 5)
);
-- Create a characters table for feeding the locations in game related to player_info, called characters
CREATE TABLE characters (
	character_id TINYINT UNSIGNED NOT NULL UNIQUE,
    character_type TINYINT UNSIGNED NOT NULL,
    character_name VARCHAR(30),
    hp SMALLINT UNSIGNED NOT NULL,
    rang TINYINT UNSIGNED NOT NULL,
    damage TINYINT UNSIGNED NOT NULL,
    speed TINYINT UNSIGNED NOT NULL,
    CONSTRAINT chk_hp_character_range CHECK (hp >= 0 AND hp <= 2000),
    CONSTRAINT chk_rang_character_range CHECK (rang >= 1 AND rang <= 20),
    CONSTRAINT chk_damage_character_range CHECK (damage >= 0 AND damage <=150),
    CONSTRAINT chk_speed_character_range CHECK (speed >= 1 AND speed <= 7),
    FOREIGN KEY (character_id) REFERENCES player_location(character_id),
    PRIMARY KEY (character_id)
    );
-- Create a dialogs table for the characters for feeding in game related to player_info, called dialogs
CREATE TABLE dialogs (
	character_id TINYINT UNSIGNED NOT NULL,
    dialog_id TINYINT UNSIGNED NOT NULL UNIQUE,
    dialog VARCHAR(200),
    FOREIGN KEY (character_id) REFERENCES characters(character_id),
    PRIMARY KEY (dialog_id)
	);
-- Create a table for storing security information regarding the user that feeds the backend, called users
CREATE TABLE users (
    id BIGINT UNSIGNED NOT NULL UNIQUE,
    user_password VARCHAR(12),
    security_question VARCHAR(40),
    FOREIGN KEY (id) REFERENCES sessions(id),
    PRIMARY KEY (id)
);
-- Create a table for storing commonly used security information regarding the user that feeds the backend, called security
CREATE TABLE users_security (
	id BIGINT UNSIGNED NOT NULL UNIQUE,
	token VARCHAR(100),
    ip_address INT UNSIGNED NOT NULL,
    latest_request TIMESTAMP NOT NULL,
    active_user BOOLEAN NOT NULL,
    password_attempt TINYINT NOT NULL,
	INDEX (ip_address),
    FOREIGN KEY (id) REFERENCES users(id),
    PRIMARY KEY (id),
    CONSTRAINT chk_pa_range CHECK (password_attempt >= 0 AND password_attempt <= 3)
    );
-- Create a table for storing the general ip addresses currently used that feeds the backend, called ip_tracker
CREATE TABLE ip_tracker (
    ip_address INT UNSIGNED NOT NULL UNIQUE,
    max_connections TINYINT UNSIGNED NOT NULL,
    current_connections TINYINT UNSIGNED NOT NULL,
    region TINYINT UNSIGNED NOT NULL,
    FOREIGN KEY (ip_address) REFERENCES users_security(ip_address),
    PRIMARY KEY (ip_address),
    INDEX (region)
);
-- Create a table for storing general information of users across the region, called users_tracker
CREATE TABLE users_tracker (
    region TINYINT UNSIGNED NOT NULL UNIQUE,
    max_users INT UNSIGNED NOT NULL,
    current_users INT UNSIGNED NOT NULL,
    FOREIGN KEY (region) REFERENCES ip_tracker(region),
    PRIMARY KEY (region),
    CONSTRAINT chk_region_range CHECK (region >= 0 AND region <= 5)
);
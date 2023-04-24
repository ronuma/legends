-- EVENT used for checking the top 7 players every 60 seconds 
CREATE EVENT eval_top_players
ON SCHEDULE
	EVERY 60 SECOND
    STARTS CURRENT_TIMESTAMP
DO
-- VIEW for seeing the players with the most games completed in the lowest time possible
	CREATE VIEW top_players AS
    SELECT session_id, play_time, finished
    FROM Sessions
	WHERE play_time ORDER by play_time ASC, finished DESC LIMIT 7;
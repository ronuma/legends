CREATE VIEW sorted_items_view AS
SELECT item_id, name, times_chosen
FROM Items
ORDER BY times_chosen DESC
LIMIT 3;

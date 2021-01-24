CREATE PROCEDURE add_note (note_id UUID, note_header VARCHAR(128), note_body VARCHAR(1024), user_id INT)
LANGUAGE SQL
AS $$
INSERT INTO notes VALUES (note_id, note_header, note_body, FALSE, user_id, DEFAULT)
$$;
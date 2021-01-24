CREATE OR REPLACE FUNCTION get_note (note_id UUID)
returns TABLE (id UUID, header VARCHAR(128), body VARCHAR(128), is_deleted BOOLEAN, user_id INT,modified_at TIMESTAMPTZ,first_name VARCHAR(128),last_name VARCHAR(128))
LANGUAGE SQL
AS $$
SELECT n.*, u.first_name, last_name FROM notes n INNER JOIN users u ON n.user_id = u.id 
WHERE n.id = note_id; 
$$;
--SELECT * FROM get_note('207b16b7-3b4c-49e8-903f-5a28ee5f5f2f');
CREATE OR REPLACE FUNCTION get_user_notes (u_id INT)
returns SETOF notes
LANGUAGE SQL
AS $$
SELECT n.* FROM notes n
WHERE n.user_id = u_id AND is_deleted = FALSE
$$;
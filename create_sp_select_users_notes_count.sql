CREATE OR REPLACE FUNCTION get_notes_count ()
returns TABLE (id INT,first_name VARCHAR(128),last_name VARCHAR(128), notes BIGINT)
LANGUAGE SQL
AS $$
SELECT u.*,COUNT(n.is_deleted) as notes
FROM users u, notes n
WHERE u.id = n.user_id AND is_deleted = FALSE
GROUP BY u.id
$$;
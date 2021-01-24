CREATE PROCEDURE delete_note (note_id UUID)
LANGUAGE SQL
AS $$
UPDATE public.notes SET is_deleted = TRUE, modified_at = current_timestamp WHERE id = note_id;
$$;
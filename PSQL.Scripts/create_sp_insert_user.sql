CREATE PROCEDURE add_user (user_name VARCHAR(128), user_surname VARCHAR(128))
LANGUAGE SQL
AS $$
INSERT INTO users VALUES (DEFAULT, user_name, user_surname)
$$;


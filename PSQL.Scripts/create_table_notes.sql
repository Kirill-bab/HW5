CREATE TABLE notes(
id UUID PRIMARY KEY,
header VARCHAR(128) NOT NULL,
body VARCHAR(1024) NOT NULL,
is_deleted BOOLEAN  NOT NULL,
user_id INT NOT NULL,
FOREIGN KEY (user_id) REFERENCES users (id),
modified_at TIMESTAMPTZ DEFAULT current_timestamp
);
CREATE INDEX i ON notes (modified_at);
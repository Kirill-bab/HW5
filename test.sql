 CALL add_user('MIke','Canady'); 
 CALL add_user ('Linux','Torvalds');
 
 CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
 CALL add_note(uuid_generate_v4(),'New header','New text', 1);
 CALL add_note(uuid_generate_v4(),'Birthdaty','Happy Birthday', 2);

 SELECT * FROM get_note('207b16b7-3b4c-49e8-903f-5a28ee5f5f2f');
 SELECT * FROM get_note('4f082847-a69d-4237-b2cc-6b08891e9d52');

 CALL delete_note('4f082847-a69d-4237-b2cc-6b08891e9d52');
 CALL delete_note('207b16b7-3b4c-49e8-903f-5a28ee5f5f2f');

 SELECT * FROM get_notes_count();

 SELECT * FROM get_user_notes(1);
 SELECT * FROM get_user_notes(2);
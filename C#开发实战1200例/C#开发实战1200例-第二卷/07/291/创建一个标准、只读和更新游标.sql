USE db_TomeTwo
GO
--创建一个标准游标
DECLARE authors_cursor CURSOR FOR
SELECT au_id,au_fname,au_lname
FROM authors
GO
--创建一个只读游标
USE db_TomeTwo
GO
DECLARE authors_cursor1 CURSOR FOR
SELECT au_id,au_fname,au_lname
FROM authors
FOR READ ONLY
GO
--创建一个更新游标
USE db_TomeTwo
GO
DECLARE authors_cursor2 CURSOR FOR
SELECT au_id,au_fname,au_lname
FROM authors
FOR UPDATE
GO


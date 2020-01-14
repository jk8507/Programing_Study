import sqlite3

conn = sqlite3.connect("Steam_games.db")
cur = conn.cursor()

cur.execute("CREATE TABLE IF NOT EXISTS games(id int PRIMARY KEY, name text, tags text, price int)")
conn.commit()

cur.execute("insert or replace into games values (?, ?, ?, ?)", (0, 'test1', 'a', 10000))
conn.commit()

cur.execute("insert or replace into games values (:id, :name, :tags, :price)", {'id':1, 'name':'test2', 'tags':'b', 'price':12000})
conn.commit()

data = [
    (2, 'test3', 'a, b', 15000),
    (3, 'test4', 'b, c, d', 1000),
    (4, 'test5', 'a, f, g', 30000),
    (5, 'test6', 'a, b, d, h', 45000),
    (6, 'test7', 'h, s, c, e', 69000),
    (7, 'test8', 'g, c, s, v', 2000),
    (8, 'test9', 'f, t, w, s, c', 1000),
    (9, 'test10', 'h, c, v, b, d, s, a, x', 20000),
    (10, 'test11', 'a, g, x', 1500),
    (11, 'test12', 'y, c, e, s', 10000),
    (12, 'test13', 'e, c, x, s, d', 10000),
    (13, 'test14', 'q, w, e, r', 3000),
    (14, 'test15', 'n', 2000),
    (15, 'test16', 'w, j, d', 3000),
    (16, 'test17', 'q, r', 6000),
    (17, 'test18', 'e, h', 9000),
    (18, 'test19', 't, e, d, h, r', 25000),
    (19, 'test20', 'j, f, s, a, w, e', 54000),
    (20, 'test21', 't, h, e, s, a', 32000),
    (21, 'test22', 'f, d, s, a', 8000),
    (22, 'test23', 'z, x, c, v', 80000),
    (23, 'test24', 'm, n, b, c', 50000),
    (24, 'test25', 'o, i, u, y', 30000),
    (25, 'test26', 's, j, l, k, p', 12000),
    (26, 'test27', 's, g, c, a', 20000)
]

cur.executemany("insert or replace into games values (?, ?, ?, ?)", data)
conn.commit()

"""cur.execute('select * from games')
for row in cur:
    print(row)"""

cur.execute("CREATE TABLE IF NOT EXISTS mygames(id int PRIMARY KEY, name text, tags text)")
conn.commit()

mydata = [
    (4, 'test5', 'a, f, g'),
    (5, 'test6', 'a, b, d, h'),
    (6, 'test7', 'h, s, c, e'),
    (7, 'test8', 'g, c, s, v'),
    (8, 'test9', 'f, t, w, s, c'),
    (9, 'test10', 'h, c, v, b, d, s, a, x'),
    (10, 'test11', 'a, g, x'),
    (11, 'test12', 'y, c, e, s'),
]

cur.executemany("insert or replace into mygames values (?, ?, ?)", mydata)
conn.commit()
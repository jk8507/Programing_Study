import dbconfig

tags = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']
count = []
rank = []
recommend = []
mygametages = dbconfig.cur.execute('select tags from mygames')
rows = mygametages.fetchall()
allgames = dbconfig.cur.execute('select * from games')
lines = allgames.fetchall()


def check_redundancy():
    for tag in tags:
        countcheck = 0
        for i in range(0, len(rows)):
            if tag in rows[i][0]:
                countcheck += 1
        count.append(countcheck)


def most_favorite():
    countable = count
    match_tag = tags
    temparory = []

    for index in range(0, len(countable)):
        string = str(countable[index]) + " times overlap tag : " + match_tag[index]
        temparory.append(string)
        temparory.sort(reverse=True)

    for index in range(0, 3):
        rank.append(temparory[index])

def rank_tag():
    temparory = []

    for index in range(0, len(rank)):
        temstr = rank[index].split(' : ')
        for num in range(0, len(temstr)):
            if "tag" not in temstr[num]:
                temparory.append(temstr[num])
        rank[index] = temparory[index]

def sorting_games():
    for index in range(0, len(rank)):
        for num in range(0, len(lines)):
            if rank[index] in lines[num][2]:
                recommend.append(lines[num]),
                recommend.sort()


check_redundancy()
most_favorite()
rank_tag()
sorting_games()

recommend = list(set(recommend))
recommend.sort()
print(recommend)
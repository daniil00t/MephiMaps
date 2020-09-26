import sqlite3
conn = sqlite3.connect('schedule.db')
c = conn.cursor()


def Filter(text):
	# в виде исключения
	if "Иностранный язык" in text:
		return "Иностранный язык"
	return text.replace("\xa0", " ").replace("\xd0", " ").replace("\n", "")
def createTable(c, conn):
	# c.execute('''CREATE TABLE Marks (iter real, content text, _date text, user text, place text)''')
	c.execute('''CREATE TABLE Schedule
             (iter integer, _group text, content text, lst_update date)''')
def setTestData(c, data=''):
	text = " "
	c.execute("INSERT INTO Schedule VALUES (1, 'Б20-514', 'dzfbfghf', date())")

def getData(c):
	return c.execute('SELECT * FROM Schedule ORDER BY iter')

# createTable(c, conn)
# setTestData(c)
for i in getData(c):
	print(i)


conn.commit()
conn.close()

# Structure of DataBase:
# 1. Marsk table:
# 	|- iter 		(integer)
#		|- content 	(text) 
#		|- _date 		(date) 
#		|- user 		(text) 
#		|- place 		(text) 
# 
# 2. Users table:
# 	|- iter 		(integer)
# 	|- login 		(text)
# 	|- pass 		(md5(text))
# 	|- _date 		(date)
# 	|- ban 			(boolean)
# 	|- rating 	(integer)
# 
# Вопрос: стоит ли делать таблицу для расписания, если основной источник - модуль для его отображения?
# 3. Schedule table:
# 	|- iter 				(integer)
# 	|- group 				(boolean)
# 	|- content 			(text)
# 	|-* last_update (text)
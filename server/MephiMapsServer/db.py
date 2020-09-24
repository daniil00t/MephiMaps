import sqlite3
conn = sqlite3.connect('schedule.db')
c = conn.cursor()


def createTable(c, conn):
	# c.execute('''CREATE TABLE Marks (iter real, content text, _date text, user text, place text)''')
	c.execute('''CREATE TABLE Marks
             (iter integer, content text, _date date, user text, place text)''')
def setTestData(c, data=''):
	c.execute("INSERT INTO Marks VALUES (1, 'Там карась! приходите быстрее!', date(), 'sdm009', 'A-100'), (2, 'Там водолаз! приходите быстрее!', date(), 'sdm009', 'Б-100')")

def getData(c):
	return c.execute('SELECT * FROM Marks ORDER BY iter')

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
# 
# Вопрос: стоит ли делать таблицу для расписания, если основной источник - модуль для его отображения?
# 3. Schedule table:
# 	|- iter 				(integer)
# 	|- group 				(boolean)
# 	|- content 			(text)
# 	|- last_update 	(text)
import sqlite3
import datetime


class DB:
	"""docstring for DB"""
	def __init__(self, link):
		super(DB, self).__init__()
		self.conn = sqlite3.connect(link)
		self.cur = self.conn.cursor()

	def insertMark(self, data):
		self.cur.execute("INSERT OR IGNORE INTO Marks (content, _date, user, place) VALUES (?, ?, ?, ?)", (data["content"], str(datetime.datetime.now()), data['user'], data['place']))
	def insertUser(self, data):
		# print(data)
		self.cur.execute("INSERT OR IGNORE INTO Users (login, password, _date, ban, rating) VALUES (?, ?, ?, ?, ?)", (data["login"], data['password'], str(datetime.datetime.now()), data['ban'], data['rating']))
	def insertSchedule(self, data):
		self.cur.execute("INSERT OR IGNORE INTO Schedules (_group, content, lst_update) VALUES (?, ?, ?)", (data["_group"], data['content'], str(datetime.datetime.now())))

	def updateMark(self, id, data):
		try:
			self.cur.execute('''UPDATE OR IGNORE Marks SET content = ? WHERE id = ?''', (data["content"], id))
		except Exception as e:
			try:
				self.cur.execute('''UPDATE OR IGNORE Marks SET user = ? WHERE id = ?''', (data["user"], id))
			except Exception as e:
				self.cur.execute('''UPDATE OR IGNORE Marks SET place = ? WHERE id = ?''', (data["place"], id))
		
	def updateUser(self, id, data):
		try:
			self.cur.execute('''UPDATE OR IGNORE Users SET login = ? WHERE id = ?''', (data["login"], id))
		except Exception as e:
			try:
				self.cur.execute('''UPDATE OR IGNORE Users SET password = ? WHERE id = ?''', (data["password"], id))
			except Exception as e:
				try:
					self.cur.execute('''UPDATE OR IGNORE Users SET rating = ? WHERE id = ?''', (data["rating"], id))
				except Exception as e:
					self.cur.execute('''UPDATE OR IGNORE Users SET ban = ? WHERE id = ?''', (data["ban"], id))
		
	def updateSchedule(self, id, data):
		try:
			self.cur.execute('''UPDATE OR IGNORE Schedules SET _group = ? WHERE id = ?''', (data["_group"], id))
			self.cur.execute('''UPDATE OR IGNORE Schedules SET lst_update = ? WHERE id = ?''', (str(datetime.datetime.now()), id))
		except Exception as e:
			self.cur.execute('''UPDATE OR IGNORE Schedules SET content = ? WHERE id = ?''', (data["content"], id))
			self.cur.execute('''UPDATE OR IGNORE Schedules SET lst_update = ? WHERE id = ?''', (str(datetime.datetime.now()), id))
		

		
	def getData(self, table):
		return self.cur.execute(f"SELECT * FROM {table} ORDER BY id")

	def close(self):
		self.conn.commit()
		self.conn.close()



def createTables(cur):
	# c.execute('''CREATE TABLE Marks (iter real, content text, _date text, user text, place text)''')
	cur.execute('''CREATE TABLE Marks
             (id INTEGER PRIMARY KEY, content text, _date date, user text, place text)''')
	cur.execute('''CREATE TABLE Users
             (id INTEGER PRIMARY KEY AUTOINCREMENT, login text, password text, _date text, ban boolean, rating real)''')
	cur.execute('''CREATE TABLE Schedules
             (id INTEGER PRIMARY KEY, _group text, content text, lst_update date)''')

	


# conn = sqlite3.connect("database.db")
# cur = conn.cursor()
# createTables(cur)
# conn.commit()
# conn.close()


#
#	Здесь мы можем подредактировать таблицу
#

# db = DB("database.db")
# db.updateMark(5, {
# 	"place": "V-"
# })
# for i in db.getData("Marks"):
# 	print(i)
# db.close()


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
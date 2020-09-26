"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template
from flask import request
from MephiMapsServer import app
from MephiMapsServer import Parser
from MephiMapsServer import Filter
from MephiMapsServer import DB


@app.after_request
def add_header(r):
	"""
	Add headers to both force latest IE rendering engine or Chrome Frame,
	and also to cache the rendered page for 10 minutes.
	"""
	r.headers["Cache-Control"] = "no-cache, no-store, must-revalidate"
	r.headers["Pragma"] = "no-cache"
	r.headers["Expires"] = "0"
	r.headers['Cache-Control'] = 'public, max-age=0'
	return r


@app.route("/")
def Home():
	return render_template("layout.html", hello_start="Hello!")

@app.route("/schedule", methods=['GET', 'POST'])
def hello():
	Names = open("./MephiMapsServer/data/parser/Names.txt", encoding="utf-8").read()
	Names_arr = Names.split("\n")
	def option(el):
		return "<option selected value=" + el +">" + el +"</option>"
	__str = ""
	_str = '''
	<style>select{height:300px}</style>
	<form action="/schedule/get" method="POST">
		<select multiple name="group" height="100">
		<option disabled>Выберите группу</option>"
	'''
	for i in Names_arr:
		__str += option(i)

	return _str + __str + "</select><input type=\"submit\" value=\"search\"></form>"


@app.route("/schedule/get", methods=['GET', "POST"])
def schedule():
	if request.method == 'POST':
		# Global Vars
		Group = request.form['group']
		parser = Parser("./MephiMapsServer/data/parser/Names.txt", "./MephiMapsServer/data/parser/Links.txt", Group)
		# print(parser.Parse())
		# print(parser.Parse())
		print(*parser.Parse())
		return render_template("index.html", content=str(parser.Parse()))
		# else:
		# 	print("Ошибка! Проверьте корректность введенных данных")
	else:
		error = 'Invalid req'
		return "Error"

@app.route("/filter", methods=['GET', "POST"])
def filter():
	return '''
	<form action="/filter/get" method="POST">
		<input type="text" placeholder="text" name="text"/>
		<input type="submit" value="filter"/>
	</form>
	'''
@app.route("/filter/get", methods=['GET', "POST"])
def filterGet():
	if request.method == 'POST':
		return Filter(request.form['text'], "Consored!")
	else:
		error = 'Invalid req'
		print("error")
		return "Error"



@app.route("/marks/get", methods=['GET', "POST"])
def MarksGet():
	db = DB("./MephiMapsServer/database.db")
	arr = list(db.getData("Marks"))
	print(arr)
	# db.close()
	return render_template("index.html", title="Marks", content=arr)

@app.route("/schedules/get", methods=['GET', "POST"])
def schedulesGet():
	db = DB("./MephiMapsServer/database.db")
	arr = list(db.getData("Schedules"))
	print(arr)
	# db.close()
	return render_template("index.html", title="Schedules", content=arr)

@app.route("/users/get", methods=['GET', "POST"])
def usersGet():
	db = DB("./MephiMapsServer/database.db")
	arr = list(db.getData("Users"))
	print(arr)
	# db.close()
	return render_template("index.html", title="Users", content=arr)



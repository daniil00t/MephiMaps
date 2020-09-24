"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template
from flask import request
from MephiMapsServer import app
from MephiMapsServer import Parser

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
	<form action="/schedule/get" method="POST">
		<select multiple name="group">
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
		return "<p>" + str(parser.Parse()) + "</p>"
		# else:
		# 	print("Ошибка! Проверьте корректность введенных данных")
	else:
		error = 'Invalid req'
		return "Error"

@app.route("/filter", methods=['GET', "POST"])
def filter():
	if request.method == 'POST':
		return "this module is filter"
	else:
		error = 'Invalid req'
		return "Error"
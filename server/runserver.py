"""
This script runs the MephiMapsServer application using a development server.
"""

from os import environ
from MephiMapsServer import app

if __name__ == '__main__':
	HOST = environ.get('SERVER_HOST', 'localhost')
	try:
		PORT = int(environ.get('SERVER_PORT', '5556'))
	except ValueError:
		PORT = 5555
	app.config['SEND_FILE_MAX_AGE_DEFAULT'] = 0
	app.run(HOST, PORT, debug=True)

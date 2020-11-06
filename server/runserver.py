"""
This script runs the MephiMapsServer application using a development server.
"""

from os import environ
import eventlet
from MephiMapsServer import app, sio, appIO


if __name__ == '__main__':
	HOST = environ.get('SERVER_HOST', 'localhost')
	PORT_HTTP = 5556
	PORT_WS = 5557
		
	# socketio.run(app, HOST, PORT, debug=True)
	eventlet.wsgi.server(eventlet.listen(('localhost', PORT_WS)), appIO)
	app.run(HOST, PORT_HTTP)
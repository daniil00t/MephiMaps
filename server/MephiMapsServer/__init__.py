"""
The flask application package.
"""

from flask import Flask
import eventlet
import socketio
from MephiMapsServer.parser import Parser
from MephiMapsServer.filter import Filter
from MephiMapsServer.db import DB

app = Flask(__name__)
sio = socketio.Server()
appIO = socketio.WSGIApp(sio)

import MephiMapsServer.routes

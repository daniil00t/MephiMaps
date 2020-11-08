"""
The flask application package.
"""

from flask import Flask
from MephiMapsServer.parser import Parser
from MephiMapsServer.filter import Filter
from MephiMapsServer.api import api
from MephiMapsServer.db import DB
# from MephiMapsServer.socketServer import sio

app = Flask(__name__)

import MephiMapsServer.routes

"""
The flask application package.
"""

from flask import Flask
from MephiMapsServer.parser import Parser
from MephiMapsServer.filter import Filter
from MephiMapsServer.db import DB

app = Flask(__name__)

import MephiMapsServer.views

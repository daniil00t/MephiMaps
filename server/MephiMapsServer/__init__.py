"""
The flask application package.
"""

from flask import Flask
from MephiMapsServer.parser import Parser
from MephiMapsServer.filter import Filter

app = Flask(__name__)

import MephiMapsServer.views

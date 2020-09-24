"""
The flask application package.
"""

from flask import Flask
from MephiMapsServer.parser import Parser

app = Flask(__name__)

import MephiMapsServer.views

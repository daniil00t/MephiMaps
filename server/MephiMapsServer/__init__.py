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
class HTTPMethodOverrideMiddleware(object):
	allowed_methods = frozenset([
		'GET',
		'HEAD',
		'POST',
		'DELETE',
		'PUT',
		'PATCH',
		'OPTIONS'
	])
	bodyless_methods = frozenset(['GET', 'HEAD', 'OPTIONS', 'DELETE'])

	def __init__(self, app):
		self.app = app

	def __call__(self, environ, start_response):
		method = environ.get('HTTP_X_HTTP_METHOD_OVERRIDE', '').upper()
		if method in self.allowed_methods:
			environ['REQUEST_METHOD'] = method
		if method in self.bodyless_methods:
			environ['CONTENT_LENGTH'] = '0'
		return self.app(environ, start_response)


app.wsgi_app = HTTPMethodOverrideMiddleware(app.wsgi_app)
import MephiMapsServer.routes

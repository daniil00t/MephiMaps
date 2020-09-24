import re
from arrWords import *

# example: (\w+)?((?:п|x|h|к|k|}{)\W*[иyu]\W*[зuyi]\W*[дuyi]\W*)(\w+)?
def generateRegExps(_dictWords, _dictLetters):
	arrRegExp = []
	def unit(letter):
		# printed array behavior ""
		return r"["+ r"".join((_dictLetters[letter][i] for i in range(len(_dictLetters[letter])))) + r"]\W*"
	for i in _dictWords:
		arrRegExp.append(r"(\?w+)?((?:"+ r"|".join(_dictLetters[i[0]]) + r")\W*"+ r"".join((unit(i[j]) for j in range(1, len(i)))) +r"?)(\w+)?")
	return arrRegExp

def Filter(text, tamplate):
	_text = text
	for i in data.ARRRegExp:
		for j in re.findall(i, _text):
			_text = _text.replace("".join(j), tamplate)
	return _text

if __name__ == "__main__":
	# error shielding with regular expressions...Input yourself :(
	data = Data()

	# for i in generateRegExps(data.dictWords, data.dictLetters):
	# 	print(i)
	# print(generateRegExps(data.dictWords, data.dictLetters))
	print(Filter(data.text, "Censored!"))
	
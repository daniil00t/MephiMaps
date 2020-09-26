import bs4 as bs
import urllib.request

#init for start
class Parser:
	def __init__(self, Names, Links, Group):
		self.Names = Names
		self.Links = Links
		self.Group = Group
		self.Link = ""

	def getLink(self):
		Names_arr = []
		Links_arr = []
		Link = ""

		Names = open(self.Names, encoding="utf-8").read()
		Links = open(self.Links, encoding="utf-8").read()
		Names_arr = Names.split("\n")
		Links_arr = Links.split("\n")
		# print(Names_arr, Links_arr, self.Group, self.Group in Names_arr)
		if self.Group in Names_arr:
			Link = Links_arr[Names_arr.index(self.Group)]
			print(self.Group, " - ", Link)
			return Link
		else:
			print("ERRRRRROR!")
		

	def Request(self, Link):
		req = urllib.request.Request(Link, headers={'User-Agent': 'Mozilla/5.0'})
		html = urllib.request.urlopen(req).read()
		soup = bs.BeautifulSoup(html, features="html.parser")
		return soup

	def Filter(self, text):
		# в виде исключения
		if "Иностранный язык" in text:
			return "Иностранный язык"
		return text.replace("\xa0", " ").replace("\xd0", " ").replace("\n", "")

	def Parse(self):
		self.Link = self.getLink()
		Names_arr = []
		Links_arr = []
		Error = False
		soup = self.Request(self.Link)

		data = []
		days = soup.find_all("div", class_="list-group")

		# Data from html:
		for i in days:
			less = i.find_all("div", class_="list-group-item")
			day = []
			for j in less:
				item = {}
				time = self.Filter(j.find("div", class_="lesson-time").text)
				_type = self.Filter(j.find("div", class_="label-lesson").text)
				teacher = self.Filter(", ".join(list((k.find("a", class_="text-nowrap").text for k in j.find_all("span", class_="text-nowrap")))))
				place = self.Filter(j.find("div", class_="pull-right").text)
				name = self.Filter(j.text)
				name = name.replace(time, "").replace(teacher, "").replace(place, "").replace(_type, "")
				item["name"] = name
				item["time"] = time
				item["teacher"] = teacher
				item["place"] = place
				day.append(item)
			data.append(day)
		# open("./answers.txt", "a+").write(str(ans[0].text.split(" ")[1]) + "\n")
		return data














# if __name__ == "__main__":
# 	if not init("NameGroups.txt", "LinksGroups.txt"):
# 		soup = Request(Link)
# 		print(Parse(soup))
# 	else:
# 		print("Ошибка! Проверьте корректность введенных данных")


# хочу обратиться к создателям сайта, а именно, кто писал модуль отображения расписания: за чтооооо!
# вы же понимиаете, что вы создали костыль, а исправляется это за минуту..а мучался я с функцией Parse
# очень долго и очень мучительно... спасибо, блин

# Локаторы 
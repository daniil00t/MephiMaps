import re

# 1
match = re.search(r'\d\d\D\d\d', r'Телефон 123-12-12') 
# print(match[0] if match else 'Not found') 

# 2
# print(re.findall(r'\(\d\d\.\d\d\.\d{4}\)', r'Эта строка написана (19.01.2018), а могла бы и (01.09.2017)'))

# 3
for m in re.finditer(r'\d\d\.\d\d\.\d{4}', r'Эта строка написана 19.01.2018, а могла бы и 01.09.2017'): 
	pass
	# print('Дата', m[0], 'начинается с позиции', m.start())


text = r'''
What is Lorem IPSUM! - DOM?
Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's 
standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make 
a type specimen book. It has survived not only 4 * 3 five centuries, but also the leap into electronic typesetting, 
remaining essentially unchanged. It DO! bwas popularised in the 1960s with the release of Letraset sheets containing 
Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

Why do we use it?
183712-209384.234234 10C - CORABINа10. д393 аrашка
It is a long established fact that a reader will be distracted by the readable content of a page when looking at 
its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as 
opposed to using 'Content here, content here', making it look 10like203 rea293dable E1nglish. Many desktop publishing 
packages and web page editors now use Lorem (123)Ipsum as their default model text, and a search for 'lorem ipsum' 
will uncover many web sites still in their infancy.альбатрос10 Various versions [2--3]have evolved over the years, sometimes by 
accident, sometimes on purpose (injected humour and the like).

'''

# Practic

# 1. Найдите все натуральные числа (возможно, окружённые буквами);
# 2. Найдите все «слова», написанные капсом (то есть строго заглавными), возможно внутри настоящих слов (аааБББввв);
# 3. Найдите слова, в которых есть русская буква, а когда-нибудь за ней цифра;
# 4. Найдите все слова, начинающиеся с русской или латинской большой буквы (\b — граница слова);
# 5. Найдите слова, которые начинаются на гласную (\b — граница слова);
# 6. Найдите все натуральные числа, не находящиеся внутри или на границе слова;
# 7. Найдите строчки, в которых есть символ * (. — это точно не конец строки!);
# 8. Найдите строчки, в которых есть открывающая и когда-нибудь потом закрывающая скобки;
# 9. Выделите одним махом весь кусок оглавления (в конце примера, вместе с тегами);
# 10.Выделите одним махом только текстовую часть оглавления, без тегов;
# 11.Найдите пустые строчки;

# 1.
# print(1, re.findall(r'\d+', text))

# # 2.
# print(2, re.findall(r'[A-ZА-Я]{2,}', text))

# # 3.
# print(3, re.findall(r'[а-яА-Я]\d+', text))

# # 4.
# print(4, re.findall(r'\b[а-яА-Я]+\w+', text))

# # 5.
# print(5, re.findall(r'\b[аеёиоуэюяaeoyui]+\w+', text))

# # 6.
# print(6, re.findall(r'\B\d+\w+', text))

# # 7.
# print(7, re.findall(r'\B\d+\w+', text))




# Решение задач:
# 1.
strs = [
	"С227НА777",
	"КУ22777",
	"Т22В7477",
	"М227К19У9",
	" С227НА777",
	"Е101@777"
]
for i in strs:
	expPr = r'[АВЕКНОРСТУХ]{1}\d{3}[АВЕКНОРСТУХ]{2}\d{2,3}'
	expTax = r'[АВЕКНОРСТУХ]{2}\d{3}\d{2,3}'
	if len(re.findall(expPr, i)) != 0:
		print("private")
	else:
		print("Taxi") if len(re.findall(expTax, i)) != 0 else print("Fail")


# # 2.

str2 = '''Он --- серо-буро-малиновая редиска!! 
>>>:-> 12 2223-
А не кот. 
www.kot.ru'''
print(len(re.findall(r'[а-яА-Яa-zA-Z-]+-?', str2)))


# !!!
# Дисклеймер: 18+, в тексте присутствует ненормативная лексика. Считать корни слов совпадением с плохими словами
# !!!

class Data:
	dictWords = [
		"блят",
		"бляд",
		"хуй",
		"хуе",
		"хуи",
		"пизд",
		"пздц",
		"еба",
		"ебе",
		"fuck",
		"долбоеб"
	]
	dictLetters = {
		"а" : ['а','А', 'a', '@'],
		"б" : ['б','Б', '6', 'b'],
		"в" : ['в','В', 'b', 'v'],
		"г" : ['г','Г', 'r', 'g'],
		"д" : ['д','Д', 'd', 'g'],
		"е" : ['е','Е', 'e', "ё"],
		"ё" : ['ё','Ё', 'е', 'e'],
		"ж" : ['ж','Ж', 'zh', '*'],
		"з" : ['з','З', '3', 'z'],
		"и" : ['и','И', 'u', 'i'],
		"й" : ['й','Й', 'u', 'y', 'i'],
		"к" : ['к','К', 'k', 'i{', '|{'],
		"л" : ['л','Л', 'l', 'ji'],
		"м" : ['м','М', 'm'],
		"н" : ['н','Н', 'h', 'n'],
		"о" : ['о','О', 'o', '0'],
		"п" : ['п','П', 'n', 'p'],
		"р" : ['р','Р', 'r', 'p'],
		"с" : ['с','С', 'c', 's'],
		"т" : ['т','Т', 'm', 't'],
		"у" : ['у','У', 'y', 'u'],
		"ф" : ['ф','Ф', 'f'],
		"х" : ['х','Х', 'x', 'h', 'к', 'k', '}{'],
		"ц" : ['ц','Ц', 'c', 'u,'],
		"ч" : ['ч','Ч', 'ch'],
		"ш" : ['ш','Ш', 'sh'],
		"щ" : ['щ','Щ', 'sch'],
		"ь" : ['ь','Ь', 'b'],
		"ы" : ['ы','Ы', 'bi'],
		"ъ" : ['ъ' 'Ъ', ],
		"э" : ['э','Э', 'е', 'e'],
		"ю" : ['ю','Ю', 'io'],
		"я" : ['я','Я', 'ya'],
		"f" : ["f", "F"],
		"u" : ["u", "U"],
		"c" : ["c", "C", "с", "С"],
		"k" : ["k", "K", "к", "К"]
	}

	ARRRegExp = [
		r"(\w+)?((?:б|Б|6|b)\W*[лЛlji]\W*[яЯya]\W*[тТmt]\W*?)(\w+)?",
		r"(\w+)?((?:б|Б|6|b)\W*[лЛlji]\W*[яЯya]\W*[дДdg]\W*?)(\w+)?",
		r"(\w+)?((?:х|Х|x|h|к|k|}{)\W*[уУyu]\W*[йЙuyi]\W*?)(\w+)?",
		r"(\w+)?((?:х|Х|x|h|к|k|}{)\W*[уУyu]\W*[еЕe]\W*?)(\w+)?",
		r"(\w+)?((?:х|Х|x|h|к|k|}{)\W*[уУyu]\W*[иИui]\W*?)(\w+)?",
		r"(\w+)?((?:п|П|n|p)\W*[иИui]\W*[зЗ3z]\W*[дДdg]\W*?)(\w+)?",
		r"(\w+)?((?:п|П|n|p)\W*[зЗ3z]\W*[дДdg]\W*[цЦcu,]\W*?)(\w+)?",
		r"(\w+)?((?:е|Е|e)\W*[бБ6b]\W*[аАa@]\W*?)(\w+)?",
		r"(\w+)?((?:е|Е|e)\W*[бБ6b]\W*[еЕe]\W*?)(\w+)?",
		r"(\w+)?((?:f|F)\W*[uU]\W*[cCсС]\W*[kKкК]\W*?)(\w+)?",
		r"(\w+)?((?:д|Д|d|g)\W*[оОo0]\W*[лЛlji]\W*[бБ6b]\W*[оОo0]\W*[еЕeё]\W*[бБ6b]\W*?)(\w+)?"
	]

	text = '''
		Тю, блядь. Блядь, да мне похуй на тебя, блядь, слушай, какая у тебя там тачка, блядь, квартиры, срачки, там, 
		блядь, яхты, всё, мне пох.у.й, там, хоть, "Бэнтли", хоть, блядь, нахуй, "Майбах", хоть "Роллс-Ройс", хоть "Бугатти" блядь,
		хоть сто-метровая яхта, мне на это насрать, понимаешь? Сколько ты там кого ебешь, каких баб, каких, значит, вот этих самок
		шикарных или хуета атласных, блядь, в космос ты летишь, мне на это насрать, нахуй понимаешь? Я, блядьва, хуйня хв своём 
		познании настолько преисполнился, что я как будто бы уже xuy сто триллионов миллиардов лет, блядь, проживаю на триллионах
		и триллионах таких же планет, понимаешь, как эта Земля, мне этот мир абсолютно понятен, и я здесь ищу только одного, 
		блядь, – покоя, умиротворения и вот этой гармонии от слияния с бесконечно вечным, от созерцания того великого фрактального
		подобия и от вот этого вот замечательного всеединства существа, бесконечно вечным, куда ни x-y-й посмотри, хоть вглубь – 
		бесконечно малое, хоть ввысь – бесконечное большое, понимаешь? А ты мне опять со своими, там, это... Иди суетись дальше, 
		это твоё распределение, это москва твой путь и твой горизонт познания, ощущения и твоей природы, он несоизмеримо мелок 
		по сравнению с моим, понимаешь? Я как будто бы уже глубокий старец, бессмертный, или там уже почти бессмертный, который 
		на этой планете от её самого на... зарождения, ещё когда только Солнце только-только сформировалось как звезда, и вот 
		это газопылевое облако форми..., вот, после взрыва Солнца, когда оно вспыхнуло как звезда, начало формировать вот эти 
		коацерваты, планеты, понимаешь? Я на этой Земле уже как будто почти пять миллиардов лет, блядь, живу и её знаю уже вдоль
		и поперёк, этот весь мир, а ты мне там какие-то это... Мне похуй на твои тачки, на твои, блядь, нахуй, яхты, на твои 
		квартиры, там, на твой..., на твоё благо. Я был на этой планете, так сказать, или на бесконечном множество и круче Цезаря, 
		и круче Гитлера, и круче всех великих, понимаешь, был? А где-то был конченым говном, ещё хуже, чем здесь. Я множество этих 
		состояний чувствую. Где-то я был больше подобен растению, где-то больше подобен птице, там, червю, где-то просто был сгусток 
		камня, это всё есть душа, понимаешь? Она, она, вот, имеет грани подобия совершенно многообразные, бесконечное множество. Но 
		тебе этого не понять, поэтому ты езжай себе, блядь. Мы в этом мире, как бы, живём на ра-, в ра-, разными ощущениями, разными 
		стремлениями, соответственно, разное наше и место, разное наше распределение. Тебе я желаю всё самые крутые тачки чтоб были у 
		тебя, и все самые лучше самки чтобы раздвигали перед тобой ноги, там, все свои щели на шиворот-навыворот, блядь, перед тобой, 
		как ковёр, это самое, раскрывали, растлевали, растлали, и ты их чтобы ебал до посинения, докрасна, вон, как Солнца си... как 
		Солнце закатное, чтоб на лучших яхтах, на самолётах летал, и кончал прямо с иллюминатора, и всё что только можешь в голову 
		прийти и не прийти. Если мало идей, обращайся ко мне, я тебе на каждую твою идею ещё сотни триллионов подскажу, как что 
		делать. Ну а я – всё, я иду как глубокий старец, узревший вечное, прикоснувшийся к Божественному, сам стал богоподобен и 
		устремлён в это бесконечное, и который в умиротворении, покое, гармонии, благодати, в этом сокровенном блаженстве пребывает, 
		вовлеченный во всё и во вся, понимаешь? Вот и всё, в этом наша разница. Так что я иду любоваться мирозданием, а ты идёшь, 
		какой-то, преисполняться в ГРАНЯХ каких-то, вот и вся разница, понимаешь? Ты не зришь это вечное бесконечное, оно тебе не 
		нужно, но зато ты, так сказать, более активен как вот этот дятел долбящий или муравей, который, вот, очень активно в своём, 
		в своей стезе, вот и всё. Поэтому давай, наши пути здесь, так сказать, имеют, конечно, грани подобия, потому что всё едино, 
		но, кхм... Ты меня... Я-то тебя прекрасно понимаю, а вот ты меня – вряд ли, потому что, как бы, я... ты... как бы, я тебя в
		себе содержу, всю твою природу, она составляет одну маленькую, там, песчиночку, от того, что есть во мне, вот и всё, поэтому 
		давай, ступай, езжай, а я пошёл насло... наслаждаться, нахуй, блядь, прекрасным осенним закатом, блядь, на берегу тёплой южной 
		реки. Всё, пиздуй-бороздуй, и я попиздил, нахуй долбоеб.
	'''
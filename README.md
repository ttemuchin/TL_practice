Несколько приложений на C#:
Order Manager
Dictionary
Debug
Fighters
CarFactory
SQL
Theatre

Работа на Vite+React+Typescript:
Приложение для запоминания иностранных слов.

Представим, что у пользователя есть 10 иностранных слов, переводы которых он хочет запомнить. Есть 10 карточек. На одной стороне карточки слово на иностранном языке, а на противоположной – его перевод на русский. Заучивание происходит следующим образом:
1) Все получившиеся карточки перемешиваются и складываем в одну пачку
2) Пользователь берёт листок и ручку
3) Затем из пачки берёт по одной карточке и читает слово, которое на ней написано (не переворачивает карточку!)
4) Пытается вспомнить перевод слова
5) Если вспомнить не получается, то переворачивает карточку и читает перевод, пытается его запомнить, затем кладёт карточку вниз пачки той же стороной вверх, которой она лежала в пачке перед тем, как её взяли
6) Если пользователь вспоминает перевод, то записывает его на листок бумаги
7) Затем переворачивает карточку и сравнивает перевод с тем, что он написал на листке
8) Если переводы совпадают, значит, он выучили слово, поэтому можно отложить карточку в сторону
9) Затем берёт следующую карточку из пачки и повторяет действия с ней, начиная с 4 пункта

Обучение заканчивается, когда выучили все 10 слов, то есть в пачке не должно оставаться карточек.
У обучающегося могут быть несколько наборов карточек для разных целей или для определенных групп слов..
Эти наборы могут пополняться карточками, и, наоборот, некоторые карточки пользователь может удалить, также пользователь может отредактировать слова в карточке.

Приложение автоматизирует процесс взаимодействия с карточками. Пусть пользователь в процессе обучения также записывает слова на лист бумаги и таким образом сравнивает перевод с исходным (так процесс запоминания будет даже лучше), но сами карточки пусть будут на его компьютере.

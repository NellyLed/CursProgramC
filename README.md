Задача: разработать автоматизированную информационную систему, в которой пользователь может:
- авторизовываться/регистрироваться
- выбрать понравившийся курс
- посмотреть его программу
- выбрать преподавателя, формат обучения, пакет услуг (при этом пользователь выбирает один из предложенных вариантов)
- фильтровать, сортировать данные о преподавателях курса и формата обучения
- посмотреть скидку
- оплатить курс банковской картой
Все данные храняться в базе данных SQL.Новые данные (регистрация, оплата, курс, формат, преподаватель, пакет услуг) сохраняются в базу данных и
прикрепляются к конкретному пользователю. Если пользователь не авторизовался/ не зарегестрировался оплатить курс он не может.
Пользователь не может выбрать формат и время обучения если они не совпадают с графиком преподавателя или у него уже имеется
достаточное количество учеников. Все это проверяется путем введения хранимых процедур и триггеров в базу данных.

﻿В файле Tasks сделать так, чтобы метод GetGameSpaces() возвращал последовательность экземпляров GameSpace со следующими свойствами:

## Forces(1 балла)

В этом задании придется поупражняться в создании анонимных методов и лямбда-выражений.

Доработайте класс ForcesTask так, чтобы все методы выполняли ровно то, что написано у них в комментариях.



## Гравитация (2 балла)

В классе GameSpacesTask в добавок к существующему, создайте новые уровни, различающихся поведением гравитации:

1. zero-gravity. Нулевая гравитация.
2. heavy-gravity. Постоянная гравитация 0.9, направленная вниз.
3. white-hole. Гравитация направлена от цели. Модуль вектора гравитации вычисляется по формуле 50*d / (d+1)², где d — расстояние до цели.

Все уровни должны удовлетворять таким дополнительным условиям:

1. Расстояние от начального положения ракеты до цели должно быть не меньше 500.
2. Угол между направлением на цель и начальным направлением ракеты должен быть не менее PI/4.
3. Уровни должны различаться поведением гравитации следующим образом:


## Управление (1 балл)

Реализуйте в классе ControlTask метод управления ракетой так, чтобы он доводил ракету до цели в любом уровне как минимум за 10 секунд игрового времени!
Встройте метод управления в программу, соблюдая два условия:

1. Класс Task разрешено использовать только внутри класса Program. Из Program нужно передать ссылку на метод управления внутрь GameForm.
2. Ваш метод наведения ракеты должен работать только пока пользователь сам не управляет ракетой курсорами.
То есть у пользователя в любой момент должна быть возможность поуправлять некоторое время ракетой вручную.


## Активность на паре

В парах, сделайте ещё что-нибудь. Ускоритель, двигающаяся цель, возможность стрелять, ограниченное топливо, сбор плюшек и т.п.
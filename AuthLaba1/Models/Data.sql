/*START TRANSACTION;

-- 1) Группы
INSERT INTO `Groups` (`Name`)
VALUES
  ('Группа A'),
  ('Группа B');

-- 2) Преподаватели (Discriminator = 'Teacher')
INSERT INTO `user` (`Discriminator`, `Password`, `Username`, `Name`)
VALUES
  ('Teacher', 'teacherpass1', 'teacher1', 'Иван Иванов'),
  ('Teacher', 'teacherpass2', 'teacher2', 'Мария Петрова');

-- 3) Студенты (Discriminator = 'Student')
INSERT INTO `user` (`Discriminator`, `Password`, `Username`, `Student_Name`, `GroupId`)
VALUES
  ('Student', 'studpass1', 'student1', 'Алексей Смирнов', (SELECT Id FROM `Groups` WHERE `Name` = 'Группа A' LIMIT 1)),
  ('Student', 'studpass2', 'student2', 'Ольга Кузнецова', (SELECT Id FROM `Groups` WHERE `Name` = 'Группа A' LIMIT 1)),
  ('Student', 'studpass3', 'student3', 'Дмитрий Новиков', (SELECT Id FROM `Groups` WHERE `Name` = 'Группа B' LIMIT 1));

-- 4) Items — предметы/задания с русскими названиями
INSERT INTO `Items` (`Name`, `StudentId`, `TeacherId`)
VALUES
  ('Контрольная по математике',    (SELECT Id FROM `user` WHERE `Username` = 'student1' LIMIT 1), (SELECT Id FROM `user` WHERE `Username` = 'teacher1' LIMIT 1)),
  ('Лабораторная по физике',       (SELECT Id FROM `user` WHERE `Username` = 'student2' LIMIT 1), (SELECT Id FROM `user` WHERE `Username` = 'teacher1' LIMIT 1)),
  ('Проект по информатике',        (SELECT Id FROM `user` WHERE `Username` = 'student3' LIMIT 1), (SELECT Id FROM `user` WHERE `Username` = 'teacher2' LIMIT 1)),
  ('Дополнительное задание по англ.', (SELECT Id FROM `user` WHERE `Username` = 'student1' LIMIT 1), (SELECT Id FROM `user` WHERE `Username` = 'teacher2' LIMIT 1));

-- 5) Marks — оценки (шкала 1..5, максимум 5)
INSERT INTO `Marks` (`ItemId`, `Value`)
VALUES
  ((SELECT Id FROM `Items` WHERE `Name` = 'Контрольная по математике' LIMIT 1), 5),
  ((SELECT Id FROM `Items` WHERE `Name` = 'Контрольная по математике' LIMIT 1), 4), -- в случае нескольких оценок для одного задания
  ((SELECT Id FROM `Items` WHERE `Name` = 'Лабораторная по физике' LIMIT 1), 5),
  ((SELECT Id FROM `Items` WHERE `Name` = 'Проект по информатике' LIMIT 1), 3),
  ((SELECT Id FROM `Items` WHERE `Name` = 'Дополнительное задание по англ.' LIMIT 1), 5);

COMMIT;
*/
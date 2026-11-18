using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Services;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Users.Any())
                return;

            int studentId;
            int student2Id;
            int csharpCourseId;

            using (var transaction = db.Database.BeginTransaction())
            {
                var teacher = new User
                {
                    FullName = "Професор Денис",
                    Login = "teacher",
                    PasswordHash = PasswordHasher.Hash("teacher123"),
                    Role = UserRole.Teacher
                };
                var student = new User
                {
                    FullName = "Петренко Андрій Олегович",
                    Login = "student",
                    PasswordHash = PasswordHasher.Hash("student123"),
                    Role = UserRole.Student
                };
                var student2 = new User
                {
                    FullName = "Коваленко Марія Іванівна",
                    Login = "student2",
                    PasswordHash = PasswordHasher.Hash("student123"),
                    Role = UserRole.Student
                };
                var student3 = new User
                {
                    FullName = "Денис С.",
                    Login = "denys",
                    PasswordHash = PasswordHasher.Hash("student123"),
                    Role = UserRole.Student
                };
                db.Users.AddRange(teacher, student, student2, student3);
                db.SaveChanges();

                Course csharp = BuildCSharpCourse(teacher.Id);
                Course sql = BuildSqlCourse(teacher.Id);
                db.Courses.AddRange(csharp, sql);
                db.SaveChanges();

                db.CourseEnrollments.AddRange(
                    new CourseEnrollment { CourseId = csharp.Id, StudentId = student.Id },
                    new CourseEnrollment { CourseId = csharp.Id, StudentId = student2.Id },
                    new CourseEnrollment { CourseId = csharp.Id, StudentId = student3.Id });
                db.SaveChanges();

                transaction.Commit();

                studentId = student.Id;
                student2Id = student2.Id;
                csharpCourseId = csharp.Id;
            }

            SeedDemoAttempts(student2Id, csharpCourseId);
        }

        private static void SeedDemoAttempts(int studentId, int courseId)
        {
            List<Test> tests;
            using (var db = new AppDbContext())
            {
                tests = db.Tests.AsNoTracking()
                    .Include(t => t.Questions).ThenInclude(q => q.Options)
                    .Where(t => t.Module.CourseId == courseId)
                    .OrderBy(t => t.Module.OrderIndex)
                    .AsSplitQuery()
                    .ToList();
            }
            if (tests.Count < 2) return;

            var service = new TestService();

            service.SubmitAttempt(studentId, tests[0].Id,
                BuildAnswers(tests[0], q => true), DateTime.Now.AddMinutes(-40));

            Question first = tests[1].Questions.OrderBy(q => q.OrderIndex).First();
            service.SubmitAttempt(studentId, tests[1].Id,
                BuildAnswers(tests[1], q => q.Id == first.Id), DateTime.Now.AddMinutes(-15));
        }

        private static List<StudentAnswerInput> BuildAnswers(Test test, Func<Question, bool> answerCorrectly)
        {
            var result = new List<StudentAnswerInput>();
            foreach (Question q in test.Questions)
            {
                var input = new StudentAnswerInput { QuestionId = q.Id };
                bool correct = answerCorrectly(q);

                if (q.Type == QuestionType.TextInput)
                {
                    input.TextAnswer = correct ? q.Options.First().Text : "не знаю";
                }
                else if (correct)
                {
                    input.SelectedOptionIds = q.Options.Where(o => o.IsCorrect).Select(o => o.Id).ToList();
                }
                else
                {
                    var wrong = q.Options.FirstOrDefault(o => !o.IsCorrect);
                    if (wrong != null) input.SelectedOptionIds.Add(wrong.Id);
                }
                result.Add(input);
            }
            return result;
        }

        private static Course BuildCSharpCourse(int teacherId)
        {
            var course = new Course
            {
                Title = "Основи програмування на C#",
                Description = "Вступний курс для початківців: синтаксис мови C#, змінні, типи даних, умовні конструкції та цикли.",
                IsPublished = true,
                CreatedByUserId = teacherId
            };

            var module1 = new CourseModule
            {
                Title = "Вступ до програмування",
                Description = "Що таке C# і .NET, перша програма, змінні та типи даних.",
                OrderIndex = 1
            };
            module1.Lessons.Add(new Lesson
            {
                Title = "Що таке C#?",
                OrderIndex = 1,
                ContentRtf = new RtfBuilder()
                    .Heading("Що таке C#?")
                    .Text("C# (читається «сі-шарп») — це ").Bold("сучасна об'єктно-орієнтована мова програмування")
                    .Text(", створена компанією Microsoft у 2000 році. Програми на C# виконуються на платформі ").Bold(".NET").Text(".").EndParagraph()
                    .SubHeading("Де використовується C#")
                    .Bullet("настільні застосунки (Windows Forms, WPF);")
                    .Bullet("вебсервіси та сайти (ASP.NET Core);")
                    .Bullet("ігри (рушій Unity);")
                    .Bullet("мобільні застосунки (.NET MAUI).")
                    .SubHeading("Перша програма")
                    .Paragraph("Найпростіша програма виводить текст на екран:")
                    .Code("Console.WriteLine(\"Привіт, світ!\");")
                    .Text("Метод ").Italic("Console.WriteLine").Text(" виводить рядок у консоль і переходить на новий рядок. ")
                    .Underline("Кожна інструкція в C# закінчується крапкою з комою.").EndParagraph()
                    .Build()
            });
            module1.Lessons.Add(new Lesson
            {
                Title = "Змінні та типи даних",
                OrderIndex = 2,
                ContentRtf = new RtfBuilder()
                    .Heading("Змінні та типи даних")
                    .Text("").Bold("Змінна").Text(" — це іменована ділянка пам'яті, у якій зберігається значення. Перед використанням змінну потрібно оголосити, вказавши її ").Italic("тип").Text(".").EndParagraph()
                    .Code("int age = 18;")
                    .Code("double price = 99.95;")
                    .Code("string name = \"Андрій\";")
                    .Code("bool isStudent = true;")
                    .SubHeading("Основні типи даних")
                    .Bullet("int — ціле число (наприклад, 42);")
                    .Bullet("double — дробове число (3.14);")
                    .Bullet("bool — логічне значення true або false;")
                    .Bullet("char — один символ ('A');")
                    .Bullet("string — рядок тексту (\"Привіт\").")
                    .Text("Типи ").Bold("int, double, bool, char").Text(" є ").Underline("типами-значеннями").Text(", а ").Bold("string").Text(" — ").Underline("посилальним типом").Text(".").EndParagraph()
                    .Build()
            });
            module1.Test = new Test
            {
                Title = "Тест до модуля 1",
                Description = "Перевірка знань з основ мови C#. Для переходу до наступного модуля потрібно набрати щонайменше 70%."
            };
            module1.Test.Questions.Add(Q("Яка компанія створила мову програмування C#?", QuestionType.SingleChoice, 1, 1,
                ("Microsoft", true), ("Google", false), ("Apple", false), ("Oracle", false)));
            module1.Test.Questions.Add(Q("Які з наведених типів є типами-значеннями (value types)?", QuestionType.MultipleChoice, 2, 2,
                ("int", true), ("bool", true), ("double", true), ("string", false)));
            module1.Test.Questions.Add(Q("Яким ключовим словом оголошується змінна для цілого числа?", QuestionType.TextInput, 1, 3,
                ("int", true), ("Int32", true)));
            module1.Test.Questions.Add(Q("Яким символом закінчується кожна інструкція в C#?", QuestionType.SingleChoice, 1, 4,
                ("Крапкою з комою ;", true), ("Двокрапкою :", false), ("Крапкою .", false), ("Нічим", false)));
            course.Modules.Add(module1);

            var module2 = new CourseModule
            {
                Title = "Умовні конструкції",
                Description = "Оператори if, else та switch — як програма приймає рішення.",
                OrderIndex = 2
            };
            module2.Lessons.Add(new Lesson
            {
                Title = "Оператор if",
                OrderIndex = 1,
                ContentRtf = new RtfBuilder()
                    .Heading("Оператор if")
                    .Text("Оператор ").Bold("if").Text(" виконує блок коду лише тоді, коли умова ").Italic("істинна").Text(" (true).").EndParagraph()
                    .Code("int x = 5;")
                    .Code("if (x > 3)")
                    .Code("{")
                    .Code("    Console.WriteLine(\"Більше\");")
                    .Code("}")
                    .Code("else")
                    .Code("{")
                    .Code("    Console.WriteLine(\"Менше або дорівнює\");")
                    .Code("}")
                    .SubHeading("Оператори порівняння")
                    .Bullet("==  дорівнює;   !=  не дорівнює;")
                    .Bullet(">  більше;   <  менше;")
                    .Bullet(">=  більше або дорівнює;   <=  менше або дорівнює.")
                    .Text("Блок ").Bold("else").Text(" необов'язковий і виконується, коли умова хибна.").EndParagraph()
                    .Build()
            });
            module2.Lessons.Add(new Lesson
            {
                Title = "Оператор switch",
                OrderIndex = 2,
                ContentRtf = new RtfBuilder()
                    .Heading("Оператор switch")
                    .Text("Оператор ").Bold("switch").Text(" зручно використовувати, коли змінну потрібно порівняти з ").Underline("багатьма конкретними значеннями").Text(".").EndParagraph()
                    .Code("switch (day)")
                    .Code("{")
                    .Code("    case 1: Console.WriteLine(\"Понеділок\"); break;")
                    .Code("    case 2: Console.WriteLine(\"Вівторок\"); break;")
                    .Code("    default: Console.WriteLine(\"Інший день\"); break;")
                    .Code("}")
                    .Text("Кожна гілка ").Bold("case").Text(" повинна закінчуватися оператором ").Bold("break").Text(". Гілка ").Bold("default").Text(" виконується, якщо жоден case не підійшов.").EndParagraph()
                    .Build()
            });
            module2.Test = new Test
            {
                Title = "Тест до модуля 2",
                Description = "Умовні конструкції if та switch."
            };
            var imageQuestion = Q("Що виведе програма, блок-схему якої наведено на зображенні?", QuestionType.SingleChoice, 2, 1,
                ("Більше", true), ("Менше або дорівнює", false), ("Нічого не виведе", false), ("Помилку компіляції", false));
            imageQuestion.ImageData = ImageHelper.CreateIfStatementDiagram();
            module2.Test.Questions.Add(imageQuestion);
            module2.Test.Questions.Add(Q("Яке ключове слово завершує гілку case в операторі switch?", QuestionType.TextInput, 1, 2,
                ("break", true)));
            module2.Test.Questions.Add(Q("Які з операторів є операторами порівняння?", QuestionType.MultipleChoice, 2, 3,
                ("==", true), ("!=", true), (">=", true), ("=", false), ("+=", false)));
            course.Modules.Add(module2);

            var module3 = new CourseModule
            {
                Title = "Цикли",
                Description = "Повторення дій: цикли for, while та do-while.",
                OrderIndex = 3
            };
            module3.Lessons.Add(new Lesson
            {
                Title = "Цикл for",
                OrderIndex = 1,
                ContentRtf = new RtfBuilder()
                    .Heading("Цикл for")
                    .Text("Цикл ").Bold("for").Text(" використовують, коли ").Italic("кількість повторень відома заздалегідь").Text(".").EndParagraph()
                    .Code("for (int i = 1; i <= 5; i++)")
                    .Code("{")
                    .Code("    Console.WriteLine(i);")
                    .Code("}")
                    .Paragraph("Заголовок циклу складається з трьох частин: ініціалізація (int i = 1), умова продовження (i <= 5) і крок (i++).")
                    .Build()
            });
            module3.Lessons.Add(new Lesson
            {
                Title = "Цикли while і do-while",
                OrderIndex = 2,
                ContentRtf = new RtfBuilder()
                    .Heading("Цикли while і do-while")
                    .Text("Цикл ").Bold("while").Text(" спочатку перевіряє умову, а потім виконує тіло. Якщо умова одразу хибна — тіло не виконається жодного разу.").EndParagraph()
                    .Code("while (count < 10) { count++; }")
                    .Text("Цикл ").Bold("do-while").Text(" спочатку виконує тіло, а потім перевіряє умову, тому ").Underline("тіло виконується щонайменше один раз").Text(".").EndParagraph()
                    .Code("do { count++; } while (count < 10);")
                    .Build()
            });
            module3.Test = new Test
            {
                Title = "Тест до модуля 3",
                Description = "Цикли for, while і do-while."
            };
            module3.Test.Questions.Add(Q("Який цикл виконує тіло щонайменше один раз?", QuestionType.SingleChoice, 1, 1,
                ("do-while", true), ("while", false), ("for", false), ("foreach", false)));
            module3.Test.Questions.Add(Q("Скільки разів виконається тіло циклу for (int i = 0; i < 3; i++)? Введіть число.", QuestionType.TextInput, 1, 2,
                ("3", true), ("три", true)));
            module3.Test.Questions.Add(Q("Які частини містить заголовок циклу for?", QuestionType.MultipleChoice, 2, 3,
                ("Ініціалізація", true), ("Умова", true), ("Крок (зміна лічильника)", true), ("Блок catch", false)));
            course.Modules.Add(module3);

            return course;
        }

        private static Course BuildSqlCourse(int teacherId)
        {
            var course = new Course
            {
                Title = "Основи баз даних та SQL",
                Description = "Реляційні бази даних, таблиці, ключі та базові SQL-запити.",
                IsPublished = true,
                CreatedByUserId = teacherId
            };

            var module = new CourseModule
            {
                Title = "Реляційні бази даних",
                Description = "Таблиці, первинні та зовнішні ключі.",
                OrderIndex = 1
            };
            module.Lessons.Add(new Lesson
            {
                Title = "Таблиці та ключі",
                OrderIndex = 1,
                ContentRtf = new RtfBuilder()
                    .Heading("Таблиці та ключі")
                    .Text("Реляційна база даних складається з ").Bold("таблиць").Text(". Кожен рядок таблиці — це окремий запис, а стовпець — його властивість.").EndParagraph()
                    .Bullet("Первинний ключ (PRIMARY KEY) однозначно ідентифікує рядок таблиці.")
                    .Bullet("Зовнішній ключ (FOREIGN KEY) посилається на первинний ключ іншої таблиці і задає зв'язок між ними.")
                    .Code("SELECT FullName FROM Users WHERE Role = 2;")
                    .Build()
            });
            module.Test = new Test { Title = "Тест: реляційні бази даних", Description = "Ключі та таблиці." };
            module.Test.Questions.Add(Q("Що однозначно ідентифікує рядок таблиці?", QuestionType.SingleChoice, 1, 1,
                ("Первинний ключ", true), ("Зовнішній ключ", false), ("Індекс", false)));
            module.Test.Questions.Add(Q("Яка команда SQL використовується для вибірки даних?", QuestionType.TextInput, 1, 2,
                ("SELECT", true)));
            course.Modules.Add(module);

            return course;
        }

        private static Question Q(string text, QuestionType type, int points, int order,
            params (string Text, bool IsCorrect)[] options)
        {
            var question = new Question { Text = text, Type = type, Points = points, OrderIndex = order };
            int index = 1;
            foreach (var option in options)
            {
                question.Options.Add(new AnswerOption
                {
                    Text = option.Text,
                    IsCorrect = option.IsCorrect,
                    OrderIndex = index++
                });
            }
            return question;
        }
    }
}

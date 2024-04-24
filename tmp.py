import random
import faker

# Generate 1,000 insert statements
with open('D:/code/uni/c#/coursework ui/queries.txt', 'w') as file:
    insert_statements = []
    for i in range(1, 1001):
        name = faker.Faker().name()
        telephone = f'{random.randint(100, 999)}-{random.randint(100, 999)}-{random.randint(1000, 9999)}'
        email = faker.Faker().email()
        role = random.choice(['teacher', 'admin', 'student'])
        insert_statement = f"INSERT INTO `people` (`people_id`, `Name`, `phone`, `Email`, `Role`) VALUES ({i}, '{name}', '{telephone}', '{email}', '{role}');"
        file.write(insert_statement + '\n')
        insert_statements.append(insert_statement)
        if (role == 'teacher'):
            salary = random.randint(30000, 60000) + random.random()
            subject1 = random.choice(['Mathematics', 'Physics', 'Chemistry', 'Biology', 'Art', 'Music', 'English', 'History', 'Geography'])
            subject2 = random.choice(['Mathematics', 'Physics', 'Chemistry', 'Biology', 'Art', 'Music', 'English', 'History', 'Geography'])
            insert_statement = f"INSERT INTO `teacher` (`people_id`,  `Salary`, `Subject1`, `Subject2`) VALUES ({i}, {salary:.2f}, '{subject1}', '{subject2}');"
        elif (role == 'admin'):
            salary = random.randint(30000, 60000) + random.random()
            full_time = random.choice(['Full-time', 'Part-time'])
            working_hours = random.randint(20, 40)
            insert_statement = f"INSERT INTO `admin` (`people_id`, `Salary`, `Employment_Type`, `Working_Hours`) VALUES ({i}, {salary:.2f}, '{full_time}', {working_hours});"
        else:
            subject1_current = random.choice(['Mathematics', 'Physics', 'Chemistry', 'Biology', 'Art', 'Music', 'English', 'History', 'Geography'])
            subject2_current = random.choice(['Mathematics', 'Physics', 'Chemistry', 'Biology', 'Art', 'Music', 'English', 'History', 'Geography'])
            subject1_previous = random.choice(['Mathematics', 'Physics', 'Chemistry', 'Biology', 'Art', 'Music', 'English', 'History', 'Geography'])
            subject2_previous = random.choice(['Mathematics', 'Physics', 'Chemistry', 'Biology', 'Art', 'Music', 'English', 'History', 'Geography'])
            insert_statement = f"INSERT INTO `Student` (`people_id`, `current_subject1`, `current_subject2`, `previous_subject1`, `previous_subject2`) VALUES ({i}, '{subject1_current}', '{subject2_current}', '{subject1_previous}', '{subject2_previous}');"
        # insert_statements.append(insert_statement)
        # for statement in insert_statements:
        file.write(insert_statement + '\n')
        


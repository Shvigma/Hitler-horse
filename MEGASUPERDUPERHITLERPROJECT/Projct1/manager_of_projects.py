def create():

    l=input("Добавьте заметку")
    z.append(l)
    pass
def delete():
    q=input("найдите нужную заметку")
    z.pop(show(q))
    pass
def search():
    l=input("Добавьте заметку")
    pass
def close():

    print("Досвидания")
    exit()
    pass
def show(srting):
    l=input("Добавьте заметку")
    pass
def interface():
    print("Здравствуй пользователь, это я менедежер твоих заметок")
    while True:
        phrase="""
        команды:
        1 - создать заметку
        2 -  удалить заметку
        3 - найти заметку
        4 - закрыть заметку
        5 - показать заметку


        Введите номер выбраной команды:
        """
        print(phrase)
        answer=input()

        if answer == "1":
                create()
        if answer == "2":
                delete()
        if answer == "3":
                search()
        if answer == "4":
                close()
        if answer == "5":
                show()
        else :
                print("Введеной вами команды не существует!!!, пожалуйста введите ещё раз.")
                continue
file=open("BD.txt","r+")
z=file.readlines()
if __name__ == "__main__":
    interface()
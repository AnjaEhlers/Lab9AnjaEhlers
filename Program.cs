List<(string, string, DateTime)>  todoList = new List<(string, string, DateTime)>();
DateTime beginningStart = new DateTime();
List<(string, string, DateTime, DateTime)> doThings = new List<(string, string, DateTime, DateTime)>();
DateTime timeTaskIsDone = new DateTime();
void menu(){
    Console.WriteLine("task managing, what do you want to do?");
    Console.WriteLine("1.see things that still need to be done 2. see what you've completed. 3. add tasks. 4. mark tasks as completed. 5. exit");
    string response = Console.ReadLine();
    if(response == "1")
        ToDoItems();
    if(response == "2")
        tasksAccomplished();
    if(response == "3")
        addingTasks();
    if(response == "4")
        finishingStuff();
    if(response == "5")
        System.Environment.Exit(0);
    else{
        menu();
    }
}
menu();
void ToDoItems(){
    Console.WriteLine("Things you need to do");
    for(int x = 0; x <todoList.Count; x++){
        Console.WriteLine($" {x + 1}: {todoList[x]}");
    }
    if(todoList.Count == 0)
    Console.WriteLine("you're all set! nothing to do.");
    Console.ReadLine();
}
void tasksAccomplished(){
    Console.WriteLine("what you've accomplished:");
    for(int x = 0; x < doThings.Count; x++){
    Console.WriteLine($" {x + 1}: {doThings[x]}");
    }
    if(doThings.Count == 0)
    Console.WriteLine("nada");
    Console.ReadLine();
}
void finishingStuff(){
    Console.WriteLine("which task do you want to edit?");
    for(int x = 0; x <todoList.Count; x++){
        Console.WriteLine($" {x + 1}: {todoList[x]}");
    }
    Console.WriteLine("(type a numero.)");
    int userNumber = int.Parse(Console.ReadLine()) - 1;
    if(userNumber > todoList.Count){
        Console.WriteLine("no entiendo");
    }
    Console.WriteLine($"did you finish this? {todoList[userNumber]}<yes or no>");
    string response = Console.ReadLine();
    if(response == "yes"){
        Console.WriteLine("boom. done.");
        (string, string, DateTime) taskDone = todoList[userNumber];
        timeTaskIsDone = DateTime.Now;
        todoList.Remove(todoList[userNumber]);
       doThings.Add((taskDone.Item1,taskDone.Item2, taskDone.Item3, timeTaskIsDone));
    }
    if(response == "no"){
        Console.WriteLine("no problem");
    }
}
void addingTasks(){
        Console.WriteLine("what do u wanna add?");
        string response = Console.ReadLine();
        string chore = response;
        Console.WriteLine($"here's the thing you wanted to add: {chore}");
        Console.WriteLine("describe it.");
        response = Console.ReadLine();
        string description = response;
        Console.WriteLine($"this is what you put: {chore}: {description}");
        Console.WriteLine("do you want this?<yes or no>");
        response = Console.ReadLine();
        if(response == "yes"){
            Console.WriteLine("added.");
            beginningStart = DateTime.Now;
            (string, string, DateTime) taskNeeded = (chore, description, beginningStart);
            todoList.Add(taskNeeded);
        }
        if(response == "no"){
            Console.WriteLine("np, not adding it.");

        }
    }